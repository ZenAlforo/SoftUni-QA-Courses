using LibroConsoleAPI.Business;
using LibroConsoleAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class UpdateBookMethodTests : IClassFixture<BookManagerFixture>
    {
        private readonly BookManagerFixture _fixture;
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public UpdateBookMethodTests()
        {
            _fixture = new BookManagerFixture();
            _bookManager = _fixture.BookManager;
            _dbContext = _fixture.DbContext;
        }

        [Fact]
        public async Task UpdateAsync_WithValidBook_ShouldUpdateBook()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test Book",
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };
            await _bookManager.AddAsync(newBook);
            string newTitle = "Test Book Updated";
            newBook.Title = newTitle;

            // Act
            await _bookManager.UpdateAsync(newBook);

            // Assert
            Assert.Equal(newTitle, (await _bookManager.GetSpecificAsync(newBook.ISBN)).Title);
        }

        [Fact]
        public async Task UpdateAsync_WithInvalidBook_ShouldThrowValidationException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test Book",
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };
            await _bookManager.AddAsync(newBook);
            double newPrice = 0;
            newBook.Price = newPrice;

            // Act
            var ex = Assert.ThrowsAsync<ValidationException> (() => _bookManager.UpdateAsync(newBook));

            // Assert
            Assert.Equal("Book is invalid.", ex.Result.Message);
        }
    }
}
