using LibroConsoleAPI.Business;
using LibroConsoleAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class SearchByTitleMethodTests : IClassFixture<BookManagerFixture>
    {
        private readonly BookManagerFixture _fixture;
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public SearchByTitleMethodTests()
        {
            _fixture = new BookManagerFixture();
            _bookManager = _fixture.BookManager;
            _dbContext = _fixture.DbContext;
        }

        [Fact]
        public async Task SearchByTitleAsync_WithValidTitleFragment_ShouldReturnMatchingBooks()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);

            // Act 
            var matchingBooks = await _bookManager.SearchByTitleAsync("and");

            // Assert
            Assert.NotNull(matchingBooks);
            Assert.Equal(3, matchingBooks.Count());
            Assert.Equal("Pride and Prejudice", matchingBooks.FirstOrDefault().Title);
        }

        [Fact]
        public async Task SearchByTitleAsync_WithNotExistingTitleFragment_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);

            // Act 
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => _bookManager.SearchByTitleAsync("Plane"));

            // Assert
            Assert.Equal("No books found with the given title fragment.", ex.Result.Message);
        }

        [Fact]
        public async Task SearchByTitleAsync_WithEmptyTitleFragment_ShouldThrowArgumentException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);

            // Act 
            var ex = Assert.ThrowsAsync<ArgumentException>(() => _bookManager.SearchByTitleAsync(""));

            // Assert
            Assert.Equal("Title fragment cannot be empty.", ex.Result.Message);
        }

        [Fact]
        public async Task SearchByTitleAsync_WithNullTitleFragment_ShouldThrowArgumentException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);

            // Act 
            var ex = Assert.ThrowsAsync<ArgumentException>(() => _bookManager.SearchByTitleAsync(null));

            // Assert
            Assert.Equal("Title fragment cannot be empty.", ex.Result.Message);
        }
    }
}
