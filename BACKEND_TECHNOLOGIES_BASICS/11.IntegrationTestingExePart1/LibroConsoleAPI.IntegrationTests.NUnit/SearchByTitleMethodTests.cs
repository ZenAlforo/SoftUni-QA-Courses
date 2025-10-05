using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using LibroConsoleAPI.DataAccess;
using LibroConsoleAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.NUnit
{
    public class SearchByTitleMethodTests
    {
        public LibroDbContext dbContext;
        public IBookManager bookManager;

        [SetUp]
        public void SetUp()
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
        public async Task SearchByTitleAsync_WithValidTitle_ShouldReturnBookFromDb()
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
            var bookInDb = await bookManager.SearchByTitleAsync(newBook.Title);

            // Assert
            Assert.IsNotNull(bookInDb);
            Assert.That(dbContext.Books.FirstOrDefault(b => b.ISBN == newBook.ISBN), Is.Not.Null);
        }

        [Test]
        public async Task SearchByTitleAsync_WithEmptyIsbn_ShouldThrowArgumentException()
        {
            // Arrange
            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(() => bookManager.SearchByTitleAsync("  "));
            Assert.That(ex.Message, Is.EqualTo("Title fragment cannot be empty."));
        }

        [Test]
        public async Task SearchByTitleAsync_WithEmptyIsbn_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            string titleToSearch = "MyBook";

            // Act & Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => bookManager.SearchByTitleAsync(titleToSearch));
            Assert.That(ex.Message, Is.EqualTo($"No books found with the given title fragment."));
        }
    }
}
