using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

public class LongestStringFinderTests
{

    [Test]
    public void Test_GetLongestString_EmptyList_ReturnsEmptyString()
    {
        // Arrange
        List<string> list = new List<string>();

        // Act
        string result = LongestStringFinder.GetLongestString(list);

        // Assert
        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_GetLongestString_NullList_ReturnsEmptyString()
    {
        // Arrange
        List<string> list = null;

        // Act
        string result = LongestStringFinder.GetLongestString(list);

        // Assert
        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_GetLongestString_OneElementInList_ReturnsThisWordAsString()
    {
        // Arrange
        List<string> list = new List<string>() {"ok"};
        string expected = "ok";

        // Act
        string result = LongestStringFinder.GetLongestString(list);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetLongestString_ManyWordWithDiffrentLength_ReturnsLongestWord()
    {
        // Arrange
        List<string> list = new List<string>() { "ok", "cat", "strong", "moon", "concatenation" };
        string expected = "concatenation";

        // Act
        string result = LongestStringFinder.GetLongestString(list);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetLongestString_ManyWordWithSameLength_ReturnsFirstWordOfThem()
    {
        // Arrange
        List<string> list = new List<string>() { "not", "cat", "dog", "has", "con" };
        string expected = "not";

        // Act
        string result = LongestStringFinder.GetLongestString(list);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
