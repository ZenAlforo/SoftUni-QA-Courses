using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class DeleteBookMethod : IClassFixture<BookManagerFixture>
    {
        private readonly BookManagerFixture _fixture;
        private readonly IBookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public DeleteBookMethod()
        {
            _fixture = new BookManagerFixture();
            _bookManager = _fixture.BookManager;
            _dbContext = _fixture.DbContext;
        }

        [Fact]
        public async Task DeleteBookAsync_WithValidISBN_ShouldRemoveBookFromDb()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Samuel",
                Author = "Samuel",
                ISBN = "3434343434123",
                YearPublished = 1889,
                Genre = "Fiction",
                Pages = 599,
                Price = 55.99
            };
            await _bookManager.AddAsync(newBook);
            var bookInDb = _dbContext.Books.FirstOrDefault(x => x.ISBN == newBook.ISBN);
            Assert.Equal(newBook.Title, bookInDb.Title);

            // Act
            await _bookManager.DeleteAsync(newBook.ISBN);

            // Assert
            var bookCheck = _dbContext.Books.FirstOrDefault(x => x.ISBN == newBook.ISBN);
            Assert.Null(bookCheck);
            Assert.Empty(_dbContext.Books);
        }

        [Fact]
        public async Task DeleteBookAsync_WithEmptyISBN_ShouldRemoveBookFromDb()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Samuel",
                Author = "Samuel",
                ISBN = "3434343434123",
                YearPublished = 1889,
                Genre = "Fiction",
                Pages = 599,
                Price = 55.99
            };
            await _bookManager.AddAsync(newBook);
            var bookInDb = _dbContext.Books.FirstOrDefault(x => x.ISBN == newBook.ISBN);
            Assert.Equal(newBook.Title, bookInDb.Title);

            // Act
            var ex = Assert.ThrowsAsync<ArgumentException> (() => _bookManager.DeleteAsync(""));

            // Assert
            Assert.Equal("ISBN cannot be empty.", ex.Result.Message);
            Assert.NotEmpty(_dbContext.Books);
        }

        [Fact]
        public async Task DeleteBookAsync_WithNullISBN_ShouldRemoveBookFromDb()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Samuel",
                Author = "Samuel",
                ISBN = "3434343434123",
                YearPublished = 1889,
                Genre = "Fiction",
                Pages = 599,
                Price = 55.99
            };
            await _bookManager.AddAsync(newBook);
            var bookInDb = _dbContext.Books.FirstOrDefault(x => x.ISBN == newBook.ISBN);
            Assert.Equal(newBook.Title, bookInDb.Title);

            // Act
            var ex = Assert.ThrowsAsync<ArgumentException>(() => _bookManager.DeleteAsync(null));

            // Assert
            Assert.Equal("ISBN cannot be empty.", ex.Result.Message);
            Assert.NotEmpty(_dbContext.Books);
        }
    }
}
