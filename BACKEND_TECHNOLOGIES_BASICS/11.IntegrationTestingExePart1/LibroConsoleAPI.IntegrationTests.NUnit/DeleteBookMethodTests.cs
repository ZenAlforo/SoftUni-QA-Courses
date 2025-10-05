using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using LibroConsoleAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.NUnit
{
    public class DeleteBookMethodTests
    {
        public TestLibroDbContext dbContext;
        public IBookManager bookManager;

        [SetUp]
        public void SetUp()
        {
            string dbName = $"TestDb_{Guid.NewGuid()}";
            dbContext = new TestLibroDbContext(dbName);
            bookManager = new BookManager(new BookRepository(dbContext));
        }

        [TearDown]
        public void TearDown()
        {
            this.dbContext.Dispose();
        }

        [Test]
        public async Task DeleteBook_WithValidIsbn_ShouldRemoveBookFromDb()
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

            await bookManager.AddAsync(newBook);
            Assert.That(dbContext.Books.Count, Is.EqualTo(1));
            Assert.That(dbContext.Books.FirstOrDefault(b => b.Title == newBook.Title), Is.Not.Null);

            // Act
            await bookManager.DeleteAsync(newBook.ISBN);

            // Assert
            Assert.That(dbContext.Books.Count, Is.EqualTo(0));
            Assert.That(dbContext.Books.FirstOrDefault(b => b.Title == newBook.Title), Is.Null);
        }

        [Test]
        public async Task DeleteBook_WithInValidIsbn_ShouldThrowArgumentException()
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

            await bookManager.AddAsync(newBook);
            Assert.That(dbContext.Books.Count, Is.EqualTo(1));
            Assert.That(dbContext.Books.FirstOrDefault(b => b.Title == newBook.Title), Is.Not.Null);

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(() => bookManager.DeleteAsync(""));
            Console.WriteLine(ex.Message);
            Assert.That(ex.Message, Is.EqualTo("ISBN cannot be empty."));
            Assert.That(dbContext.Books.Count, Is.EqualTo(1));
        }
    }
}
