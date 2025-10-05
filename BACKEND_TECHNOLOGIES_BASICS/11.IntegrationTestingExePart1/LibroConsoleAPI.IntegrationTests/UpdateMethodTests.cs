using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class UpdateMethodTests : IClassFixture<BookManagerFixture>
    {
        private readonly BookManagerFixture _fixture;
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public UpdateMethodTests()
        {
            _fixture = new BookManagerFixture();
            _bookManager = _fixture.BookManager;
            _dbContext = _fixture.DbContext;
        }

        [Fact]
        public async Task UpdateAsync_WithValidBook_ShouldUpdateBookInDb()
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
            string updatedTitle = "UpdatedTitle";
            double updatedPrice = 15.00;
            newBook.Title = updatedTitle;
            newBook.Price = updatedPrice;


            // Act
            await _bookManager.UpdateAsync(newBook);

            // Assert

            var bookInDb = await _bookManager.GetSpecificAsync(newBook.ISBN);
            Assert.Single(_dbContext.Books);
            Assert.NotNull(bookInDb);
            Assert.Equal(bookInDb.Title, updatedTitle);
            Assert.Equal(bookInDb.Price, updatedPrice);
        }

        [Fact]
        public async Task UpdateAsync_WithInValidBook_ShouldThrowValidationException()
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
            string updatedIsbn = "123456";
            double updatedPrice = 15.00;
            newBook.ISBN = updatedIsbn;
            newBook.Price = updatedPrice;

            // Act & Assert
            var ex = await Assert.ThrowsAsync<ValidationException>(() => _bookManager.UpdateAsync(newBook));
            Assert.Equal(ex.Message, "Book is invalid.");

        }
    }
    
}
