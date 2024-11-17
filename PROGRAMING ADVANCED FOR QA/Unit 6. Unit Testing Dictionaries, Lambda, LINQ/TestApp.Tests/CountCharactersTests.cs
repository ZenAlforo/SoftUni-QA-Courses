using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.Tests;

public class CountCharactersTests
{
    [Test]
    public void Test_Count_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new();

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_Count_WithNoCharacters_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new() { "", "", ""};

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Count_WithSingleCharacter_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new() { "q", "b", "c"};
        string expected = $"q -> 1{Environment.NewLine}b -> 1{Environment.NewLine}c -> 1";

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithMultipleCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new() { "queue", "q"};
        string expected = $"q -> 2{Environment.NewLine}u -> 2{Environment.NewLine}e -> 2";

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithSpecialCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new() { "#filadelfia" };
        string expected = $"" +
            $"# -> 1{Environment.NewLine}" +
            $"f -> 2{Environment.NewLine}" +
            $"i -> 2{Environment.NewLine}" +
            $"l -> 2{Environment.NewLine}" +
            $"a -> 2{Environment.NewLine}" +
            $"d -> 1{Environment.NewLine}" +
            $"e -> 1";

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
