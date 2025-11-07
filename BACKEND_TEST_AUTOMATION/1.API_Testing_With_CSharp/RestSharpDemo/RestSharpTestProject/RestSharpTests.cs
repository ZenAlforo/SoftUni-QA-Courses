using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Text.Json;

namespace RestSharpTestProject
{
    public class RestSharpTests
    {
        private RestClient client;

        [SetUp]
        public void Setup()
        {
            var options = new RestClientOptions("https://api.github.com")
            {
                Timeout = TimeSpan.FromMilliseconds(3000),
                Authenticator = new HttpBasicAuthenticator("ZenAlforo", "API_KEY")
            };

            client = new RestClient(options);
        }

        [TearDown]
        public void TearDown()
        {
            client.Dispose();
        }

        [Test]
        public void Test_GitHubAPIRequest()
        {
            // Arrange
            var request = new RestRequest("/repos/testnakov/test-nakov-repo/issues", Method.Get);
            request.Timeout = TimeSpan.FromSeconds(1);
            // Act
            var response = client.Get(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void Test_GitHubGetAllIssuesEndpoint_ShouldReturnIssues()
        {
            // Arrange
            var request = new RestRequest("/repos/testnakov/test-nakov-repo/issues", Method.Get);
            request.Timeout = TimeSpan.FromMilliseconds(1_000);

            // Act
            var response = client.Execute(request);
            var issues = System.Text.Json.JsonSerializer.Deserialize<List<Issue>>(response.Content);

            // Assert
            Assert.That(issues.Count > 0);
            foreach (var issue in issues)
            {
                Assert.That(issue.id, Is.GreaterThan(0));
                Assert.That(issue.number, Is.GreaterThan(0));
                Assert.That(issue.title, Is.Not.Empty);
            }
        }

        [Test]
        public void Test_GitHubPostIssueEndpoint_ShouldBeSuccessfull()
        {
            // Arrange
            string title = "Samuels Test Issue";
            string body = "This is just a testing issue";

            // Act
            var issue = CreateIssue(title, body);

            // Assert
            Assert.That(issue.id, Is.GreaterThan(0));
            Assert.That(issue.number, Is.GreaterThan(0));
            Assert.That(issue.title == title);
            Assert.That(issue.body == body);
        }

        [Test]
        public void Test_GitHubPatchIssueEndpoint_ShouldEditTheIssue()
        {
            // Arrange
            string newTitle = "Changed for the testing";
            var request = new RestRequest("repos/testnakov/test-nakov-repo/issues/10399");
            request.AddJsonBody(new
            {
                title = newTitle
            });

            // Act
            var response = client.Execute(request, Method.Patch);
            var issue = JsonConvert.DeserializeObject<Issue>(response.Content);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(issue.id, Is.GreaterThan(0), "Issue ID should be greater than 0");
            Assert.That(issue.number, Is.GreaterThan(0), "Issue number should be greater than 0");
            Assert.That(response.Content, Is.Not.Empty, "The reponse content should not be empty");
            Assert.That(issue.title, Is.EqualTo(newTitle));
        }

        public Issue CreateIssue(string title, string body)
        {
            var request = new RestRequest("/repos/testnakov/test-nakov-repo/issues", Method.Post);
            request.AddBody(new { body, title });
            var response = client.Execute(request);
            var issuesObject = JsonConvert.DeserializeObject<Issue>(response.Content);

            return issuesObject;
        }
    }
}