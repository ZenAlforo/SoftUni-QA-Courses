using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class MatchUrlsTests
{
    // TODO: finish the test
    [Test]
    public void Test_ExtractUrls_EmptyText_ReturnsEmptyList()
    {
        // Arrange
        string text = "";

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);


        // Assert
        Assert.IsTrue(result.Count == 0);
    }

    // TODO: finish the test
    [Test]
    public void Test_ExtractUrls_NoUrlsInText_ReturnsEmptyList()
    {
        // Arrange
        string text = "there was a night when...";

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_ExtractUrls_SingleUrlInText_ReturnsSingleUrl()
    {
        // Arrange
        string text = "https://softuni.bg/trainings/resources/video/107154/video-07-november-2024-diyan-apostolov-programming-advanced-for-qa-november-2024/4724";

        // Act
        List<string> expected = new List<string> { "https://softuni.bg"};
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ExtractUrls_MultipleUrlsInText_ReturnsAllUrls()
    {
        // Arrange
        string text = "https://softuni.bg https://www.youtube.com and other urls";

        // Act
        List<string> expected = new List<string> { "https://softuni.bg" , "https://www.youtube.com" };
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ExtractUrls_UrlsInQuotationMarks_ReturnsUrlsInQuotationMarks()
    {
        // Arrange
        string text = "\"https://softuni.bg\" https://www.youtube.com and other urls";

        // Act
        List<string> expected = new List<string> { "" +
            "https://softuni.bg", "https://www.youtube.com" };
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
