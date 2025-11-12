using Eventmi.Core.Models.Event;
using Eventmi.Infrastructure.Data.Contexts;
using Eventmi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestSharp;
using System.Net;

namespace EventMi.Tests
{
    public class EventControllerTests
    {
        private RestClient _client;
        private string _baseUrl = "https://localhost:7236";

        [SetUp]
        public void Setup()
        {
            _client = new RestClient(_baseUrl);
        }

        [Test]
        public async Task TestGetAllEventsMethod_ShouldReturnSuccessStatusCode()
        {
            // Arrange
            var request = new RestRequest("/Event/All");

            // Act
            var response = await _client.ExecuteAsync(request, Method.Get);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The response code should be successful");
        }

        [Test]
        public async Task TestAdd_GetRequest_ShouldReturnAddView()
        {
            // Arrange
            var request = new RestRequest("/Event/Add");

            // Act
            var response = await _client.ExecuteAsync(request, Method.Get);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task TestAdd_PostRequest_ShouldAddEventAndRedirect()
        {
            // Arrange
            var input = new EventFormModel()
            {
                Name = "Test Event",
                Place = "Sofia",
                Start = new DateTime(2025, 11, 12, 20, 22, 00),
                End = new DateTime(2025, 11, 13, 20, 22, 00)
            };

            var request = new RestRequest("/Event/Add", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("Name", input.Name);
            request.AddParameter("Place", input.Place);
            request.AddParameter("Start", input.Start.ToString("dd/MM/yyyy hh:mm:ss"));
            request.AddParameter("End", input.End.ToString("dd/MM/yyyy hh:mm:ss"));

            // Act
            var response = await _client.ExecuteAsync(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsTrue(CheckIfEventExists(input.Name), "The event was not added to the database");
        }

        [Test]
        public async Task TestEventDetails_GetRequest_ShouldReturnEventDetailsView()
        {
            // Arrange
            var eventId = 1;
            var request = new RestRequest($"/Event/Details/{eventId}");

            // Act
            var response = await _client.ExecuteAsync(request, Method.Get);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo((HttpStatusCode)HttpStatusCode.OK), "The response was not successful");
        }

        [Test]
        public async Task TestEventDetails_GetRequest_ShouldReturnNotFound_IfNoIdIsGiven()
        {
            // Arrange
            var eventId = "";
            var request = new RestRequest($"/Event/Details/{eventId}");

            // Act
            var response = await _client.ExecuteAsync(request, Method.Get);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo((HttpStatusCode)HttpStatusCode.NotFound), "The response was not as expected");
        }

        [Test]
        public async Task TestEditDetails_GetRequest_ShouldReturnEditView()
        {
            // Arrange
            var eventId = 1;
            var request = new RestRequest($"/Event/Edit/{eventId}");

            // Act
            var response = await _client.ExecuteAsync(request, Method.Get);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo((HttpStatusCode)HttpStatusCode.OK), "The response was not successful");
        }

        [Test]
        public async Task TestEditEventDetails_GetRequest_ShouldReturnEditView_WhenNoIdIsGiven()
        {
            // Arrange
            var eventId = 1;
            var request = new RestRequest($"/Event/Edit/");

            // Act
            var response = await _client.ExecuteAsync(request, Method.Get);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo((HttpStatusCode)HttpStatusCode.NotFound), "The response was not successful");
        }

