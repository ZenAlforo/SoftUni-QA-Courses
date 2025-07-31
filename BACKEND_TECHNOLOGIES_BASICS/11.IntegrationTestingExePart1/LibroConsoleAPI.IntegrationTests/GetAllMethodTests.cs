using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class GetAllMethodTests : IClassFixture<BookManagerFixture>
    {
        private readonly BookManagerFixture _fixture;
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public GetAllMethodTests()
        {
            _fixture = new BookManagerFixture();
            _bookManager = _fixture.BookManager;
            _dbContext = _fixture.DbContext;
        }

        [Fact]
        public async Task GetAllAsync_TryToGetAllBooksWhenBooksExist_ShouldReturnAllBooks()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);

            // Act
            var result = await _bookManager.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(10, result.ToList().Count);
        }

        [Fact]
        public async Task GetAllAsync_TryToGetAllBooksWhenNoBooksExist_ShouldThrowKeyNotFoundException()
        {
            // Arrange

            // Act
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _bookManager.GetAllAsync());

            // Assert
            Assert.Equal(exception.Message, "No books found.");
            
        }
    }
}
