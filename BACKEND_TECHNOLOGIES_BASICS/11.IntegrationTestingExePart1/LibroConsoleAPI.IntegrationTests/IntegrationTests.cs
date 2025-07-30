using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using LibroConsoleAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibroConsoleAPI.IntegrationTests
{
    public class IntegrationTests : IClassFixture<BookManagerFixture>
    {
        private readonly BookManagerFixture _fixture;
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public IntegrationTests()
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

        [Fact]
        public async Task AddBookAsync_TryToAddBookWithInvalidTitle_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = new string('x', 260),
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

        [Fact]
        public async Task AddBookAsync_TryToAddBookWithInvalidAuthor_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "New Book",
                Author = new string('a', 120),
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

        [Fact]
        public async Task AddBookAsync_TryToAddBookWithInvalidISBN_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "New Book",
                Author = "Samuel",
                ISBN = "sadasda",
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

        [Fact]
        public async Task AddBookAsync_TryToAddBookWithInvalidYear_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "New Book",
                Author = "Samuel",
                ISBN = "1234567891012",
                YearPublished = -2000,
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

        [Fact]
        public async Task AddBookAsync_TryToAddBookWithInvalidGenre_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "New Book",
                Author = "Samuel",
                ISBN = "1234567891012",
                YearPublished = 2000,
                Genre = "",
                Pages = 100,
                Price = 19.99
            };

            // Act & Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));
            Assert.Equal("Book is invalid.", ex.Result.Message);
            var bookInDb = await _dbContext.Books.FirstOrDefaultAsync();
            Assert.Null(bookInDb);
        }

        [Fact]
        public async Task AddBookAsync_TryToAddBookWithInvalidPages_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "New Book",
                Author = "Samuel",
                ISBN = "1234567891012",
                YearPublished = 2000,
                Genre = "Fantasy",
                Pages = -50,
                Price = 19.99
            };

            // Act & Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));
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


        [Fact]
        public async Task DeleteBookAsync_TryToDeleteWithNullOrWhiteSpaceISBN_ShouldThrowException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);

            // Act
            var ex = Assert.ThrowsAsync<ArgumentException>(() => _bookManager.DeleteAsync(""));

            // Assert
            var booksInDb = _dbContext.Books.ToList();
            //Assert.Equal(ex.Result.Message, "ISBN cannot be empty.");
        }


        [Fact]
        public async Task GetAllAsync_WhenBooksExist_ShouldReturnAllBooks()
        {
            throw new NotImplementedException();
        }

         
        [Fact]
        public async Task GetAllAsync_WhenNoBooksExist_ShouldThrowKeyNotFoundException()
        {
            throw new NotImplementedException();
        }


        [Fact]
        public async Task SearchByTitleAsync_WithValidTitleFragment_ShouldReturnMatchingBooks()
        {
            throw new NotImplementedException();
        }


        [Fact]
        public async Task SearchByTitleAsync_WithInvalidTitleFragment_ShouldThrowKeyNotFoundException()
        {
            throw new NotImplementedException();
        }


        [Fact]
        public async Task GetSpecificAsync_WithValidIsbn_ShouldReturnBook()
        {
            throw new NotImplementedException();
        }


        [Fact]
        public async Task GetSpecificAsync_WithInvalidIsbn_ShouldThrowKeyNotFoundException()
        {
            throw new NotImplementedException();
        }


        [Fact]
        public async Task UpdateAsync_WithValidBook_ShouldUpdateBook()
        {
            throw new NotImplementedException();
        }


        [Fact]
        public async Task UpdateAsync_WithInvalidBook_ShouldThrowValidationException()
        {
            throw new NotImplementedException();
        }


    }
}
