using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using LibroConsoleAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.NUnit
{
    public class GetSpecificMethodTests
    {
        public TestLibroDbContext dbContext;
        public IBookManager bookManager;

        [SetUp] 
        public void Setup()
        {
            string dbName = Guid.NewGuid().ToString();
            dbContext = new TestLibroDbContext(dbName);
            bookManager = new BookManager(new BookRepository(dbContext));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        [Test]
        public async Task GetSpecificAsync_WithValidIsbn_ShouldReturnCorrectBook()
        {
            // Arrange
            Book newBook = new Book
            {
                ISBN = "1234567891012",
                Title = "Title",
                Author = "Author",
                YearPublished = 1830,
                Genre = "fantasy",
                Pages = 650,
                Price = 10.99
            };

            await bookManager.AddAsync(newBook);

            // Act
            var bookInDb = await bookManager.GetSpecificAsync(newBook.ISBN);

            // Assert
            Assert.IsNotNull(bookInDb);
            Assert.That(bookInDb, Is.EqualTo(newBook));
        }

        [Test]
        public async Task GetSpecificAsync_WithEmptyIsbn_ShouldThrowArgumentException()
        {
            // Arrange
            Book newBook = new Book
            {
                ISBN = "1234567891012",
                Title = "Title",
                Author = "Author",
                YearPublished = 1830,
                Genre = "fantasy",
                Pages = 650,
                Price = 10.99
            };

            await bookManager.AddAsync(newBook);

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(() => bookManager.GetSpecificAsync("  "));
            Assert.That(ex.Message, Is.EqualTo("ISBN cannot be empty."));
        }

        [Test]
        public async Task GetSpecificAsync_WithNonExistingIsbn_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            Book newBook = new Book
            {
                ISBN = "1234567891012",
                Title = "Title",
                Author = "Author",
                YearPublished = 1830,
                Genre = "fantasy",
                Pages = 650,
                Price = 10.99
            };

            await bookManager.AddAsync(newBook);
            string isbnToSearch = "1212121212123";

            // Act & Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => bookManager.GetSpecificAsync(isbnToSearch));
            Assert.That(ex.Message, Is.EqualTo($"No book found with ISBN: {isbnToSearch}"));
        }
    }
}
