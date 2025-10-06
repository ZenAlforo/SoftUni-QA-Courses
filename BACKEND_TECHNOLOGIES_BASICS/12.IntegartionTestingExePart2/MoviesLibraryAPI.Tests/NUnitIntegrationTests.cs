using Amazon.Auth.AccessControlPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MoviesLibraryAPI.Controllers;
using MoviesLibraryAPI.Controllers.Contracts;
using MoviesLibraryAPI.Data.Models;
using MoviesLibraryAPI.Data.Seed;
using MoviesLibraryAPI.Services;
using MoviesLibraryAPI.Services.Contracts;
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
            Assert.That(_dbContext.Movies.CountDocuments(x => true), Is.EqualTo(1));
        }

        [Theory]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        public async Task AddMovieAsync_WhenInvalidMovieProvided_ShouldThrowValidationException(string title)
        {
            // Arrange
            var invalidMovie = new Movie
            {
                // Provide an invalid movie object, for example, missing required fields like 'Title'
                // Assuming 'Title' is a required field, do not set it
                Title = title,
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5

            };

            // Act and Assert
            // Expect a ValidationException because the movie is missing a required field
            var exception = Assert.ThrowsAsync<ValidationException>(() => _controller.AddAsync(invalidMovie));
            Assert.That(exception.Message, Is.EqualTo("Movie is not valid."));
        }

        [Test]
        public async Task DeleteAsync_WhenValidTitleProvided_ShouldDeleteMovie()
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

            await _controller.AddAsync(movie);

            // Act
            await _controller.DeleteAsync(movie.Title);

            // Assert
            var resultMovie = await _dbContext.Movies.Find(m => m.Title == "Test Movie").FirstOrDefaultAsync();
            Assert.IsNull(resultMovie);
        }


        [Theory]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public async Task DeleteAsync_WhenTitleIsNullOrEmpty_ShouldThrowArgumentException(string title)
        {
            // Act and Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(() => _controller.DeleteAsync(title));
            Assert.AreEqual("Title cannot be empty.", ex.Message);
        }

        [Test]
        public async Task DeleteAsync_WhenTitleDoesNotExist_ShouldThrowInvalidOperationException()
        {
            // Act and Assert
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

            await _controller.AddAsync(movie);
            var titleToDelete = "My NON-existent title";

            // Act & Assert
            var ex = Assert.ThrowsAsync<InvalidOperationException>(() => _controller.DeleteAsync(titleToDelete));
            Assert.That(ex.Message, Is.EqualTo($"Movie with title '{titleToDelete}' not found."));
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
            var firstMovie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            await _controller.AddAsync(firstMovie);

            var secondMovie = new Movie
            {
                Title = "Pirates of the Caribbean",
                Director = "Jack Sparrow",
                YearReleased = 2025,
                Genre = "Action",
                Duration = 155,
                Rating = 8.5
            };

            await _controller.AddAsync(secondMovie);

            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            Assert.IsNotEmpty(result);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.Any(m => m.Title == secondMovie.Title));
            Assert.That(result.Any(m => m.Director == firstMovie.Director));

        }

        [Test]
        public async Task GetAllAsync_WhenMoviesDoNotExist_ShouldReturnEmptyCollection()
        {
            // Arrange
            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            Assert.IsEmpty(result);
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetByTitle_WhenTitleExists_ShouldReturnMatchingMovie()
        {
            // Arrange
            var firstMovie = new Movie
            {
                Title = "Matching title",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };
            await _controller.AddAsync(firstMovie);

            // Act
            var result = await _controller.GetByTitle(firstMovie.Title);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Title == firstMovie.Title);
            Assert.That(result.Rating == firstMovie.Rating);
            Assert.That(result.Genre == firstMovie.Genre);


        }

        [Test]
        public async Task GetByTitle_WhenTitleDoesNotExist_ShouldReturnNull()
        {


            // Act
            var result = await _controller.GetByTitle("Caribbean");

            // Assert
            Assert.IsNull(result, "Expecting null when searching for a title that does not exist in the database");
        }


        [Test]
        public async Task SearchByTitleFragmentAsync_WhenTitleFragmentExists_ShouldReturnMatchingMovies()
        {

            // Arrange
            var firstMovie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            await _controller.AddAsync(firstMovie);

            var secondMovie = new Movie
            {
                Title = "Pirates of the Caribbean",
                Director = "Jack Sparrow",
                YearReleased = 2025,
                Genre = "Action",
                Duration = 155,
                Rating = 8.5
            };

            await _controller.AddAsync(secondMovie);

            var thirdMovie = new Movie
            {
                Title = "Sharks of the Caribbean",
                Director = "Jack Norton",
                YearReleased = 1991,
                Genre = "Fantasy",
                Duration = 140,
                Rating = 3.0
            };

            await _controller.AddAsync(thirdMovie);

            // Act
            var result = await _controller.SearchByTitleFragmentAsync("Caribbean");

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            var foundMovie = result.FirstOrDefault(movie => movie.Title == secondMovie.Title);
            Assert.IsNotNull(foundMovie);
        }

        [Test]
        public async Task SearchByTitleFragmentAsync_WhenNoMatchingTitleFragment_ShouldThrowKeyNotFoundException()
        {
            // Act and Assert

            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => _controller.SearchByTitleFragmentAsync("some"));
            Assert.AreEqual("No movies found.", ex.Message);
        }

        [Test]
        public async Task UpdateAsync_WhenValidMovieProvided_ShouldUpdateMovie()
        {
            // Arrange
            var firstMovie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            await _controller.AddAsync(firstMovie);

            // Modify the movie
            string newTitle = "updatedTitle";
            double newRating = 8.1;
            firstMovie.Title = newTitle;
            firstMovie.Rating = newRating;

            // Act
            await _controller.UpdateAsync(firstMovie);

            // Assert
            var foundMovie = await _dbContext.Movies.Find(movie => movie.Title == newTitle).FirstOrDefaultAsync();
            Assert.IsNotNull(foundMovie, "Movie was not found after update");
            Assert.AreEqual(foundMovie.Title, newTitle);
            Assert.AreEqual(foundMovie.Rating, newRating);
           
        }

        [Test]
        public async Task UpdateAsync_WhenInvalidMovieProvided_ShouldThrowValidationException()
        {
            // Arrange
            var firstMovie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            await _controller.AddAsync(firstMovie);

            // Modify the movie
            string newTitle = "updatedTitle";
            double newRating = 11.1;
            firstMovie.Title = newTitle;
            firstMovie.Rating = newRating;

            // Act & Assert
            var ex = Assert.ThrowsAsync<ValidationException> (() => _controller.UpdateAsync(firstMovie));
            Assert.That(ex.Message, Is.EqualTo("Movie is not valid."));
        }


        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await _dbContext.ClearDatabaseAsync();
        }
    }
}
