using RestSharpServices;
using System.Net;
using System.Reflection.Emit;
using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using NUnit.Framework.Internal;
using RestSharpServices.Models;
using System;

namespace TestGitHubApi
{
    public class TestGitHubApi
    {
        private GitHubApiClient client;
        private static string repo;
        private string gitToken = Environment.GetEnvironmentVariable("MY_GITHUB_TOKEN");
        private static int lastCreatedIssueNumber;
        private static long lastCreatedCommentId;
        private static string lastCreatedCommentBody;

        [SetUp]
        public void Setup()

        {
            client = new GitHubApiClient("https://api.github.com/repos/testnakov/", "ZenAlforo", gitToken);
            repo = "test-nakov-repo";
        }

        [Test, Order(1)]
        public void Test_GetAllIssuesFromARepo()
        {
            // Arrange

            // Act
            var issues = client.GetAllIssues(repo);

            // Assert
            Assert.That(issues, Is.Not.Null, "Issues should not be null");
            Assert.That(issues.Count, Is.GreaterThan(1), "Issues should be more than 1");

            foreach (var issue in issues)
            {
                Assert.That(issue.Id, Is.GreaterThan(0), "Issues Id should be more than 0");
                Assert.That(issue.Number, Is.GreaterThan(0), "Issues Issue number should be more than 0");
                Assert.That(issue.Title, Is.Not.Empty.Or.Null, "Title should not be null or empty");
                Assert.That(issue.Body, Is.Not.Empty.Or.Null, "Body should not be null or empty");
            }
        }

        [Test, Order(2)]
        public void Test_GetIssueByValidNumber()
        {
            // Arrange
            var issueNumber = 10418;

            // Act
            var issue = client.GetIssueByNumber(repo, issueNumber);

            // Assert
            Assert.That(issue, Is.Not.Null, "The call was not successfull");

            Assert.That(issue.Id, Is.GreaterThan(0), "Issues Id should be more than 0");
            Assert.That(issue.Number, Is.EqualTo(issueNumber), "Issues Id should be more than 0");
            Assert.That(issue.Title, Is.Not.Empty.Or.Null, "Title should not be null or empty");
            Assert.That(issue.Body, Is.Not.Empty.Or.Null, "Body should not be null or empty");
        }

        [Test, Order(3)]
        public void Test_GetAllLabelsForIssue()
        {
            // Arrange
            var issueNumber = 6;

            // Act
            var labels = client.GetAllLabelsForIssue(repo, issueNumber);

            // Assert
            Assert.That(labels.Count, Is.GreaterThan(0), "The issue had no labels");
            Assert.That(labels, Is.Not.Null.And.Not.Empty, "The list of lables was not extracted and is empty");

            foreach (var label in labels)
            {
                Assert.That(label.Id, Is.GreaterThan(0), "The label Id should be greated than 0");
                Assert.That(label.Name, Is.Not.Null, "The label should have a name");

                Console.WriteLine($"Label ID: {label.Id} - Name: {label.Name}");
            }
        }

        [Test, Order(4)]
        public void Test_GetAllCommentsForIssue()
        {
            // Arrange
            var issueNumber = 6;

            // Act
            var comments = client.GetAllCommentsForIssue(repo, issueNumber);

            // Assert
            Assert.That(comments.Count, Is.GreaterThan(0), "The issue had no comments");
            Assert.That(comments, Is.Not.Null.And.Not.Empty, "The list of comments was not extracted and is empty");

            foreach (var comment in comments)
            {
                Assert.That(comment.Id, Is.GreaterThan(0), "The comments Id should be greated than 0");
                Assert.That(comment.Body, Is.Not.Null, "The comments should have a name");

                Console.WriteLine($"Label ID: {comment.Id} - Name: {comment.Body}");
            }
        }

        [Test, Order(5)]
        public void Test_CreateGitHubIssue()
        {
            // Arrange
            var issueTitle = "My neeext issue";
            var issueBody = "Ye, another one";

            // Act
            var issue = client.CreateIssue(repo, issueTitle, issueBody);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(issue);
                Assert.That(issue.Id, Is.GreaterThan(0), "Issue has to have ID greater than 0");
                Assert.That(issue.Number, Is.GreaterThan(0), "Issue has to have Number greater than 0");
                Assert.That(issue.Title, Is.Not.Empty, "Title should not be empty");
                Assert.That(issue.Title, Is.EqualTo(issueTitle), "Title has to be same as given upon creation");
                Assert.That(issue.Body, Is.EqualTo(issueBody), "Body has to be same as given upon creation");
            });

            Console.WriteLine(issue.Number);
            lastCreatedIssueNumber = issue.Number;
        }

        [Test, Order(6)]
        public void Test_CreateCommentOnGitHubIssue()
        {
            // Arraneg
            var newCommentBody = "Your issue has been reviewed and taken into consideration.";

            // Act
            var comment = client.CreateCommentOnGitHubIssue(repo, lastCreatedIssueNumber, newCommentBody);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(comment);
                Assert.That(comment.Id, Is.GreaterThan(0), "Issue has to have ID greater than 0");
                Assert.That(comment.Body, Is.Not.Empty, "Comment Body should not be empty");
                Assert.That(comment.Body, Is.EqualTo(newCommentBody), "Comment has to be same as given upon creation");
            });

            Console.WriteLine(comment.Id);
            lastCreatedCommentId = comment.Id;
            lastCreatedCommentBody = newCommentBody;
        }

        [Test, Order(7)]
        public void Test_GetCommentById()
        {
            // Arrange

            // Act
            var comment = client.GetCommentById(repo, lastCreatedCommentId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(comment);
                Assert.That(comment.Id, Is.EqualTo(lastCreatedCommentId), "Issue has to have ID same as called");
                Assert.That(comment.Body, Is.Not.Empty, "Comment Body should not be empty");
                Assert.That(comment.Body, Is.EqualTo(lastCreatedCommentBody), "Comment has to be same as given upon creation");
            });
        }

        [Test, Order(8)]
        public void Test_EditCommentOnGitHubIssue()
        {
            // Arrange
            var updatedCommentBody = "Hi, I am updated comment";

            // Act
            var comment = client.EditCommentOnGitHubIssue(repo, lastCreatedCommentId, updatedCommentBody);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(comment);
                Assert.That(comment.Id, Is.EqualTo(lastCreatedCommentId), "Issue has to have ID same as called");
                Assert.That(comment.Body, Is.Not.Empty, "Comment Body should not be empty");
                Assert.That(comment.Body, Is.EqualTo(updatedCommentBody), "Comment body is not the same as done");
            });
        }

        [Test, Order(9)]
        public void Test_DeleteCommentOnGitHubIssue()
        {
            // Arrange

            // Act
            var result = client.DeleteCommentOnGitHubIssue(repo, lastCreatedCommentId);

            // Assert
            Assert.True(result);
        }

        [Test, Order(10)]
        public void Test_GetCommentById_AfterDeletion_ShouldReturnNull()
        {
            var comment = client.GetCommentById(repo, lastCreatedCommentId);

            Assert.That(comment.Body, Is.Null, "Comment should not exist after deletion");
            Console.WriteLine(comment);
        }
    }
}