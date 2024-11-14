using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ReverserTests
{
    [Test]
    public void Test_ReverseStrings_WithEmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        string[] inputArray = Array.Empty<string>();

        // Act
        string[] result = Reverser.ReverseStrings(inputArray);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_ReverseStrings_WithSingleString_ReturnsReversedString()
    {
        // Arrange
        string[] inputArray = { "Hello" };

        // Act
        string[] result = Reverser.ReverseStrings(inputArray);

        // Assert
        Assert.That(result, Is.EqualTo(new[] { "olleH" }));
    }

    [Test]
    public void Test_ReverseStrings_WithMultipleStrings_ReturnsReversedStrings()
    {
        // Arrange
        string[] inputArray = { "Hello", "Soft", "Uni" };
        string[] expectedResult = { "olleH", "tfoS", "inU" };
        // Act
        string[] result = Reverser.ReverseStrings(inputArray);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void Test_ReverseStrings_WithSpecialCharacters_ReturnsReversedSpecialCharacters()
    {
        // Arrange
        string[] inputArray = { "Hello_81", "Soft", "Uni" };
        string[] expectedResult = { "18_olleH", "tfoS", "inU" };
        // Act
        string[] result = Reverser.ReverseStrings(inputArray);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}
