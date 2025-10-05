using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class GetSpecificMethodTests : IClassFixture<BookManagerFixture>
    {
        private readonly BookManagerFixture _fixture;
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public GetSpecificMethodTests()
        {
            _fixture = new BookManagerFixture();
            _bookManager = _fixture.BookManager;
            _dbContext = _fixture.DbContext;
        }

        [Fact]
        public async Task GetSpecificAsync_WithValidTitle_ShouldReturnMovieFromDb()
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
            var bookInDb = await _bookManager.GetSpecificAsync(newBook.ISBN);

            // Assert
            Assert.NotNull(bookInDb);
            Assert.Equal(bookInDb, newBook);
        }
        [Fact]
        public async Task GetSpecificAsync_WithEmptyIsbn_ShouldThrowArgumentException()
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

            // Act & Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _bookManager.GetSpecificAsync("  "));
            Assert.Equal(ex.Message, "ISBN cannot be empty.");
        }

        [Fact]
        public async Task GetSpecificAsync_WithNonExistingIsbn_ShouldThrowKeyNotFoundException()
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
            string isbnToSearch = "1212121212123";

            // Act & Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => _bookManager.GetSpecificAsync(isbnToSearch));
            Assert.Equal(ex.Result.Message, $"No book found with ISBN: {isbnToSearch}");
        }
    }
}
