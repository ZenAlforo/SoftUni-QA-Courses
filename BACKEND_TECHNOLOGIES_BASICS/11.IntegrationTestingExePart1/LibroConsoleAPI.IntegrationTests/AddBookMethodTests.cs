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
    public class AddBookMethodTests : IClassFixture<BookManagerFixture>
    {
        private readonly BookManagerFixture _fixture;
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public AddBookMethodTests()
        {
            _fixture = new BookManagerFixture();
            _bookManager = _fixture.BookManager;
            _dbContext = _fixture.DbContext;
        }

        [Fact]
        public async Task AddBookAsync_WithValidData_ShouldAddBook()
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
            Assert.Equal("Test Book", bookInDb.Title);
            Assert.Equal("John Doe", bookInDb.Author);
        }

       
        [Theory]
        [InlineData(null)]
        [InlineData("51651511515151515151515151516515165165165165165165165651651651651561651651651651516516516515616516516515616516516515615615615615165165165516516516516516516516516516515615156151561651561561651651515616515616515616515616515165165165165165156165156165156156156165156151515165156165165151651")]
        [InlineData("")]

        public async Task AddBookAsync_TryToAddBookWithInvalidTitle_ShouldThrowException(string title)
        {
            // Arrange
            var newBook = new Book
            {
                Title = title,
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };

            // Act & Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));
            Assert.Equal("Book is invalid.", ex.Result.Message);
            var bookInDb = await _dbContext.Books.FirstOrDefaultAsync();
            Assert.Null(bookInDb);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("51651511515151515151515151516515165165165165165165165651651651651561651651651651516516516515616516516515616516516515615615615615165165165516516516516516516516516516515615156151561651561561651651515616515616515616515616515165165165165165156165156165156156156165156151515165156165165151651")]
        [InlineData("")]
        public async Task AddBookAsync_TryToAddBookWithInvalidAuthor_ShouldThrowException(string author)
        {
            // Arrange
            var newBook = new Book
            {
                Title = "New Book",
                Author = author,
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };

            // Act & Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));
            Assert.Equal("Book is invalid.", ex.Result.Message);
            var bookInDb = await _dbContext.Books.FirstOrDefaultAsync();
            Assert.Null(bookInDb);

        }

        [Theory]
        [InlineData(null)]
        [InlineData("51651511515151515151515151511")]
        [InlineData("")]
        public async Task AddBookAsync_TryToAddBookWithInvalidISBN_ShouldThrowException(string isbn)
        {
            // Arrange
            var newBook = new Book
            {
                Title = "New Book",
                Author = "Samuel",
                ISBN = isbn,
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };

            // Act & Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));
            Assert.Equal("Book is invalid.", ex.Result.Message);
            var bookInDb = await _dbContext.Books.FirstOrDefaultAsync();
            Assert.Null(bookInDb);
        }

        [Theory]
        [InlineData(-2000)]
        [InlineData(1655)]
        [InlineData(2025)]
        //[InlineData(2002.29)]
        public async Task AddBookAsync_TryToAddBookWithInvalidYear_ShouldThrowException(int year)
        {
            // Arrange
            var newBook = new Book
            {
                Title = "New Book",
                Author = "Samuel",
                ISBN = "1234567891012",
                YearPublished = year,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };

            // Act & Assert
            var ex = await Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));
            Assert.Equal("Book is invalid.", ex.Message);
            var bookInDb = await _dbContext.Books.FirstOrDefaultAsync();
            Assert.Null(bookInDb);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("adsadsadjajdadahdjlsahdjsahdhadhahdadahsjdsajhdjahdahldahdajhdjadjahdaha")]

        public async Task AddBookAsync_TryToAddBookWithInvalidGenre_ShouldThrowException(string genre)
        {
            // Arrange
            var newBook = new Book
            {
                Title = "New Book",
                Author = "Samuel",
                ISBN = "1234567891012",
                YearPublished = 2000,
                Genre = genre,
                Pages = 100,
                Price = 19.99
            };

            // Act & Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));
            Assert.Equal("Book is invalid.", ex.Result.Message);
            var bookInDb = await _dbContext.Books.FirstOrDefaultAsync();
            Assert.Null(bookInDb);
        }

        [Theory]
        [InlineData(-20)]
        [InlineData(0)]
        public async Task AddBookAsync_TryToAddBookWithInvalidPages_ShouldThrowException(int pages)
        {
            // Arrange
            var newBook = new Book
            {
                Title = "New Book",
                Author = "Samuel",
                ISBN = "1234567891012",
                YearPublished = 2000,
                Genre = "Fantasy",
                Pages = pages,
                Price = 19.99
            };

            // Act & Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));
            Assert.Equal("Book is invalid.", ex.Result.Message);
            var bookInDb = await _dbContext.Books.FirstOrDefaultAsync();
            Assert.Null(bookInDb);
        }

        [Theory]
        [InlineData(-20.5)]
        [InlineData(1500)]
        [InlineData(0)]
        [InlineData(2002.29)]
        public async Task AddBookAsync_TryToAddBookWithInvalidPrice_ShouldThrowException(double price)
        {
            // Arrange
            var newBook = new Book
            {
                Title = "New Book",
                Author = "Samuel",
                ISBN = "1234567891012",
                YearPublished = 2000,
                Genre = "Fantasy",
                Pages = 100,
                Price = -200
            };

            // Act & Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));
            Assert.Equal("Book is invalid.", ex.Result.Message);
            var bookInDb = await _dbContext.Books.FirstOrDefaultAsync();
            Assert.Null(bookInDb);
        }
    }
}
