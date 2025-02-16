using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.DataAccess;
using LibroConsoleAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.NUnit
{
    public class SearchByTitleMethodTests
    {
        private TestLibroDbContext dbContext;
        private BookManager bookManager;

        [SetUp]
        public void SetUp()
        {
            string dbName = $"TestDb_{Guid.NewGuid()}";
            this.dbContext = new TestLibroDbContext(dbName);
            this.bookManager = new BookManager(new BookRepository(this.dbContext));
        }

        [Test]
        public async Task SearchByTitleAsync_WithValidTitleFragment_ShouldReturnMatchingBooks()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(dbContext, bookManager);

            // Act 
            var matchingBooks = await bookManager.SearchByTitleAsync("and");

            // Assert
            Assert.NotNull(matchingBooks);
            Assert.AreEqual(3, matchingBooks.Count());
            Assert.AreEqual("Pride and Prejudice", matchingBooks.FirstOrDefault().Title);
        }

        [Test]
        public async Task SearchByTitleAsync_WithNotExistingTitleFragment_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(dbContext, bookManager);

            // Act 
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => bookManager.SearchByTitleAsync("Plane"));

            // Assert
            Assert.AreEqual("No books found with the given title fragment.", ex.Message);
        }

        [Test]
        public async Task SearchByTitleAsync_WithEmptyTitleFragment_ShouldThrowArgumentException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(dbContext, bookManager);

            // Act 
            var ex = Assert.ThrowsAsync<ArgumentException>(() => bookManager.SearchByTitleAsync(""));

            // Assert
            Assert.AreEqual("Title fragment cannot be empty.", ex.Message);
        }

        [Test]
        public async Task SearchByTitleAsync_WithNullTitleFragment_ShouldThrowArgumentException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(dbContext, bookManager);

            // Act 
            var ex = Assert.ThrowsAsync<ArgumentException>(() => bookManager.SearchByTitleAsync(null));

            // Assert
            Assert.AreEqual("Title fragment cannot be empty.", ex.Message);
        }
    }
}