        [Test]
        public async Task TestEditEventDetails_PostRequest_ShouldBeSuccessful()
        {
            // Arrange
            var eventId = 1;
            var dbEvent = await GetEventByIdAsync(eventId);

            var editedEvent = new EventFormModel()
            {
                Id = dbEvent.Id,
                Name = "This event was updated",
                Start = dbEvent.Start,
                End = dbEvent.End,
                Place = dbEvent.Place
            };

            var request = new RestRequest($"/Event/Edit/{editedEvent.Id}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("Id", editedEvent.Id);
            request.AddParameter("Name", editedEvent.Name);
            request.AddParameter("Place", editedEvent.Place);
            request.AddParameter("Start", editedEvent.Start);
            request.AddParameter("End", editedEvent.End);

            // Act
            var response = await _client.ExecuteAsync(request, Method.Post);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The request was not successful");
            var updatedDbEvent = await GetEventByIdAsync(eventId);
            Assert.That(updatedDbEvent.Name, Is.EqualTo(dbEvent.Name), "The event name was not updated");
        }

        [Test]
        public async Task TestEditEventDetails_PostRequest_ShouldReturnSameView_IfModelIsNotKept()
        {
            // Arrange
            var eventId = 1;
            var eventInDb = await GetEventByIdAsync(eventId);

            var eventModel = new EventFormModel()
            {
                Id = eventInDb.Id,
                Name = "",
                Place = ""
            };

            var request = new RestRequest($"/Event/Edit/{eventId}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("Id", eventInDb.Id);
            request.AddParameter("Name", eventModel.Name);
            request.AddParameter("End", eventModel.End);

            // Act
            var response = await _client.ExecuteAsync(request, Method.Post);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The response result was not as expected");
        }

        [Test]
        public async Task TestEditEventDetails_PostRequest_ShouldReturnNotFound_IfIdsDoNotMatch()
        {
            // Arrange
            var eventId = 1;
            var dbEvent = await GetEventByIdAsync(eventId);

            var editedEvent = new EventFormModel()
            {
                Id = dbEvent.Id,
                Name = "This event was updated",
                Start = dbEvent.Start,
                End = dbEvent.End,
                Place = dbEvent.Place
            };

            var request = new RestRequest($"/Event/Edit/{editedEvent.Id}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("Id", 45);
            request.AddParameter("Name", editedEvent.Name);
            request.AddParameter("Place", editedEvent.Place);
            request.AddParameter("Start", editedEvent.Start);
            request.AddParameter("End", editedEvent.End);

            // Act
            var response = await _client.ExecuteAsync(request, Method.Post);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "The response result was not as expected");
        }

        [Test]
        public async Task TestDeleteEvent_DeleteRequest_ShouldReturnSuccessfulCodeAndRedirectToAllEventsVieww_IfIdIsValid()
        {
            // Arrange
            var eventToAdd = new EventFormModel()
            {
                Name = "New event to dest Delete",
                Start = new DateTime(2025, 11, 12, 22, 22, 00),
                End = new DateTime(2025, 12, 12, 22, 22, 00),
                Place = "My Home"
            };

            var request = new RestRequest($"/Event/Add/");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("Name", eventToAdd.Name);
            request.AddParameter("Place", eventToAdd.Place);
            request.AddParameter("Start", eventToAdd.Start);
            request.AddParameter("End", eventToAdd.End);

            await _client.ExecuteAsync(request, Method.Post);
            var eventInDb = await GetEventByNameAsync(eventToAdd.Name);
            var eventToDelete = eventInDb.Id;

            var deleteRequest = new RestRequest($"/Event/Delete/{eventToDelete}");

            // Act
            var response = await _client.ExecuteAsync(deleteRequest, Method.Post);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The response result was not as expected");
        }

        [Test]
        public async Task TestDeleteEvent_PostRequest_ShouldRedirectToAllEvents_IfIdNotValid()
        {
            // Arrange
            var request = new RestRequest("/Event/Delete/");

            // Act
            var response = await _client.ExecuteAsync(request, Method.Post);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "The response was not as expected");
        }

        private bool CheckIfEventExists(string name)
        {
            var options = new DbContextOptionsBuilder<EventmiContext>()
                .UseSqlServer("Server=.;Database=Eventmi;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            using (var context = new EventmiContext(options))
            {
                return context.Events.Any(e => e.Name == name);
            }
        }

        private async Task<Event> GetEventByNameAsync(string name)
        {
            var options = new DbContextOptionsBuilder<EventmiContext>()
                .UseSqlServer("Server=.;Database=Eventmi;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            using (var context = new EventmiContext(options))
            {
                return await context.Events.FirstOrDefaultAsync<Event>(e => e.Name == name);
            }
        }

        private async Task<Event> GetEventByIdAsync(int id)
        {
            var options = new DbContextOptionsBuilder<EventmiContext>()
                .UseSqlServer("Server=.;Database=Eventmi;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            using (var context = new EventmiContext(options))
            {
                return await context.Events.FirstOrDefaultAsync<Event>(e => e.Id == id);
            }
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
        }
    }
}