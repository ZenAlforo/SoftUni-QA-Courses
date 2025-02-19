using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MoviesLibraryAPI.Controllers;
using MoviesLibraryAPI.Controllers.Contracts;
using MoviesLibraryAPI.Data.Models;
using MoviesLibraryAPI.Services;
using MoviesLibraryAPI.Services.Contracts;
using NuGet.Frameworks;
using System.ComponentModel.DataAnnotations;

namespace MoviesLibraryAPI.Tests
{
    [TestFixture]
    public class NUnitIntegrationTests
    {
        private MoviesLibraryNUnitTestDbContext _dbContext;
        private IMoviesLibraryController _controller;
        private IMoviesRepository _repository;
        IConfiguration _configuration;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        [SetUp]
        public async Task Setup()
        {
            string dbName = $"MoviesLibraryTestDb_{Guid.NewGuid()}";
            _dbContext = new MoviesLibraryNUnitTestDbContext(_configuration, dbName);

            _repository = new MoviesRepository(_dbContext.Movies);
            _controller = new MoviesLibraryController(_repository);
        }

        [TearDown]
        public async Task TearDown()
        {
            await _dbContext.ClearDatabaseAsync();
        }

        [Test]
        public async Task AddMovieAsync_WhenValidMovieProvided_ShouldAddToDatabase()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            // Act
            await _controller.AddAsync(movie);

            // Assert
            var resultMovie = await _dbContext.Movies.Find(m => m.Title == "Test Movie").FirstOrDefaultAsync();
            Assert.IsNotNull(resultMovie);
        }

