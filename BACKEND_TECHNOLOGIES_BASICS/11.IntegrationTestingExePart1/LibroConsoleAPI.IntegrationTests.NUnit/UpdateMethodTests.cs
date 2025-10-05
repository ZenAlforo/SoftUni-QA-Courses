using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using LibroConsoleAPI.DataAccess;
using LibroConsoleAPI.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.NUnit
{
    public class UpdateMethodTests
    {
        public LibroDbContext dbContext;
        public IBookManager bookManager;

        [SetUp] 
        public void SetUp()
        {
            string dbName = Guid.NewGuid().ToString();
            dbContext = new TestLibroDbContext(dbName);
            bookManager = new BookManager(new BookRepository(dbContext));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        [Test]
        public async Task UpdateAsync_WithValidBook_ShouldUpdateBook()
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

            await bookManager.AddAsync(newBook);
            string updatedTitle = "UpdatedTitle";
            double updatedPrice = 15.00;
            newBook.Title = updatedTitle;
            newBook.Price = updatedPrice;
            

            // Act
            await bookManager.UpdateAsync(newBook);

            // Assert

            var bookInDb = await bookManager.GetSpecificAsync(newBook.ISBN);
            Assert.That(dbContext.Books.Count, Is.EqualTo(1));
            Assert.IsNotNull(bookInDb);
            Assert.That(bookInDb.Title, Is.EqualTo(updatedTitle));
            Assert.That(bookInDb.Price, Is.EqualTo(updatedPrice));
        }

        [Test]
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

            await bookManager.AddAsync(newBook);
            string updatedIsbn = "123456";
            double updatedPrice = 15.00;
            newBook.ISBN = updatedIsbn;
            newBook.Price = updatedPrice;

            // Act & Assert
            var ex = Assert.ThrowsAsync<ValidationException> (() => bookManager.UpdateAsync(newBook));
            Assert.That(ex.Message, Is.EqualTo("Book is invalid."));
            
        }
    }
}
