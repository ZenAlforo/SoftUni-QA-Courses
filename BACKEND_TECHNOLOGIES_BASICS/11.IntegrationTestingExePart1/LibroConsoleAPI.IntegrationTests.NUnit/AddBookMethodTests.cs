using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using LibroConsoleAPI.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.NUnit
{
    public class AddBookMethodTests
    {
        public TestLibroDbContext dbContext;
        public IBookManager bookManager;

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
        public async Task AddBookAsync_WithValidData_ShouldAddBook()
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

            // Act
            await bookManager.AddAsync(newBook);

            // Assert
            var bookInDb = await bookManager.GetSpecificAsync(newBook.ISBN);
            Assert.IsNotNull(bookInDb);
            Assert.That(bookInDb, Is.EqualTo(newBook));
        }

        [Test]
        public async Task AddBookAsync_WithInvalidISBN_ShouldThrowValidationException()
        {
            // Arrange
            Book newBook = new Book
            {
                ISBN = "123456789101",
                Title = "Title",
                Author = "Author",
                YearPublished = 1830,
                Genre = "fantasy",
                Pages = 650,
                Price = 10.99
            };

            // Act & Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => bookManager.AddAsync(newBook));
            Assert.That(ex.Message, Is.EqualTo("Book is invalid."));
            Assert.Null(dbContext.Books.FirstOrDefault(b => b.Title == newBook.Title));
            Assert.IsEmpty(dbContext.Books);
        }
    }
}
