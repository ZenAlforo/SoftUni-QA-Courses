using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class OddOccurrencesTests
{
    [Test]
    public void Test_FindOdd_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] words = { };
        string expected = "";

        // Act
        string result = OddOccurrences.FindOdd(words);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }


    [Test]
    public void Test_FindOdd_WithNoOddOccurrences_ShouldReturnEmptyString()
    {
        // Arrange
        string[] words = { "cat", "bird", "cat", "Bird"};
        string expected = "";

        // Act
        string result = OddOccurrences.FindOdd(words);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindOdd_WithSingleOddOccurrence_ShouldReturnTheOddWord()
    {
        // Arrange
        string[] words = { "cat", "cat", "dog", "bird", "dog"};
        string expected = "bird";

        // Act
        string result = OddOccurrences.FindOdd(words);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindOdd_WithMultipleOddOccurrences_ShouldReturnAllOddWords()
    {
        // Arrange
        string[] words = { "cat", "mouse", "dog", "bird" };
        string expected = "cat mouse dog bird";

        // Act
        string result = OddOccurrences.FindOdd(words);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindOdd_WithMixedCaseWords_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] words = { "cat", "mOuse", "Dog", "cat" };
        string expected = "mouse dog";

        // Act
        string result = OddOccurrences.FindOdd(words);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
