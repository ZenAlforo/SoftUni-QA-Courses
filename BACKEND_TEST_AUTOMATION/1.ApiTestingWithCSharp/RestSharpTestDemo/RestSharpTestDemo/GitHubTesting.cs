using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Text.Json.Nodes;

namespace RestSharpTestDemo
{
    public class GitHubTesting
    {
        private RestClient _client;

        //private Issue issue;
        private string myToken = Environment.GetEnvironmentVariable("MY_GITHUB_TOKEN");

        [SetUp]
        public void Setup()
        {
            var options = new RestClientOptions("https://api.github.com")
            {
                Authenticator = new HttpBasicAuthenticator("ZenAlforo", myToken),
                Timeout = TimeSpan.FromMilliseconds(3000)
            };

            _client = new RestClient(options);
        }

        [Test]
        public void Test_GitHubAPIGet_ShouldRetrieveStatusCode200()
        {
            // Arrange
            var request = new RestRequest("/repos/testnakov/test-nakov-repo/issues", Method.Get);
            request.Timeout = TimeSpan.FromSeconds(1);
            // Act
            var response = _client.Execute(request);

            // Assert
            Assert.IsNotNull(response, "The response is null");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The Status code is no as expected");
        }

        [Test]
        public void Test_GitHubAPIGetIssues_ShouldGelAllIssues()
        {
            // Arrange
            var request = new RestRequest("/repos/testnakov/test-nakov-repo/issues", Method.Get);
            request.Timeout = TimeSpan.FromSeconds(1);
            // Act
            var response = _client.Execute(request);
            var issues = JsonConvert.DeserializeObject<List<Issue>>(response.Content);

            // Assert
            Assert.IsNotNull(response, "The response is null");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The Status code is no as expected");
            Assert.That(issues.Count > 0, "the issues list is empty");

            foreach (var issue in issues)
            {
                Assert.That(issue.id, Is.GreaterThan(0), "the id of the issue is not correct");
                Assert.That(issue.number, Is.GreaterThan(0), "the number of the issue is not correct");
                Assert.That(issue.title, Is.Not.Empty, "the issue has no title");
            }
        }

        [Test]
        public void Test_GitHubApiCreateIssue_ShouldCreateIssue()
        {
            // Arrange
            string title = "My second try";
            string body = "Yesterday I deleted my issue, so this is my second issue";

            // Act
            var issue = CreateIssue(title, body);

            // Assert
            Assert.That(issue.id, Is.GreaterThan(0), "the id of the issue is not correct");
            Assert.That(issue.number, Is.GreaterThan(0), "the number of the issue is not correct");
            Assert.That(issue.title, Is.Not.Empty, "the issue has no title");
        }

        [Test]
        public void Test_GitHubApiEditIssue_ShouldBeSuccessful()
        {
            // Arrange
            var request = new RestRequest("/repos/testnakov/test-nakov-repo/issues/10401");
            request.AddJsonBody(new
            {
                title = "Just changed my issue title"
            });

            // Act
            var response = _client.Execute(request, Method.Patch);
            var issue = JsonConvert.DeserializeObject<Issue>(response.Content);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The status code was not 200");
            Assert.That(response.Content, Is.Not.Empty, "The body is empty");
            Assert.That(issue.id, Is.GreaterThan(0), "the id of the issue is not correct");
            Assert.That(issue.number, Is.GreaterThan(0), "the number of the issue is not correct");
            Assert.That(issue.title, Is.Not.Empty, "the issue has no title");
        }

        private Issue CreateIssue(string title, string body)
        {
            var request = new RestRequest("/repos/testnakov/test-nakov-repo/issues");
            request.AddBody(new { body, title });
            var response = _client.Execute(request, Method.Post);
            var issue = JsonConvert.DeserializeObject<Issue>(response.Content);
            return issue;
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
        }
    }
}