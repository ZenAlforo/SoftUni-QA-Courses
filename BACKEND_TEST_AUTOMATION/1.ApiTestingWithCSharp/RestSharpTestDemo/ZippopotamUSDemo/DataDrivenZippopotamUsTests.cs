using Newtonsoft.Json;
using RestSharp;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ZippopotamUSDemo
{
    public class Tests
    {
        private RestClient client;

        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://api.zippopotam.us");
        }

        [TestCase("BG", "1000", "Sofija")]
        [TestCase("BG", "5000", "Veliko Turnovo")]
        [TestCase("CA", "M5S", "Toronto")]
        [TestCase("GB", "B1", "Birmingham")]
        [TestCase("DE", "01067", "Dresden")]
        public void Test_ZippopotamUsAPI_ShouldRetrieveRequestedData(string countryCode, string zipCode, string expectedPlace)
        {
            // Arrange
            var request = new RestRequest($"{countryCode}/{zipCode}");

            // Act
            var response = client.Execute(request, Method.Get);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The API call failed");
            Assert.That(response.Content, Is.Not.Null.And.Not.Empty, "There is no response");

            var location = JsonConvert.DeserializeObject<Location>(response.Content);
            Assert.That(location, Is.Not.Null);
            Assert.That(location.Places, Is.Not.Null.And.Not.Empty);

            var actualPlace = location.Places[0].PlaceName;

            Console.WriteLine(actualPlace);

            Assert.That(location.Places, Is.Not.Empty, "No places returned");
            Assert.That(actualPlace.Contains(expectedPlace));
        }

        [TearDown]
        public void Teardown()
        {
            client.Dispose();
        }
    }
}