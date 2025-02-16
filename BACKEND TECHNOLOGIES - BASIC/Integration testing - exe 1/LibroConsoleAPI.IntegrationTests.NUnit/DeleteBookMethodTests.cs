using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using LibroConsoleAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.NUnit
{
    public class DeleteBookMethodTests
    {
        private TestLibroDbContext dbContext;
        private IBookManager bookManager;

        [SetUp]
        public void Setup()
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
        public async Task DeleteBookAsync_WithValidISBN_ShouldRemoveBookFromDb()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Samuel",
                Author = "Samuel",
                ISBN = "3434343434123",
                YearPublished = 1889,
                Genre = "Fiction",
                Pages = 599,
                Price = 55.99
            };
            await bookManager.AddAsync(newBook);
            var bookInDb = dbContext.Books.FirstOrDefault(x => x.ISBN == newBook.ISBN);
            Assert.AreEqual(newBook.Title, bookInDb.Title);

            // Act
            await bookManager.DeleteAsync(newBook.ISBN);

            // Assert
            var bookCheck = dbContext.Books.FirstOrDefault(x => x.ISBN == newBook.ISBN);
            Assert.Null(bookCheck);
            Assert.IsEmpty(dbContext.Books);
        }

        [Test]
        public async Task DeleteBookAsync_WithEmptyISBN_ShouldRemoveBookFromDb()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Samuel",
                Author = "Samuel",
                ISBN = "3434343434123",
                YearPublished = 1889,
                Genre = "Fiction",
                Pages = 599,
                Price = 55.99
            };
            await bookManager.AddAsync(newBook);
            var bookInDb = dbContext.Books.FirstOrDefault(x => x.ISBN == newBook.ISBN);
            Assert.AreEqual(newBook.Title, bookInDb.Title);

            // Act
            var ex = Assert.ThrowsAsync<ArgumentException>(() => bookManager.DeleteAsync(""));

            // Assert
            Assert.AreEqual("ISBN cannot be empty.", ex.Message);
            Assert.IsNotEmpty(dbContext.Books);
        }

        [Test]
        public async Task DeleteBookAsync_WithNullISBN_ShouldRemoveBookFromDb()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Samuel",
                Author = "Samuel",
                ISBN = "3434343434123",
                YearPublished = 1889,
                Genre = "Fiction",
                Pages = 599,
                Price = 55.99
            };
            await bookManager.AddAsync(newBook);
            var bookInDb = dbContext.Books.FirstOrDefault(x => x.ISBN == newBook.ISBN);
            Assert.AreEqual(newBook.Title, bookInDb.Title);

            // Act
            var ex = Assert.ThrowsAsync<ArgumentException>(() => bookManager.DeleteAsync(null));

            // Assert
            Assert.AreEqual("ISBN cannot be empty.", ex.Message);
            Assert.IsNotEmpty(dbContext.Books);
        }
    }
}
