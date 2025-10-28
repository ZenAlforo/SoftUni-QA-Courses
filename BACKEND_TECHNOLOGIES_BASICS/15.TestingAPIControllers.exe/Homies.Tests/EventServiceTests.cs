using Homies.Data;
using Homies.Data.Models;
using Homies.Models.Event;
using Homies.Services;
using Microsoft.EntityFrameworkCore;

namespace Homies.Tests
{
    [TestFixture]
    internal class EventServiceTests
    {
        private HomiesDbContext _dbContext;
        private EventService _eventService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<HomiesDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Use unique database name to avoid conflicts
                .Options;
            _dbContext = new HomiesDbContext(options);

            _eventService = new EventService(_dbContext);
        }

        [Test]
        public async Task AddEventAsync_ShouldAddEvent_WhenValidEventModelAndUserId()
        {
            // Step 1: Arrange - Set up the initial conditions for the test
            // Create a new event model with test data

            var eventModel = new EventFormModel
            {
                Name = "Test Event",
                Description = "Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2)
            };

            // Define a user ID for testing purposes

            string userId = "testUserId";

            // Step 2: Act - Perform the action being tested
            // Call the service method to add the event

            await _eventService.AddEventAsync(eventModel, userId);

            // Step 3: Assert - Verify the outcome of the action
            // Retrieve the added event from the database

            var result = await _dbContext.Events.FirstOrDefaultAsync(e => e.Name == eventModel.Name && e.OrganiserId == userId);

            // Assert that the added event is not null, indicating it was successfully added
            Assert.NotNull(result, "The event was not found in the db");

            // Assert that the description of the added event matches the description provided in the event model
            Assert.That(result.Description, Is.EqualTo(eventModel.Description));
            Assert.That(result.Start, Is.EqualTo(eventModel.Start));
            Assert.That(result.End, Is.EqualTo(eventModel.End));
        }

        [Test]
        public async Task GetAllEventsAsync_ShouldReturnAllEvents()
        {
            // Step 1: Arrange - Set up the initial conditions for the test
            // Create two event models with test data

            var firstEvent = new EventFormModel
            {
                Name = "My Birthday",
                Description = "I am entering my 30s",
                Start = new DateTime(2026, 07, 02, 00, 00, 00),
                End = new DateTime(2026, 07, 02, 23, 59, 59)
            };

            var secondEvent = new EventFormModel
            {
                Name = "My Work Anniversary",
                Description = "I am entering my 11th year at the company",
                Start = new DateTime(2026, 05, 15, 00, 00, 00),
                End = new DateTime(2026, 05, 15, 23, 59, 59)
            };

            // Define a user ID for testing purposes
            string userId = "testUserId";

            // Step 2: Act - Perform the action being tested
            // Add the two events to the database using the event service
            await _eventService.AddEventAsync(firstEvent, userId);
            await _eventService.AddEventAsync(secondEvent, userId);

            // Step 3: Act - Retrieve the count of events from the database
            var eventsInDb = await _eventService.GetAllEventsAsync();

            // Step 4: Assert - Verify the outcome of the action
            // Assert that the count of events in the database is equal to the expected count (2)
            Assert.That(eventsInDb, Is.Not.Null, "Events were not added to the DB");
            Assert.That(eventsInDb.Count(), Is.EqualTo(2), "Events count is different than the ones we added");
        }

        [Test]
        public async Task GetEventDetailsAsync_ShouldReturnAllEventDetails()
        {
            // Arrange

            var eventModel = new EventFormModel
            {
                Name = "Test Event",
                Description = "Test Description",
                Start = DateTime.Now.AddHours(1),
                End = DateTime.Now.AddHours(2),
                TypeId = 2
            };

            await _eventService.AddEventAsync(eventModel, "NonExistingUserId");
            var eventInDb = await _dbContext.Events.FirstAsync();

            // Act
            var result = await _eventService.GetEventDetailsAsync(eventInDb.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(eventModel.Name));
            Assert.That(result.Description, Is.EqualTo(eventModel.Description));
            Assert.That(result.Start, Is.EqualTo(eventModel.Start.ToString("dd/MM/yyyy H:mm")));
            Assert.That(result.End, Is.EqualTo(eventModel.End.ToString("dd/MM/yyyy H:mm")));
        }

