using NUnit.Framework;
using Moq;
using ItemManagementApp.Services;
using ItemManagementLib.Repositories;
using ItemManagementLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace ItemManagement.Tests
{
    [TestFixture]
    public class ItemServiceTests
    {
        // the subject of testing
        private ItemService _itemService;
        // the subject of mocking
        private Mock<IItemRepository> _mockItemRepository;

        [SetUp]
        public void Setup()
        {
            // Arrange: Create a mock instance of IItemRepository
            _mockItemRepository = new Mock<IItemRepository>();
            // Instantiate ItemService with the mocked repository
            _itemService = new ItemService(_mockItemRepository.Object);
        }

        [Test]
        public void TestAddItem_WhenItemIsValid_ShouldBeSuccessful()
        {
            // Arrange
            Item item = new Item() { Id = 2, Name = "dog" };
            _mockItemRepository.Setup(x => x.AddItem(It.IsAny<Item>()));

            // Act
            _itemService.AddItem(item.Name);

            // Assert: cannot assert by the object item cause the mocks verify by reference (which in both cases is different).
            _mockItemRepository.Verify(x => x.AddItem(It.IsAny<Item>()), Times.Exactly(1));
        }

        [Test]
        public void TestAddItem_WhenItemNameIsValid_ShouldThrowAnError()
        {
            // Arrange
            string invalidName = "";
            _mockItemRepository.Setup(x => x.AddItem(It.IsAny<Item>())).Throws<ArgumentException>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _itemService.AddItem(invalidName));
            _mockItemRepository.Verify(x => x.AddItem(It.IsAny<Item>()), Times.Exactly(1));
        }

        [Test]
        public void GetAllItems_WhenThereAreItemsInsideTheDb_ShouldReturnAllItems()
        {
            // Arrange: item list for inserting into the db
            var items = new List<Item>() { new Item { Id = 1, Name = "SampleItem" }, new Item { Id = 2, Name = "SampleItem2" } };
            // inserting the item list int he db
            _mockItemRepository.Setup(x => x.GetAllItems()).Returns(items);
            // Act: call the GetAllItems method and save it to a variable result
            var result = _itemService.GetAllItems();
            // Assert: 1 - not null, 2 - count of items inside the result, 3 - verify calling the GetAllItems method once
            Assert.NotNull(result);
            Assert.IsNotEmpty(result);
            Assert.That(result.Count(), Is.EqualTo(2));
            _mockItemRepository.Verify(x => x.GetAllItems(), Times.Once());
        }

        [Test]
        public void TestGetItemById_WhenValidIdIsGiven_ShouldReturnTheItem()
        {
            // Arrange
            Item item = new Item { Id = 1, Name = "Cat" };
            _mockItemRepository.Setup(x => x.GetItemById(item.Id)).Returns(item);

            // Act
            var result = _itemService.GetItemById(item.Id);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Name, Is.EqualTo(item.Name));
            _mockItemRepository.Verify(x => x.GetItemById(item.Id), Times.Once());
        }

        [Test] 
        public void TestGetItemById_WhenInvalidIdIsGiven_ShouldReturnNull()
        {
            // Arrange
            _mockItemRepository.Setup(x => x.GetItemById(It.IsAny<int>())).Returns<Item>(null);

            // Act
            var result = _itemService.GetItemById(123);

            // Assert
            Assert.Null(result);
            _mockItemRepository.Verify(x => x.GetItemById(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void TestUpdateItem_WhenExistingItemIsUpdated_ShouldBeSuccessful()
        {
            // Arrange
            var item = new Item { Id = 1, Name = "SampleItem" };
            _mockItemRepository.Setup(x => x.GetItemById(item.Id)).Returns(item);
            _mockItemRepository.Setup(x => x.UpdateItem(It.IsAny<Item>()));

            // Act
            _itemService.UpdateItem(item.Id, "New Title");

            // Assert
            _mockItemRepository.Verify(x => x.GetItemById(item.Id), Times.Once());
            _mockItemRepository.Verify(x => x.UpdateItem(It.IsAny<Item>()), Times.Once());
        }

        [Test]
        public void TestUpdateItem_WhenNonExistingItemIsGiven_ShouldNotUpdateItem()
        {
            // Arrange: 
            var item = new Item { Id = 1, Name = "SampleItem" };
            _mockItemRepository.Setup(x => x.GetItemById(item.Id)).Returns(item);
            _mockItemRepository.Setup(x => x.UpdateItem(It.IsAny<Item>())).Throws<ArgumentException>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _itemService.UpdateItem(item.Id, ""));

            _mockItemRepository.Verify(x => x.GetItemById(item.Id), Times.Once());
            _mockItemRepository.Verify(x => x.UpdateItem(It.IsAny<Item>()), Times.Once());
        }

        [Test]
        public void TestUpdateItem_ShouldThrowException_WhenNonValidItemNameIsGiven()
        {
            // Arrange: Creating id for non existing item and passing it to GetItemById => ensuring it returns 'null' so that other method cannot be called upon null collection, then trying to see if possible to call UpdateItemMethod
            var nonExistingItem = 3;
            _mockItemRepository.Setup(x => x.GetItemById(nonExistingItem)).Returns<Item>(null);
            _mockItemRepository.Setup(x => x.UpdateItem(It.IsAny<Item>()));

            // Act: Calling the UpdateItemMethod
            _itemService.UpdateItem(nonExistingItem, "DoesNotMatter");

            // Asserting that GetItemById was called one, and that UpdateItem method was NEVER called
            _mockItemRepository.Verify(x => x.GetItemById(nonExistingItem), Times.Once());
            _mockItemRepository.Verify(x => x.UpdateItem(It.IsAny<Item>()), Times.Never());
        }

        [Test]
        public void TestDeleteItemMethod_WhenValidIdIsGiven_ShouldBeSuccessful()
        {
            // Arrange
            var item = new Item { Id = 1, Name = "Some Title" };
            _mockItemRepository.Setup(x => x.DeleteItem(item.Id));

            // Act
            _itemService.DeleteItem(item.Id);

            // Assert
            _mockItemRepository.Verify(x => x.DeleteItem(item.Id), Times.Once());
        }

        [TestCase("", false)]
        [TestCase(null, false)]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaa", false)]
        [TestCase("A", true)]
        [TestCase("Normal", true)]
        [TestCase("NormalOne", true)]
        public void TestValidationItemNameMethod_WhenDifferentNamesAreGiven_ShouldReturnCorrectAnswer(string name, bool isValid)
        {
            // Arrange

            // Act
            var result = _itemService.ValidateItemName(name);

            // Assert
            Assert.That(result, Is.EqualTo(isValid));
        }
    }
}