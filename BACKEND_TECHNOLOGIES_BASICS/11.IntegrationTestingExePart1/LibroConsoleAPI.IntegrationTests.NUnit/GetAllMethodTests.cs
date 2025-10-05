using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.DataAccess;
using LibroConsoleAPI.DataAccess.Contracts;
using LibroConsoleAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.NUnit
{
    public class GetAllMethodTests
    {
        public LibroDbContext dbContext;
        public BookManager bookManager;

        [SetUp]
        public void SetUp()
        {
            string dbName = $"myDb_{Guid.NewGuid()}";
            dbContext = new TestLibroDbContext(dbName);
            bookManager = new BookManager(new BookRepository(dbContext));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllBooks()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(dbContext, bookManager);

            // Act
            var result = await bookManager.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count, Is.EqualTo(10));
        }

        [Test]
        public async Task GetAllAsync_WhenNoBooksInDb_ShouldThrowKeyNotFoundException()
        {
            // Arrange

            // Act

            // Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(async () => await bookManager.GetAllAsync());
            Assert.That(ex.Message, Is.EqualTo("No books found."));
            Assert.That(dbContext.Books, Is.Empty);

        }
    }
}
