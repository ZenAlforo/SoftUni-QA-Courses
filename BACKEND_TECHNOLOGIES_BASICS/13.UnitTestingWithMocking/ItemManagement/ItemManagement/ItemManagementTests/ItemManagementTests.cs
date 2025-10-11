using NUnit.Framework;
using Moq;
using ItemManagementApp.Services;
using ItemManagementLib.Repositories;
using ItemManagementLib.Models;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Constraints;

namespace ItemManagement.Tests
{
    [TestFixture]
    public class ItemManagementTests
    {
        private Mock<IItemRepository> _mockedItemRepo;
        private ItemService _itemService;


        [SetUp]
        public void SetUp()
        {
            _mockedItemRepo = new Mock<IItemRepository>();
            _itemService = new ItemService( _mockedItemRepo.Object );
        }

        [Test]
        public void AddItem_ShouldAddItem_WithValidName()
        {
            // Arrange
            Item myItem = new Item { Id = 1, Name = "MyItem"};
            _mockedItemRepo.Setup(repo => repo.AddItem(It.IsAny<Item>()));

            // Act
            _itemService.AddItem(myItem.Name);

            // Assert
            _mockedItemRepo.Verify(x => x.AddItem(It.Is<Item>(i => i.Name == myItem.Name)), Times.Once());
        }

        [TestCase("12345678910")]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        public void AddItem_ShouldThrowArgumentException_WithInvalidName(string name)
        {
            // Arrange
            Item myItem = new Item { Id = 1, Name = name };
            _mockedItemRepo.Setup(repo => repo.AddItem(It.IsAny<Item>())).Throws(new ArgumentException("Item name must be between 1 and 10 characters."));

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _itemService.AddItem(myItem.Name));
            _mockedItemRepo.Verify(repo => repo.AddItem(It.Is<Item>(i => i.Name == myItem.Name)), Times.Once());
            Assert.That(ex.Message, Is.EqualTo("Item name must be between 1 and 10 characters."));
        }

