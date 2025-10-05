using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
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

            await _bookManager.AddAsync(newBook);

            // Act
            var bookInDb = await _bookManager.SearchByTitleAsync(newBook.Title);

            // Assert
            Assert.NotNull(bookInDb);
            Assert.NotNull(_dbContext.Books.FirstOrDefault(b => b.ISBN == newBook.ISBN));
        }

        [Fact]
        public async Task SearchByTitleAsync_WithEmptyIsbn_ShouldThrowArgumentException()
        {
            // Arrange
            // Act & Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _bookManager.SearchByTitleAsync("  "));
            Assert.Equal(ex.Message, "Title fragment cannot be empty.");
        }

        [Fact]
        public async Task SearchByTitleAsync_WithEmptyIsbn_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            string titleToSearch = "MyBook";

            // Act & Assert
            var ex = await Assert.ThrowsAsync<KeyNotFoundException>(() => _bookManager.SearchByTitleAsync(titleToSearch));
            Assert.Equal(ex.Message, $"No books found with the given title fragment.");
        }
    }


}