        [Test]
        public async Task GetEventForEditAsync_ShouldReturnTheSearchedEvent()
        {
            // Arrange

            var myEvent = new EventFormModel
            {
                Name = "My cats birthday",
                Description = "So lovely little fella",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow.AddDays(1)
            };

            var id = Guid.NewGuid().ToString();

            await _eventService.AddEventAsync(myEvent, id);
            var eventInDb = await _dbContext.Events.FirstAsync();

            // Act
            var result = await _eventService.GetEventForEditAsync(eventInDb.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(eventInDb.Name, Is.EqualTo(result.Name));
            Assert.That(eventInDb.Description, Is.EqualTo(result.Description));
            Assert.That(eventInDb.Start, Is.EqualTo(result.Start));
            Assert.That(eventInDb.End, Is.EqualTo(result.End));
        }

        [Test]
        public async Task GetEventForEditAsync_ShouldReturnNullIfNotExistingIdIsSearched()
        {
            // Arrange
            // Act
            var result = await _eventService.GetEventForEditAsync(10);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetEventOrganizerIdAsync_ShouldReturnTheSearchedEventOrganizerId()
        {
            // Arrange

            var myEvent = new EventFormModel
            {
                Name = "My cats birthday",
                Description = "So lovely little fella",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow.AddDays(1)
            };

            var id = Guid.NewGuid().ToString();

            await _eventService.AddEventAsync(myEvent, id);

            var eventInDb = await _dbContext.Events.FirstAsync();

            // Act
            var result = await _eventService.GetEventOrganizerIdAsync(eventInDb.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(id));
        }

        [Test]
        public async Task GetEventOrganizerIdAsync_ShouldReturnNullIfTheSearchedEventIsNotExisting()
        {
            // Arrange

            // Act
            var result = await _eventService.GetEventOrganizerIdAsync(22);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetUserJoinedEventsAsync_ShouldReturnAllJoinedUsers()
        {
            // Arrange

            // Add constant userid
            const string userId = "userId";

            // Create, Add and Save type to db
            var testType = new Homies.Data.Models.Type
            {
                Name = "TestType"
            };

            await _dbContext.Types.AddAsync(testType);
            await _dbContext.SaveChangesAsync();

            // Create event, add it and save it to the db
            var myEvent = new Event
            {
                Name = "Test Event",
                Description = "Event for testing my project",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow.AddDays(2),
                TypeId = testType.Id,
                OrganiserId = userId
            };

            await _dbContext.Events.AddAsync(myEvent);
            await _dbContext.SaveChangesAsync();

            // Create event participant, add and save it to db

            var newEventParticipant = new EventParticipant
            {
                EventId = myEvent.Id,
                HelperId = userId
            };

            await _dbContext.EventsParticipants.AddAsync(newEventParticipant);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _eventService.GetUserJoinedEventsAsync(userId);

            // Assert successfully added event and number of event expected
            Assert.NotNull(result);
            Assert.That(result.Count, Is.EqualTo(1));

            // Assert properties
            var eventParticipation = result.First();

            Assert.That(eventParticipation.Id, Is.EqualTo(myEvent.Id));
            Assert.That(eventParticipation.Name, Is.EqualTo(myEvent.Name));
            Assert.That(eventParticipation.Type, Is.EqualTo(testType.Name));
        }

        [Test]
        public async Task JoinEventAsync_ShouldReturnFalseIfEventDoesNotExist()
        {
            // Arrange
            var eventId = 4;
            var userId = "userId";

            // Act
            var result = await _eventService.JoinEventAsync(eventId, userId);

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task JoinEventAsync_ShouldReturnFalseIfUserIsAlreadyPartOfTheEvent()
        {
            // Arrange

            // Add constant userid
            const string userId = "userId";

            // Create, Add and Save type to db
            var testType = new Homies.Data.Models.Type
            {
                Name = "TestType"
            };

            await _dbContext.Types.AddAsync(testType);
            await _dbContext.SaveChangesAsync();

            // Create event, add it and save it to the db
            var myEvent = new Event
            {
                Name = "Test Event",
                Description = "Event for testing my project",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow.AddDays(2),
                TypeId = testType.Id,
                OrganiserId = userId
            };

            await _dbContext.Events.AddAsync(myEvent);
            await _dbContext.SaveChangesAsync();

            // Create event participant, add and save it to db

            var newEventParticipant = new EventParticipant
            {
                EventId = myEvent.Id,
                HelperId = userId
            };

            await _dbContext.EventsParticipants.AddAsync(newEventParticipant);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _eventService.JoinEventAsync(myEvent.Id, userId);

            // Assert successfully added event and number of event expected
            Assert.False(result);
        }

        [Test]
        public async Task JoinEventAsync_ShouldReturnTrueIfUserIsAddedToTheEvent()
        {
            // Arrange

            // Add constant userid
            const string userId = "userId";

            // Create, Add and Save type to db
            var testType = new Homies.Data.Models.Type
            {
                Name = "TestType"
            };

            await _dbContext.Types.AddAsync(testType);
            await _dbContext.SaveChangesAsync();

            // Create event, add it and save it to the db
            var myEvent = new Event
            {
                Name = "Test Event",
                Description = "Event for testing my project",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow.AddDays(2),
                TypeId = testType.Id,
                OrganiserId = userId
            };

            await _dbContext.Events.AddAsync(myEvent);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _eventService.JoinEventAsync(myEvent.Id, userId);

            // Assert successfully added event and number of event expected
            Assert.True(result);
        }

        [Test]
        public async Task LeaveEventAsync_ShouldReturnFalseIfWeTryToLeaveAnEventWeAreNotPartOf()
        {
            // Arrange
            const string userId = "user-id";

            // Act
            var result = await _eventService.LeaveEventAsync(12, userId);

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task LeaveEventAsync_ShouldReturnTrueIfWeLeaveAnEventWeArePartOf()
        {
            // Arrange

            // Add constant userid
            const string userId = "userId";

            // Create, Add and Save type to db
            var testType = new Homies.Data.Models.Type
            {
                Name = "TestType"
            };

            await _dbContext.Types.AddAsync(testType);
            await _dbContext.SaveChangesAsync();

            // Create event, add it and save it to the db
            var myEvent = new Event
            {
                Name = "Test Event",
                Description = "Event for testing my project",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow.AddDays(2),
                TypeId = testType.Id,
                OrganiserId = userId
            };

            await _dbContext.Events.AddAsync(myEvent);
            await _dbContext.SaveChangesAsync();

            // Add participant

            await _eventService.JoinEventAsync(myEvent.Id, userId);

            // Act
            var result = await _eventService.LeaveEventAsync(myEvent.Id, userId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task UpdateEventAsync_ShouldReturnFalseIfEventDoesNotExist()
        {
            // Arrange
            var eventId = 12;
            var testEvent = new EventFormModel
            {
            };
            string userId = "userId";

            // Act
            var result = await _eventService.UpdateEventAsync(eventId, testEvent, userId);

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task UpdateEventAsync_ShouldReturnFalseIfTheOrginiserOfTheEventIsDifferent()
        {
            // Arrange

            // Add constant userid
            const string authorId = "author-id";
            const string userId = "nonAuthor";

            // Create, Add and Save type to db
            var testType = new Homies.Data.Models.Type
            {
                Name = "TestType"
            };

            await _dbContext.Types.AddAsync(testType);
            await _dbContext.SaveChangesAsync();

            // Create event, add it and save it to the db
            var myEvent = new Event
            {
                Name = "Test Event",
                Description = "Event for testing my project",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow.AddDays(2),
                TypeId = testType.Id,
                OrganiserId = authorId
            };

            await _dbContext.Events.AddAsync(myEvent);
            await _dbContext.SaveChangesAsync();

            var myEditedEvent = new EventFormModel
            {
                Name = "Updated Test Event",
                Description = "Event for testing my project No2",
                Start = DateTime.UtcNow.AddDays(2),
                End = DateTime.UtcNow.AddDays(3),
                TypeId = testType.Id,
            };

            // Act
            var result = await _eventService.UpdateEventAsync(myEvent.Id, myEditedEvent, userId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task UpdateEventAsync_ShouldReturnTrueIfEventIsUpdatedSuccessfully()
        {
            // Arrange

            // Add constant userid
            const string authorId = "author-id";
            const string userId = "nonAuthor";

            // Create, Add and Save type to db
            var testType = new Homies.Data.Models.Type
            {
                Name = "TestType"
            };

            await _dbContext.Types.AddAsync(testType);
            await _dbContext.SaveChangesAsync();

            // Create event, add it and save it to the db
            var myEvent = new Event
            {
                Name = "Test Event",
                Description = "Event for testing my project",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow.AddDays(2),
                TypeId = testType.Id,
                OrganiserId = authorId
            };

            await _dbContext.Events.AddAsync(myEvent);
            await _dbContext.SaveChangesAsync();

            var myEditedEvent = new EventFormModel
            {
                Name = "Updated Test Event",
                Description = "Event for testing my project No2",
                Start = DateTime.UtcNow.AddDays(2),
                End = DateTime.UtcNow.AddDays(3),
                TypeId = testType.Id,
            };

            // Act
            var result = await _eventService.UpdateEventAsync(myEvent.Id, myEditedEvent, authorId);

            // Assert
            Assert.True(result);

            var eventInDb = await _dbContext.Events.FindAsync(myEvent.Id);
            Assert.That(eventInDb.Id, Is.EqualTo(myEvent.Id));
            Assert.That(eventInDb.Name, Is.EqualTo(myEditedEvent.Name));
        }

        [Test]
        public async Task GetAllTypesAsync_ShuldReturnAllTypes()
        {
            // Create, Add and Save type to db
            var testType = new Homies.Data.Models.Type
            {
                Name = "TestType"
            };

            await _dbContext.Types.AddAsync(testType);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _eventService.GetAllTypesAsync();

            // Assert
            Assert.NotNull(result);

            var typeInDb = await _dbContext.Types.FirstAsync();

            Assert.That(typeInDb.Id, Is.EqualTo(testType.Id));
            Assert.That(typeInDb.Name, Is.EqualTo(testType.Name));
        }

        [Test]
        public async Task IsUserJoinedEventAsync_ShouldReturnFalse_IfEventDoesNotExist()
        {
            // Arrange
            const int eventId = 123;
            const string userId = "userId";

            // Act
            var result = await _eventService.IsUserJoinedEventAsync(eventId, userId);

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task IsUserJoinedEventAsync_ShouldReturnFalse_IfUserDoesNotExist()
        {
            // Arrange

            // Add constant userid
            const string authorId = "author-id";
            const string userId = "nonAuthor";

            // Create, Add and Save type to db
            var testType = new Homies.Data.Models.Type
            {
                Name = "TestType"
            };

            await _dbContext.Types.AddAsync(testType);
            await _dbContext.SaveChangesAsync();

            // Create event, add it and save it to the db
            var myEvent = new Event
            {
                Name = "Test Event",
                Description = "Event for testing my project",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow.AddDays(2),
                TypeId = testType.Id,
                OrganiserId = authorId
            };

            await _dbContext.Events.AddAsync(myEvent);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _eventService.IsUserJoinedEventAsync(myEvent.Id, userId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsUserJoinedEventAsync_ShouldReturnTrue_IfUserHasJoinedTheEvent()
        {
            // Arrange

            // Add constant userid
            const string authorId = "author-id";
            const string userId = "nonAuthor";

            // Create, Add and Save type to db
            var testType = new Homies.Data.Models.Type
            {
                Name = "TestType"
            };

            await _dbContext.Types.AddAsync(testType);
            await _dbContext.SaveChangesAsync();

            // Create event, add it and save it to the db
            var myEvent = new Event
            {
                Name = "Test Event",
                Description = "Event for testing my project",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow.AddDays(2),
                TypeId = testType.Id,
                OrganiserId = authorId
            };

            await _dbContext.Events.AddAsync(myEvent);
            await _dbContext.SaveChangesAsync();

            await _eventService.JoinEventAsync(myEvent.Id, userId);

            // Act
            var result = await _eventService.IsUserJoinedEventAsync(myEvent.Id, userId);

            // Assert
            Assert.IsTrue(result);
        }
    }
}