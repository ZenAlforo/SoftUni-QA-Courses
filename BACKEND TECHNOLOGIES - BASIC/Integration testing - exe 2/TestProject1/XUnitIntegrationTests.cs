using MongoDB.Driver;
using MoviesLibraryAPI.Controllers;
using MoviesLibraryAPI.Controllers.Contracts;
using MoviesLibraryAPI.Data.Models;
using MoviesLibraryAPI.Services;
using MoviesLibraryAPI.Services.Contracts;
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
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 120,
                Rating = 7.5
            };

            // Act
            await _controller.AddAsync(movie);

            // Assert
            var resultMovie = await _dbContext.Movies.Find(m => m.Title == "Test Movie").FirstOrDefaultAsync();
            Xunit.Assert.NotNull(resultMovie);
            Xunit.Assert.Equal("Test Movie", resultMovie.Title);
            Xunit.Assert.Equal("Test Director", resultMovie.Director);
            Xunit.Assert.Equal(2022, resultMovie.YearReleased);
            Xunit.Assert.Equal("Action", resultMovie.Genre);
            Xunit.Assert.Equal(120, resultMovie.Duration);
            Xunit.Assert.Equal(7.5, resultMovie.Rating);
        }

        [Fact]
        public async Task AddMovieAsync_WhenInvalidMovieProvided_ShouldThrowValidationException()
        {
            // Arrange
            var invalidMovie = new Movie
            {
                // Provide an invalid movie object, e.g., without a title or other required fields
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 120,
                Rating = 7.5
            };

            // Act and Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => _controller.AddAsync(invalidMovie));
            Assert.Equal("Movie is not valid.", ex.Result.Message);
        }

        [Fact]
        public async Task DeleteAsync_WhenValidTitleProvided_ShouldDeleteMovie()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie2",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 120,
                Rating = 7.5
            };
            await _controller.AddAsync(movie);
            var resultBeforeDeletion = await _controller.GetAllAsync();
            Assert.NotEmpty(resultBeforeDeletion);
            Assert.Equal(movie.Title, resultBeforeDeletion.First().Title);

            // Act
            await _controller.DeleteAsync(movie.Title);
            // Assert
            var resultAfterDeletion = await _controller.GetAllAsync();

            Assert.Empty(resultAfterDeletion);
        }


        [Fact]
        public async Task DeleteAsync_WhenTitleIsNotValid_ShouldThrowInvalidOperationException()
        {
            // Act and Assert
            var title = "Terminator";
            var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => _controller.DeleteAsync(title));
            Assert.Equal($"Movie with title '{title}' not found.", ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task DeleteAsync_WhenTitleIsNullOrEmpty_ShouldThrowArgumentException(string title)
        {
            // Act and Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _controller.DeleteAsync(title));
            Assert.Equal("Title cannot be empty.", ex.Message);
        }

        [Fact]
        public async Task GetAllAsync_WhenNoMoviesExist_ShouldReturnEmptyList()
        {
            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetAllAsync_WhenMoviesExist_ShouldReturnAllMovies()
        {
            // Arrange
            var movie1 = new Movie
            {
                Title = "Test Movie2",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 120,
                Rating = 7.5
            };

            var movie2 = new Movie
            {
                Title = "Different movie",
                Director = "Samuel",
                YearReleased = 2019,
                Genre = "Romance",
                Duration = 110,
                Rating = 8.5
            };
            await _controller.AddAsync(movie1);
            await _controller.AddAsync(movie2);

            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
            var firstMovieInDb = await _dbContext.Movies.Find(x => x.Title == movie1.Title).FirstOrDefaultAsync();
            var secondMovieInDb = await _dbContext.Movies.Find(y => y.Title == movie2.Title).FirstOrDefaultAsync();
            Assert.Equal(firstMovieInDb.Title, movie1.Title);
            Assert.Equal(secondMovieInDb.Director, movie2.Director);
        }

        [Fact]
        public async Task GetByTitle_WhenTitleExists_ShouldReturnMatchingMovie()
        {
            // Arrange
            var movie1 = new Movie
            {
                Title = "Test Movie2",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 120,
                Rating = 7.5
            };

            var movie2 = new Movie
            {
                Title = "Different movie",
                Director = "Samuel",
                YearReleased = 2019,
                Genre = "Romance",
                Duration = 110,
                Rating = 8.5
            };
            await _controller.AddAsync(movie1);
            await _controller.AddAsync(movie2);
            // Act

            var result = await _controller.GetByTitle(movie1.Title);

            // Assert
            Assert.Equal(2, (await _controller.GetAllAsync()).Count());
            Assert.Equal(result.Title, movie1.Title);
        }

        [Fact]
        public async Task GetByTitle_WhenTitleDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            var title = "Xena";

            // Act
            var resultMovieList = await _controller.GetByTitle(title);
            
            // Assert
            Assert.Null(resultMovieList);
        }


        [Fact]
        public async Task SearchByTitleFragmentAsync_WhenTitleFragmentExists_ShouldReturnMatchingMovies()
        {
            // Arrange
            var movie1 = new Movie
            {
                Title = "Test Movie2",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 120,
                Rating = 7.5
            };

            var movie2 = new Movie
            {
                Title = "Different movie",
                Director = "Samuel",
                YearReleased = 2019,
                Genre = "Romance",
                Duration = 110,
                Rating = 8.5
            };
            await _controller.AddAsync(movie1);
            await _controller.AddAsync(movie2);
            // Act

            var result = await _controller.SearchByTitleFragmentAsync("Test");

            // Assert
            Assert.Equal(1, result.Count());
            Assert.Equal(result.First().Genre, movie1.Genre);
        }

        [Fact]
        public async Task SearchByTitleFragmentAsync_WhenNoMatchingTitleFragment_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var titleFragment = "cat";

            // Act and Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => _controller.SearchByTitleFragmentAsync(titleFragment));
            Assert.Equal("No movies found.", ex.Result.Message);
        }

        [Fact]
        public async Task UpdateAsync_WhenValidMovieProvided_ShouldUpdateMovie()
        {
            // Arrange
            var movie1 = new Movie
            {
                // Assuming 'Title' is a required field, do not set it
                Title = "Terminator",
                Director = "Samuel",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 8.5
            };
            await _controller.AddAsync(movie1);

            // Modify the movie
            var newTitle = $"Updated {movie1.Title}";
            movie1.Title = newTitle;
            movie1.Rating = 7.8;

            // Act
            await _controller.UpdateAsync(movie1);

            // Assert
            var result = await _controller.SearchByTitleFragmentAsync(movie1.Title);
            Assert.NotNull(result);
            Assert.Equal(movie1.Rating, result.First().Rating);
            Assert.Equal(movie1.Title, result.First().Title);
        }

        [Fact]
        public async Task UpdateAsync_WhenInvalidMovieProvided_ShouldThrowValidationException()
        {
            // Arrange
            var movie1 = new Movie
            {
                // Assuming 'Title' is a required field, do not set it
                Title = "Terminator",
                Director = "Samuel",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 8.5
            };
            await _controller.AddAsync(movie1);

            // Act
            movie1.YearReleased = 0;
            var ex = Assert.ThrowsAsync<ValidationException>(() => _controller.UpdateAsync(movie1));
            Assert.Equal("Movie is not valid.", ex.Result.Message);
        }
    }
}