        [Test]
        public async Task AddMovieAsync_WhenInvalidMovieProvided_ShouldThrowValidationException()
        {
            // Arrange
            var invalidMovie = new Movie
            {
                // Provide an invalid movie object, for example, missing required fields like 'Title'
                // Assuming 'Title' is a required field, do not set it
                Title = "",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            // Act and Assert
            // Expect a ValidationException because the movie is missing a required field
            var exception = Assert.ThrowsAsync<ValidationException>(() => _controller.AddAsync(invalidMovie));
        }

        [Test]
        public async Task DeleteAsync_WhenValidTitleProvided_ShouldDeleteMovie()
        {
            // Arrange
            var validMovie = new Movie
            {
                // Provide an invalid movie object, for example, missing required fields like 'Title'
                // Assuming 'Title' is a required field, do not set it
                Title = "New movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 9.5
            };

            // Act            
            await _repository.AddMovieAsync(validMovie);
            Assert.IsNotNull(_dbContext.Movies);
            await _controller.DeleteAsync(validMovie.Title);
            var movies = await _repository.GetAllMoviesAsync();
            var result = await _dbContext.Movies.Find(m => m.Title == validMovie.Title).FirstOrDefaultAsync();

            // Assert
            Assert.IsEmpty(movies);
            Assert.IsNull(result);

        }


        [Test]
        public async Task DeleteAsync_WhenTitleIsNull_ShouldThrowArgumentException()
        {
            // Act and Assert
            var expectedMessage = "Title cannot be empty.";
            var ex = Assert.ThrowsAsync<ArgumentException>(() => _controller.DeleteAsync(null));

            // Assert
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public async Task DeleteAsync_WhenTitleIsEmpty_ShouldThrowArgumentException()
        {
            // Act and Assert
            var expectedMessage = "Title cannot be empty.";
            var ex = Assert.ThrowsAsync<ArgumentException>(() => _controller.DeleteAsync(string.Empty));

            // Assert
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public async Task DeleteAsync_WhenTitleDoesNotExist_ShouldThrowInvalidOperationException()
        {
            // Act and Assert
            var movieToDeleteTitle = "Terminator";
            var expectedErrorMessage = $"Movie with title '{movieToDeleteTitle}' not found.";
            var ex = Assert.ThrowsAsync<InvalidOperationException>(() => _controller.DeleteAsync(movieToDeleteTitle));

            // Assert
            Assert.AreEqual(expectedErrorMessage, ex.Message);
        }

        [Test]
        public async Task GetAllAsync_WhenNoMoviesExist_ShouldReturnEmptyList()
        {
            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task GetAllAsync_WhenMoviesExist_ShouldReturnAllMovies()
        {
            // Arrange
            var movie1 = new Movie
            {
                // Provide an invalid movie object, for example, missing required fields like 'Title'
                // Assuming 'Title' is a required field, do not set it
                Title = "Terminator",
                Director = "Samuel",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 8.5
            };

            var movie2 = new Movie
            {
                // Provide an invalid movie object, for example, missing required fields like 'Title'
                // Assuming 'Title' is a required field, do not set it
                Title = "Drama Queen",
                Director = "Aleksandra",
                YearReleased = 2018,
                Genre = "Drama",
                Duration = 130,
                Rating = 6.5
            };

            await _repository.AddMovieAsync(movie1);
            await _repository.AddMovieAsync(movie2);

            // Act

            var result = await _controller.GetAllAsync();
            // Assert

            Assert.True(result.Count() == 2);
            var hasFirstMovie = result.Any(x => x.Title == movie1.Title);
            Assert.True(hasFirstMovie);
            // Ensure that all movies are returned
        }

        [Test]
        public async Task GetByTitle_WhenTitleExists_ShouldReturnMatchingMovie()
        {
            // Arrange
            var movie1 = new Movie
            {
                // Provide an invalid movie object, for example, missing required fields like 'Title'
                // Assuming 'Title' is a required field, do not set it
                Title = "Terminator",
                Director = "Samuel",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 8.5
            };

            var movie2 = new Movie
            {
                // Provide an invalid movie object, for example, missing required fields like 'Title'
                // Assuming 'Title' is a required field, do not set it
                Title = "Drama Queen",
                Director = "Aleksandra",
                YearReleased = 2018,
                Genre = "Drama",
                Duration = 130,
                Rating = 6.5
            };

            await _repository.AddMovieAsync(movie1);
            await _repository.AddMovieAsync(movie2);

            // Act
            var result = await _controller.GetByTitle(movie1.Title);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(movie1.Title, result.Title);
        }

        [Test]
        public async Task GetByTitle_WhenTitleDoesNotExist_ShouldReturnNull()
        {
            // Assert
            var movieTitle = "Valkyrie";

            // Act
            var result = await _controller.GetByTitle(movieTitle);

            // Assert
            Assert.IsNull(result);
        }


        [Test]
        public async Task SearchByTitleFragmentAsync_WhenTitleFragmentExists_ShouldReturnMatchingMovies()
        {
            // Arrange
            var movie1 = new Movie
            {
                // Provide an invalid movie object, for example, missing required fields like 'Title'
                // Assuming 'Title' is a required field, do not set it
                Title = "Terminator",
                Director = "Samuel",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 8.5
            };

            var movie2 = new Movie
            {
                // Provide an invalid movie object, for example, missing required fields like 'Title'
                // Assuming 'Title' is a required field, do not set it
                Title = "Drama Queen",
                Director = "Aleksandra",
                YearReleased = 2018,
                Genre = "Drama",
                Duration = 130,
                Rating = 6.5
            };

            await _repository.AddMovieAsync(movie1);
            await _repository.AddMovieAsync(movie2);

            // Act
            var result = await _controller.SearchByTitleFragmentAsync("Drama");

            // Assert // Should return one matching movie
            Assert.IsNotNull(result);
            Assert.AreEqual(movie2.Title, result.FirstOrDefault().Title);
        }

        [Test]
        public async Task SearchByTitleFragmentAsync_WhenNoMatchingTitleFragment_ShouldThrowKeyNotFoundException()
        {
            // Act and Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => _controller.SearchByTitleFragmentAsync("Test"));
            Assert.AreEqual("No movies found.", ex.Message);
        }

        [Test]
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
            await _repository.AddMovieAsync(movie1);

            // Modify the movie
            var newTitle = $"Updated {movie1.Title}";
            movie1.Title = newTitle;
            movie1.Rating = 7.8;

            // Act
            await _controller.UpdateAsync(movie1);

            // Assert
            var result = await _controller.SearchByTitleFragmentAsync(movie1.Title);
            Assert.IsNotNull(result);
            Assert.AreEqual(movie1.Rating, result.First().Rating);
            Assert.AreEqual(movie1.Title, result.First().Title);
        }

        [Test]
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
            await _repository.AddMovieAsync(movie1);

            // Modify the movie
            movie1.Title = null;
            movie1.Rating = 7.8;

            // Act
            var ex = Assert.ThrowsAsync<ValidationException>(() => _controller.UpdateAsync(movie1));

            // Assert
            Assert.That("Movie is not valid.", Is.EqualTo(ex.Message));
        }


        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await _dbContext.ClearDatabaseAsync();
        }
    }
}
