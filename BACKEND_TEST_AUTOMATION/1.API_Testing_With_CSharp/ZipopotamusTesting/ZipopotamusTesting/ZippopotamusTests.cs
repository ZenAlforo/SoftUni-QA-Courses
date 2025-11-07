using RestSharp;
using System.Text.Json;

namespace ZippopotamusTesting
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
        public void TestZippopotamus(string countryCode, string zipCode, string expectedCity)
        {
            // Arrange
            var request = new RestRequest(countryCode + "/" + zipCode);

            // Act
            var response = client.Execute(request, Method.Get);

            // Assert
            var location = JsonSerializer.Deserialize<Location>(response.Content);
            Assert.IsNotNull(location);
            StringAssert.Contains(expectedCity, location.Places[0].PlaceName);
        }

        [TearDown]
        public void TearDown()
        {
            client.Dispose();
        }
    }
}