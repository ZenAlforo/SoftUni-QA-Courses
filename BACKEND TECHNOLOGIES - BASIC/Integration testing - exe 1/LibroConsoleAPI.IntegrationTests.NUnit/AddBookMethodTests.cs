using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Business;
using LibroConsoleAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using System.Threading.Tasks;
using LibroConsoleAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibroConsoleAPI.IntegrationTests.NUnit
{
    public class AddBookMethodTests
    {
        private TestLibroDbContext dbContext;
        private IBookManager bookManager;

        [SetUp]
        public void SetUp()
        {
            string dbName = $"TestDb_{Guid.NewGuid()}";
            this.dbContext = new TestLibroDbContext(dbName);
            this.bookManager = new BookManager(new BookRepository(this.dbContext));
        }

        [TearDown]
        public void TearDown()
        {
            this.dbContext.Dispose();
        }

        [Test]
        public async Task AddBookAsync_ShouldAddBook()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test Book",
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };

            // Act
            await bookManager.AddAsync(newBook);

            // Assert
            var bookInDb = await dbContext.Books.FirstOrDefaultAsync(b => b.ISBN == newBook.ISBN);
            Assert.NotNull(bookInDb);
            Assert.AreEqual("Test Book", bookInDb.Title);
            Assert.AreEqual("John Doe", bookInDb.Author);
        }

        [Test]
        public async Task AddBookAsync_TryToAddBookWithInvalidIsbn_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test Book",
                Author = "John Doe",
                ISBN = "123456789012345",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };

            // Act
            var ex = Assert.ThrowsAsync<ValidationException>(() => bookManager.AddAsync(newBook));

            // Assert
            Assert.AreEqual("Book is invalid.", ex.Message);
            Assert.IsEmpty(dbContext.Books);
        }

        [Test]
        public async Task AddBookAsync_TryToAddBookWithInvalidTitle_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = new string('t', 500),
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };

            // Act
            var ex = Assert.ThrowsAsync<ValidationException>(() => bookManager.AddAsync(newBook));

            // Assert
            Assert.AreEqual("Book is invalid.", ex.Message);
            Assert.IsEmpty(dbContext.Books);
        }

        [Test]
        public async Task AddBookAsync_TryToAddBookWithInvalidPrice_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test Book",
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 0
            };

            // Act
            var ex = Assert.ThrowsAsync<ValidationException>(() => bookManager.AddAsync(newBook));

            // Assert
            Assert.AreEqual("Book is invalid.", ex.Message);
            Assert.IsEmpty(dbContext.Books);
        }

        [Test]
        public async Task AddBookAsync_TryToAddBookWithInvalidYear_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test Book",
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 1650,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };

            // Act
            var ex = Assert.ThrowsAsync<ValidationException>(() => bookManager.AddAsync(newBook));

            // Assert
            Assert.AreEqual("Book is invalid.", ex.Message);
            Assert.IsEmpty(dbContext.Books);
        }

        [Test]
        public async Task AddBookAsync_TryToAddBookWithInvalidPages_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test Book",
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 0,
                Price = 19.99
            };

            // Act
            var ex = Assert.ThrowsAsync<ValidationException>(() => bookManager.AddAsync(newBook));

            // Assert
            Assert.AreEqual("Book is invalid.", ex.Message);
            Assert.IsEmpty(dbContext.Books);
        }
    }
}
