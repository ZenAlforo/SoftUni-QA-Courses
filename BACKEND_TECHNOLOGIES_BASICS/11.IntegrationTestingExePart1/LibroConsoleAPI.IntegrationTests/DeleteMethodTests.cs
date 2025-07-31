using LibroConsoleAPI.Business;
using LibroConsoleAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class DeleteMethodTests : IClassFixture<BookManagerFixture>
    {
        private readonly BookManagerFixture _fixture;
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public DeleteMethodTests()
        {
            _fixture = new BookManagerFixture();
            _bookManager = _fixture.BookManager;
            _dbContext = _fixture.DbContext;
        }

        [Fact]
        public async Task DeleteBookAsync_WithValidISBN_ShouldRemoveBookFromDb()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);

            // Act
            await _bookManager.DeleteAsync("9780385487256");

            // Assert
            var booksInDb = _dbContext.Books.ToList();
            Assert.Equal(booksInDb.Count, 9);
            Assert.False(booksInDb.Any(b => b.ISBN == "9780385487256"));
        }


        [Theory]
    
        [InlineData("")]
        [InlineData(null)]
        [InlineData("     ")]

        public async Task DeleteBookAsync_TryToDeleteWithNullOrWhiteSpaceISBN_ShouldThrowException(string isbn)
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);

            // Act
            var ex = Assert.ThrowsAsync<ArgumentException>(() => _bookManager.DeleteAsync(isbn));

            // Assert
            var booksInDb = _dbContext.Books.ToList();
            Assert.Equal(ex.Result.Message, "ISBN cannot be empty.");
        }
    }
}
