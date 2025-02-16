using LibroConsoleAPI.Business;
using LibroConsoleAPI.DataAccess;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class GetSpecificBookMethodTests : IClassFixture<BookManagerFixture>
    {
        private readonly BookManagerFixture _fixture;
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public GetSpecificBookMethodTests()
        {
            _fixture = new BookManagerFixture();
            _bookManager = _fixture.BookManager;
            _dbContext = _fixture.DbContext;
        }

        [Fact]
        public async Task GetSpecificAsync_WithValidIsbn_ShouldReturnBook()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);

            // Act
            var result = await _bookManager.GetSpecificAsync("9780140449276");

            // Assert
            Assert.Equal("War and Peace", result.Title);
        }


        [Fact]
        public async Task GetSpecificAsync_WithNotExistingIsbn_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);
            var isbn = "9780140449444";

            // Act
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => _bookManager.GetSpecificAsync(isbn));

            // Assert
            Assert.Equal($"No book found with ISBN: {isbn}", ex.Result.Message);
        }

        [Fact]
        public async Task GetSpecificAsync_WithLettersIsbn_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);
            var isbn = "abcdefffffffa";

            // Act
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(()=> _bookManager.GetSpecificAsync(isbn));

            // Assert
            Assert.Equal($"No book found with ISBN: {isbn}", ex.Result.Message);
        }

        [Fact]
        public async Task GetSpecificAsync_WithLongerIsbn_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);
            var isbn = "123456456456456";

            // Act
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => _bookManager.GetSpecificAsync(isbn));

            // Assert
            Assert.Equal($"No book found with ISBN: {isbn}", ex.Result.Message);
        }

        [Fact]
        public async Task GetSpecificAsync_WithShorterIsbn_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);
            var isbn = "123";

            // Act
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => _bookManager.GetSpecificAsync(isbn));

            // Assert
            Assert.Equal($"No book found with ISBN: {isbn}", ex.Result.Message);
        }

        [Fact]
        public async Task GetSpecificAsync_WithEmptyIsbn_ShouldThrowArgumentException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);
            var isbn = "";

            // Act
            var ex = Assert.ThrowsAsync<ArgumentException>(() => _bookManager.GetSpecificAsync(isbn));

            // Assert
            Assert.Equal("ISBN cannot be empty.", ex.Result.Message);
        }


        [Fact]
        public async Task GetSpecificAsync_WithNullIsbn_ShouldThrowKeyArgumentException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);

            // Act
            var ex = Assert.ThrowsAsync<ArgumentException>(() => _bookManager.GetSpecificAsync(null));

            // Assert
            Assert.Equal("ISBN cannot be empty.", ex.Result.Message);
        }
    }
}
