using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ArticleTests
{

    private Article _currentArticle;

    [SetUp] 
    public void SetUp()
    {
        _currentArticle = new Article();
    }

    // TODO: finish test
    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        string[] input = { "Nestle Chocolate Ivan", "NachevShop Nuts Sonia", "Banitsa Pastry Asia" };

        // Act

        Article result = _currentArticle.AddArticles(input);

        // Assert
        Assert.That(result.ArticleList, Has.Count.EqualTo(3));
        Assert.That(result.ArticleList[0].Title, Is.EqualTo("Nestle"));
        Assert.That(result.ArticleList[1].Content, Is.EqualTo("Nuts"));
        Assert.That(result.ArticleList[2].Author, Is.EqualTo("Asia"));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        // Arrange
        string[] input = { "Nestle Chocolate Ivan", "NachevShop Nuts Sonia", "Banitsa Pastry Asia" };
        Article result = _currentArticle.AddArticles(input);

        string expected = $"Banitsa - Pastry: Asia{Environment.NewLine}" +
                          $"NachevShop - Nuts: Sonia{Environment.NewLine}" +
                          $"Nestle - Chocolate: Ivan";

        // Act
        string sortedArticleList = _currentArticle.GetArticleList(result, "title");

        // Assert
        Assert.That(sortedArticleList, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        // Arrange
        string[] input = { "Nestle Chocolate Ivan", "NachevShop Nuts Sonia", "Banitsa Pastry Asia" };
        string expected = string.Empty;

        // Act
        Article result = _currentArticle.AddArticles(input);
        string sortedArticleList = _currentArticle.GetArticleList(result, "Animals");

        // Assert
        Assert.That(sortedArticleList, Is.EqualTo(expected));
    }
}
