using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace LibroConsoleAPI.IntegrationTests
{
    public class IntegrationTests : IClassFixture<BookManagerFixture>
    {
        private readonly BookManagerFixture _fixture;
        private readonly IBookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public IntegrationTests()
        {
            _fixture = new BookManagerFixture();
            _bookManager = _fixture.BookManager;
            _dbContext = _fixture.DbContext;
        }

        [Fact]
        public async Task AddBookAsync_ShouldAddBook()
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

            // Act
            await _bookManager.AddAsync(newBook);

            // Assert
            var bookInDb = await _dbContext.Books.FirstOrDefaultAsync(b => b.ISBN == newBook.ISBN);
            Assert.NotNull(bookInDb);
            Assert.Equal(newBook.Title, bookInDb.Title);
            Assert.Equal(newBook.Author, bookInDb.Author);
        }

        [Fact]
        public async Task AddBookAsync_TryToAddBookWithInvalidTitle_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = new string('a', 500),
                Author = "Samuel Pankov",
                ISBN = "1234567890124",
                YearPublished = 2023,
                Genre = "Fiction",
                Pages = 200,
                Price = 29.99
            };

            // Act
            var ex = Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));

            // Assert
            Assert.Equal("Book is invalid.", ex.Result.Message);
            var bookInDb = await _dbContext.Books.FirstOrDefaultAsync();
            Assert.Null(bookInDb);

        }

        [Fact]
        public async Task AddBookAsync_TryToAddBookWithInvalidISBN_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "My New book",
                Author = "Samuel Pankov",
                ISBN = "12345678901245",
                YearPublished = 2023,
                Genre = "Fiction",
                Pages = 200,
                Price = 29.99
            };

            // Act
            var ex = Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));

            // Assert
            Assert.Equal("Book is invalid.", ex.Result.Message);
            var bookInDb = await _dbContext.Books.FirstOrDefaultAsync();
            Assert.Null(bookInDb);

        }

        [Fact]
        public async Task AddBookAsync_TryToAddBookWithInvalidYear_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "New book",
                Author = "Samuel Pankov",
                ISBN = "1234567890123",
                YearPublished = 1111,
                Genre = "Fiction",
                Pages = 200,
                Price = 29.99
            };

            // Act
            var ex = Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));

            // Assert
            Assert.Equal("Book is invalid.", ex.Result.Message);
            var bookInDb = await _dbContext.Books.FirstOrDefaultAsync();
            Assert.Null(bookInDb);

        }

        [Fact]
        public async Task AddBookAsync_TryToAddBookWithInvalidPrice_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "New book",
                Author = "Samuel Pankov",
                ISBN = "1234567890123",
                YearPublished = 1885,
                Genre = "Fiction",
                Pages = 200,
                Price = 0.001
            };

            // Act
            var ex = Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));

            // Assert
            Assert.Equal("Book is invalid.", ex.Result.Message);
            var bookInDb = await _dbContext.Books.FirstOrDefaultAsync();
            Assert.Null(bookInDb);

        }



        [Fact]
        public async Task DeleteBookAsync_WithValidISBN_ShouldRemoveBookFromDb()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "New book",
                Author = "Samuel Pankov",
                ISBN = "1234567890000",
                YearPublished = 1885,
                Genre = "Fiction",
                Pages = 200,
                Price = 50
            };

            // Act
            await _bookManager.AddAsync(newBook);
            var bookInDb = await _dbContext.Books.FirstOrDefaultAsync((b) => b.ISBN == newBook.ISBN);
            Assert.Equal(bookInDb.ISBN, newBook.ISBN);
            
            await _bookManager.DeleteAsync(newBook.ISBN);
            var deletedBookInDb = await _dbContext.Books.FirstOrDefaultAsync((b) => b.ISBN == newBook.ISBN);
            Assert.Null(deletedBookInDb);
            // Assert
        }


        [Fact]
        public async Task DeleteBookAsync_TryToDeleteWithNullOrWhiteSpaceISBN_ShouldThrowException()
        {
            // Act
            var ex = Assert.ThrowsAsync<ArgumentException>(() =>  _bookManager.DeleteAsync(""));
            
            // Assert
            Assert.Equal("ISBN cannot be empty.", ex.Result.Message);
        }


        [Fact]
        public async Task GetAllAsync_WhenBooksExist_ShouldReturnAllBooks()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "New book",
                Author = "Samuel Pankov",
                ISBN = "1234567890000",
                YearPublished = 1885,
                Genre = "Fiction",
                Pages = 200,
                Price = 50
            };

            // Act
            await _bookManager.AddAsync(newBook);
            var books = await _bookManager.GetAllAsync();
             
            // Assert
            Assert.True(books.Any());
            Assert.Equal(newBook.Author, books.FirstOrDefault().Author);
        }


        [Fact]
        public async Task GetAllAsync_WhenNoBooksExist_ShouldThrowKeyNotFoundException()
        {
            // Act & Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(()=> _bookManager.GetAllAsync());
            Assert.Equal("No books found.", ex.Result.Message);
        }


        [Fact]
        public async Task SearchByTitleAsync_WithValidTitleFragment_ShouldReturnMatchingBooks()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "New book",
                Author = "Samuel Pankov",
                ISBN = "1234567890000",
                YearPublished = 1885,
                Genre = "Fiction",
                Pages = 200,
                Price = 50
            };

            // Act
            await _bookManager.AddAsync(newBook);
            var result = await _bookManager.SearchByTitleAsync(newBook.Title);

            // Assert
            Assert.True(result.Any());
            Assert.Equal(newBook.Author, result.FirstOrDefault().Author);
        }


        [Fact]
        public async Task SearchByTitleAsync_WithInvalidTitleFragment_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "New book",
                Author = "Samuel Pankov",
                ISBN = "1234567890000",
                YearPublished = 1885,
                Genre = "Fiction",
                Pages = 200,
                Price = 50
            };

            // Act
            await _bookManager.AddAsync(newBook);
            var ex = Assert.ThrowsAsync<KeyNotFoundException> (() => _bookManager.SearchByTitleAsync("My book"));

            // Assert
            Assert.Equal("No books found with the given title fragment.", ex.Result.Message);
        }


        [Fact]
        public async Task GetSpecificAsync_WithValidIsbn_ShouldReturnBook()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "You and me",
                Author = "Samuel Pankov",
                ISBN = "1234567891011",
                YearPublished = 1999,
                Genre = "Romance",
                Pages = 499,
                Price = 50.99
            };

            // Act
            await _bookManager.AddAsync(newBook);
            var result = await _bookManager.GetSpecificAsync(newBook.ISBN);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newBook.Title, result.Title);
        }


        [Fact]
        public async Task GetSpecificAsync_WithInvalidIsbn_ShouldThrowKeyNotFoundException()
        {
            // Act
            
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => _bookManager.GetSpecificAsync("124554545"));

            // Assert
            Assert.Equal("No book found with ISBN: 124554545", ex.Result.Message);
        }


        [Fact]
        public async Task UpdateAsync_WithValidBook_ShouldUpdateBook()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "You and me",
                Author = "Samuel Pankov",
                ISBN = "1234567891011",
                YearPublished = 1999,
                Genre = "Romance",
                Pages = 499,
                Price = 50.99
            };

            // Act
            await _bookManager.AddAsync(newBook);
            newBook.Title = "Me alone";
            await _bookManager.UpdateAsync(newBook);

            // Assert
            var book = await _bookManager.GetAllAsync();
            Assert.Single(book);
            Assert.Equal(newBook.Title, book.FirstOrDefault((b) => b.ISBN == newBook.ISBN).Title);
        }


        [Fact]
        public async Task UpdateAsync_WithInvalidBook_ShouldThrowValidationException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "You and me",
                Author = "Samuel Pankov",
                ISBN = "1234567891011",
                YearPublished = 1999,
                Genre = "Romance",
                Pages = 499,
                Price = 50.99
            };

            // Act
            await _bookManager.AddAsync(newBook);
            newBook.Title = "";
            var ex = Assert.ThrowsAsync<ValidationException> (()=> _bookManager.UpdateAsync(newBook));

            // Assert

            Assert.Equal("Book is invalid.", ex.Result.Message);    
        }


    }
}
