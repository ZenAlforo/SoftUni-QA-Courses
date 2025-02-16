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
    public class GetSpecificBookMethodTests
    {
        private TestLibroDbContext dbContext;
        private BookManager bookManager;

        [SetUp]
        public void SetUp()
        {
            string dbName = $"TestDb_{Guid.NewGuid()}";
            this.dbContext = new TestLibroDbContext();
            this.bookManager = new BookManager(new BookRepository(this.dbContext));
        }

        [Test]
        public async Task GetSpecificAsync_WithValidIsbn_ShouldReturnBook()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(dbContext, bookManager);

            // Act
            var result = await bookManager.GetSpecificAsync("9780140449276");

            // Assert
            Assert.AreEqual("War and Peace", result.Title);
        }


        [Test]
        public async Task GetSpecificAsync_WithNotExistingIsbn_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(dbContext, bookManager);
            var isbn = "9780140449444";

            // Act
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => bookManager.GetSpecificAsync(isbn));

            // Assert
            Assert.AreEqual($"No book found with ISBN: {isbn}", ex.Message);
        }

        [Test]
        public async Task GetSpecificAsync_WithLettersIsbn_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(dbContext, bookManager);
            var isbn = "abcdefffffffa";

            // Act
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => bookManager.GetSpecificAsync(isbn));

            // Assert
            Assert.AreEqual($"No book found with ISBN: {isbn}", ex.Message);
        }

        [Test]
        public async Task GetSpecificAsync_WithLongerIsbn_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(dbContext, bookManager);
            var isbn = "123456456456456";

            // Act
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => bookManager.GetSpecificAsync(isbn));

            // Assert
            Assert.AreEqual($"No book found with ISBN: {isbn}", ex.Message);
        }

        [Test]
        public async Task GetSpecificAsync_WithShorterIsbn_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(dbContext, bookManager);
            var isbn = "123";

            // Act
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => bookManager.GetSpecificAsync(isbn));

            // Assert
            Assert.AreEqual($"No book found with ISBN: {isbn}", ex.Message);
        }

        [Test]
        public async Task GetSpecificAsync_WithEmptyIsbn_ShouldThrowArgumentException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(dbContext, bookManager);
            var isbn = "";

            // Act
            var ex = Assert.ThrowsAsync<ArgumentException>(() => bookManager.GetSpecificAsync(isbn));

            // Assert
            Assert.AreEqual("ISBN cannot be empty.", ex.Message);
        }


        [Test]
        public async Task GetSpecificAsync_WithNullIsbn_ShouldThrowKeyArgumentException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(dbContext, bookManager);

            // Act
            var ex = Assert.ThrowsAsync<ArgumentException>(() => bookManager.GetSpecificAsync(null));

            // Assert
            Assert.AreEqual("ISBN cannot be empty.", ex.Message);
        }
    }
}
