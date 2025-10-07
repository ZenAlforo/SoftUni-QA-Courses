using MongoDB.Driver;
using MoviesLibraryAPI.Controllers;
using MoviesLibraryAPI.Controllers.Contracts;
using MoviesLibraryAPI.Data.Models;
using MoviesLibraryAPI.Services;
using MoviesLibraryAPI.Services.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesLibraryAPI.XUnitTests
{
    public class XUnitIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly MoviesLibraryXUnitTestDbContext _dbContext;
        private readonly IMoviesLibraryController _controller;
        private readonly IMoviesRepository _repository;

        public XUnitIntegrationTests(DatabaseFixture fixture)
        {
            _dbContext = fixture.DbContext;
            _repository = new MoviesRepository(_dbContext.Movies);
            _controller = new MoviesLibraryController(_repository);

            InitializeDatabaseAsync().GetAwaiter().GetResult();
        }

        private async Task InitializeDatabaseAsync()
        {
            await _dbContext.ClearDatabaseAsync();
        }

        [Fact]
        public async Task AddMovieAsync_WhenValidMovieProvided_ShouldAddToDatabase()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie1",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 120,
                Rating = 7.5
            };

            // Act
            await _controller.AddAsync(movie);

            // Assert
            var resultMovie = await _dbContext.Movies.Find(m => m.Title == movie.Title).FirstOrDefaultAsync();
            Assert.NotNull(resultMovie);
            Assert.Equal(movie.Title, resultMovie.Title);
            Assert.Equal(movie.Director, resultMovie.Director);
            Assert.Equal(2022, resultMovie.YearReleased);
            Assert.Equal(movie.Genre, resultMovie.Genre);
            Assert.Equal(120, resultMovie.Duration);
            Assert.Equal(7.5, resultMovie.Rating);
        }

        [Fact]
        public async Task AddMovieAsync_WhenInvalidMovieProvided_ShouldThrowValidationException()
        {
            // Arrange
            var invalidMovie = new Movie
            {
                Title = "New Movie", 
                Director = "Me Myself", 
                YearReleased = 1200, 
                Genre = "Fantasy",
                Duration = 1999,
                Rating = 12.00
            };

            // Act and Assert
            try
            {
                await _controller.AddAsync(invalidMovie);
                Assert.Fail("Expected exception was not thrown");
            }
            catch (ValidationException ex)
            {
                Assert.Equal("Movie is not valid.", ex.Message);
                Assert.Equal(0, await _dbContext.Movies.CountDocumentsAsync(x => true));
            }
        }

        [Fact]
        public async Task DeleteAsync_WhenValidTitleProvided_ShouldDeleteMovie()
        {
            // Arrange
            Movie testMovie = new Movie
            {
                Title = "He himself",
                Director = "Me myself",
                YearReleased = 1991,
                Genre = "Drama",
                Duration = 34,
                Rating = 8.5
            };

            await _controller.AddAsync(testMovie);

            // Act            
            await _controller.DeleteAsync(testMovie.Title);

            // Assert
            var count = await _dbContext.Movies.CountDocumentsAsync(x => true);
            Assert.Equal(0, count);
            var movieCursor = await _dbContext.Movies.FindAsync(x => x.Title == testMovie.Title);
            var movies = await movieCursor.ToListAsync();
            Assert.Empty(movies);
        }


        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public async Task DeleteAsync_WhenTitleIsNull_ShouldThrowArgumentException(string title)
        {
            // Act and Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _controller.DeleteAsync(title));
            Assert.Equal("Title cannot be empty.", ex.Message);
        }

        [Fact]
        public async Task DeleteAsync_WhenTitleDoesNotExist_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var title = "Some title";

            // Act and Assert
            var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => _controller.DeleteAsync(title));
            Assert.Equal($"Movie with title '{title}' not found.", ex.Message);
        }

        [Fact]
        public async Task GetAllAsync_WhenNoMoviesExist_ShouldReturnEmptyList()
        {
            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            Assert.Empty(result);
            Assert.Equal(0, result.Count());
        }

        [Fact]
        public async Task GetAllAsync_WhenMoviesExist_ShouldReturnAllMovies()
        {
            // Arrange
            Movie testMovie1 = new Movie
            {
                Title = "He himself",
                Director = "Me myself",
                YearReleased = 1991,
                Genre = "Drama",
                Duration = 34,
                Rating = 8.5
            };

            Movie testMovie2 = new Movie
            {
                Title = "Her life",
                Director = "My friend",
                YearReleased = 1998,
                Genre = "Drama",
                Duration = 122,
                Rating = 5.8
            };

            await _controller.AddAsync(testMovie1);
            await _controller.AddAsync(testMovie2);

            // Act

            var result = await _controller.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(result, movie => movie.Title == "He himself" && movie.Director == "Me myself");
            Assert.Contains(result, movie => movie.Title == "Her life" && movie.Rating == 5.8);
        }

        [Fact]
        public async Task GetByTitle_WhenTitleExists_ShouldReturnMatchingMovie()
        {
            // Arrange
            Movie testMovie1 = new Movie
            {
                Title = "He himself",
                Director = "Me myself",
                YearReleased = 1991,
                Genre = "Drama",
                Duration = 34,
                Rating = 8.5
            };

            Movie testMovie2 = new Movie
            {
                Title = "Her life",
                Director = "My friend",
                YearReleased = 1998,
                Genre = "Drama",
                Duration = 122,
                Rating = 5.8
            };

            await _controller.AddAsync(testMovie1);
            await _controller.AddAsync(testMovie2);

            // Act

            var result = await _controller.GetByTitle(testMovie1.Title);

            // Assert
            Assert.Equal(testMovie1.Title, result.Title);
        }

        [Fact]
        public async Task GetByTitle_WhenTitleDoesNotExist_ShouldReturnNull()
        {
            // Act

            // Assert
            var resultMovie = await _controller.GetByTitle("Some title");
            Assert.Null(resultMovie);
        }


        [Fact]
        public async Task SearchByTitleFragmentAsync_WhenTitleFragmentExists_ShouldReturnMatchingMovies()
        {
            // Arrange
            Movie testMovie1 = new Movie
            {
                Title = "He himself",
                Director = "Me myself",
                YearReleased = 1991,
                Genre = "Drama",
                Duration = 34,
                Rating = 8.5
            };

            Movie testMovie2 = new Movie
            {
                Title = "Her life",
                Director = "My friend",
                YearReleased = 1998,
                Genre = "Drama",
                Duration = 122,
                Rating = 5.8
            };

            await _controller.AddAsync(testMovie1);
            await _controller.AddAsync(testMovie2);

            // Act

            var result = await _controller.SearchByTitleFragmentAsync("He");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, movie => movie.Title == "Her life" && movie.Title == "Her life");

        }

        [Fact]
        public async Task SearchByTitleFragmentAsync_WhenNoMatchingTitleFragment_ShouldThrowKeyNotFoundException()
        {
            // Act and Assert
            var ex = await Assert.ThrowsAsync<KeyNotFoundException>(() => _controller.SearchByTitleFragmentAsync("cat"));
            Assert.Equal("No movies found.", ex.Message);
        }

        [Fact]
        public async Task UpdateAsync_WhenValidMovieProvided_ShouldUpdateMovie()
        {
            // Arrange
            Movie testMovie2 = new Movie
            {
                Title = "Her life",
                Director = "My friend",
                YearReleased = 1998,
                Genre = "Drama",
                Duration = 122,
                Rating = 5.8
            };

            await _controller.AddAsync(testMovie2);

            // Modify the movie
            string newTitle = "Im here";
            testMovie2.Title = newTitle;

            // Act
            await _controller.UpdateAsync(testMovie2);

            // Assert

            var result = await _dbContext.Movies.Find(movie => movie.Title == newTitle).FirstOrDefaultAsync();
            Assert.NotNull(result);
            Assert.Equal(newTitle, result.Title);
        }

        [Fact]
        public async Task UpdateAsync_WhenInvalidMovieProvided_ShouldThrowValidationException()
        {
            // Arrange
            Movie testMovie2 = new Movie
            {
                Title = "Her life",
                Director = "My friend",
                YearReleased = 1998,
                Genre = "Drama",
                Duration = 122,
                Rating = 5.8
            };

            await _controller.AddAsync(testMovie2);

            // Modify the movie
            string newTitle = "Im here";
            double newRating = 11.00;

            testMovie2.Title = newTitle;
            testMovie2.Rating = newRating;

            // Act & Assert

            var ex = await Assert.ThrowsAsync<ValidationException>(() => _controller.UpdateAsync(testMovie2));
            Assert.Equal("Movie is not valid.", ex.Message);
        }
    }
}
