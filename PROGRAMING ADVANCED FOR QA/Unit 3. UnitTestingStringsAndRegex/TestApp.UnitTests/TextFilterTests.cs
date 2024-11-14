using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class TextFilterTests
{
    // TODO: finish the test
    [Test]
    public void Test_Filter_WhenNoBannedWords_ShouldReturnOriginalText()
    {
        // Arrange
        string[] bannedWords = new string[] { };
        string text = "I am professional gamer and one day I will win the league's world cup";

        // Act
        string result = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(result, Is.EqualTo(text));
    }

    [Test]
    public void Test_Filter_WhenBannedWordExists_ShouldReplaceBannedWordWithAsterisks()
    {
        // Arrange
        string[] bannedWords = new string[] { "gamer", "cup"};
        string text = "I am professional gamer and one day I will win the league's world cup";
        string expected = "I am professional ***** and one day I will win the league's world ***";

        // Act
        string result = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsAreEmpty_ShouldReturnOriginalText()
    {
        // Arrange
        string[] bannedWords = new string[] { "    ", "        " };
        string text = "I am professional gamer and one day I will win the league's world cup";
        string expected = "I am professional gamer and one day I will win the league's world cup";

        // Act
        string result = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsContainWhitespace_ShouldReplaceBannedWord()
    {
        // Arrange
        string[] bannedWords = new string[] { "gamer ", " cup" };
        string text = "I am professional gamer and one day I will win the league's world cup";
        string expected = "I am professional ******and one day I will win the league's world****";

        // Act
        string result = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