        [Test]
        public void GetAllItems_ShouldReturnItemsInRepo_WhenItemsInRepo()
        {
            // Arrange
            List<Item> myItems = new List<Item>() { new Item { Id = 1, Name = "Item1" }, new Item { Id = 2, Name = "Item2" } };
            _mockedItemRepo.Setup(repo => repo.GetAllItems()).Returns(myItems);

            // Act
            var result = _itemService.GetAllItems();

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count, Is.EqualTo(2));
            _mockedItemRepo.Verify(x => x.GetAllItems(), Times.Once());
        }

        [Test]
        public void GetAllItems_ShouldReturnEmptyList_WhenNoItemsInRepo()
        {
            // Arrange
            List<Item> myItems = new List<Item>();
            _mockedItemRepo.Setup(repo => repo.GetAllItems()).Returns(myItems);

            // Act
            var result = _itemService.GetAllItems();

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count, Is.EqualTo(0));
            _mockedItemRepo.Verify(x => x.GetAllItems(), Times.Once());
        }

        [Test]
        public void GetItemById_ShouldReturnItem_WithExistingId()
        {
            // Arrange
            Item item = new Item() { Id = 1, Name = "myItem"};
            _mockedItemRepo.Setup(repo => repo.GetItemById(item.Id)).Returns(item);

            // Act
            var result = _itemService.GetItemById(item.Id);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Name, Is.EqualTo(item.Name));
            _mockedItemRepo.Verify(repo => repo.GetItemById(item.Id), Times.Once());
        }

        [Test]
        public void GetItemById_ShouldReturnItem_WithNonExistingId()
        {
            // Arrange
            
            _mockedItemRepo.Setup(repo => repo.GetItemById(It.IsAny<int>())).Returns<Item>(null);

            // Act
            var result = _itemService.GetItemById(123);

            // Assert
            Assert.IsNull(result);
            _mockedItemRepo.Verify(repo => repo.GetItemById(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void UpdateItem_ShouldSucceed_WhenItemExists()
        {
            // Arrange
            Item myItem = new Item() { Id = 1, Name = "myItem" };
            string newName = "EditedName";
            _mockedItemRepo.Setup(repo => repo.GetItemById(myItem.Id)).Returns(myItem);
            _mockedItemRepo.Setup(repo => repo.UpdateItem(It.IsAny<Item>()));

            // Act
            _itemService.UpdateItem(myItem.Id, newName);

            // Assert
            _mockedItemRepo.Verify(repo => repo.GetItemById(myItem.Id), Times.Once());
            _mockedItemRepo.Verify(repo => repo.UpdateItem(It.Is<Item>(i => i.Id == myItem.Id && i.Name == myItem.Name)), Times.Once());
        }

        [Test]
        public void UpdateItem_ShouldReturnNull_WhenItemDoNotExists()
        {
            // Arrange
            int nonExistingId = 1;
            string newName = "NewName";
            _mockedItemRepo.Setup(repo => repo.GetItemById(nonExistingId)).Returns<Item>(null);
            _mockedItemRepo.Setup(repo => repo.UpdateItem(It.IsAny<Item>()));

            // Act
            _itemService.UpdateItem(nonExistingId, newName);

            // Assert
            _mockedItemRepo.Verify(repo => repo.GetItemById(nonExistingId), Times.Once());
            _mockedItemRepo.Verify(repo => repo.UpdateItem(It.IsAny<Item>()), Times.Never());
        }

        [TestCase("MyNameIsVeryLong")]
        [TestCase("")]
        [TestCase("    ")]
        [TestCase(null)]
        public void UpdateItem_ShouldThrowArgumentException_WhenNewNameIsInvalid(string newName)
        {
            // Arrange
            Item myItem = new Item() { Id = 1, Name = "myItem" };
            myItem.Name = newName;

            _mockedItemRepo.Setup(repo => repo.GetItemById(myItem.Id)).Returns(myItem);
            _mockedItemRepo.Setup(repo => repo.UpdateItem(It.Is<Item>(i => string.IsNullOrWhiteSpace(i.Name) || i.Name.Length > 10))).Throws(new ArgumentException("Item name must be between 1 and 10 characters."));

            // Act & Assert
            var ex = Assert.Throws<ArgumentException> (() => _itemService.UpdateItem(myItem.Id, newName));

            _mockedItemRepo.Verify(repo => repo.GetItemById(myItem.Id), Times.Once());
            _mockedItemRepo.Verify(repo => repo.UpdateItem(It.IsAny<Item>()), Times.Once());
            Assert.That(ex.Message, Is.EqualTo("Item name must be between 1 and 10 characters."));
        }

        [Test]
        public void DeleteItem_ShouldDeleteItemFromTheRepo_WithExistingId()
        {
            // Arrange
            var itemId = 12;
            _mockedItemRepo.Setup(repo => repo.DeleteItem(itemId));

            // Act
            _itemService.DeleteItem(itemId);

            // Assert
            _mockedItemRepo.Verify(repo => repo.DeleteItem(itemId), Times.Once());
        }

        [TestCase("1")]
        [TestCase("21hj21")]
        [TestCase("1234567891")]

        public void ValidateItemName_ShouldReturnCorrectAnswer_IfItemNameIsValid(string name)
        {
            // Arrange & Act
            var result = _itemService.ValidateItemName(name);

            // Assert
            Assert.IsTrue(result);
        }

        [TestCase("")]
        [TestCase("12345678910")]
        [TestCase("    ")]
        [TestCase(null)]
        public void ValidateItemName_ShouldReturnCorrectAnswer_IfItemNameIsNotValid(string name)
        {
            // Arrange & Act
            var result = _itemService.ValidateItemName(name);

            // Assert
            Assert.IsFalse(result, $"Validation should fail for input: `{name ?? null}`");
        }

    }
}