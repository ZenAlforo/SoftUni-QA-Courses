using NUnit.Framework;
using System;

namespace TestApp.Tests;

public class LongestIncreasingSubsequenceTests
{
    [Test]
    public void Test_GetLis_NullArray_ThrowsArgumentNullException()
    {
        // Arrange & Act
        int[] emptyArray = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => LongestIncreasingSubsequence.GetLis(emptyArray));
    }

    [Test]
    public void Test_GetLis_EmptyArray_ReturnsEmptyString()
    {
        // Arrange
        int[] emptyArray = Array.Empty<int>();
        string expected = string.Empty;

        // Act
        string result = LongestIncreasingSubsequence.GetLis(emptyArray);

        // Assert
        Assert.AreEqual(expected, result);
        Assert.IsEmpty(expected);
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_GetLis_SingleElementArray_ReturnsElement()
    {
        // Arrange
        int[] oneElementAray = { 1 };
        string expected = "1";
        
        // Act
        string result = LongestIncreasingSubsequence.GetLis(oneElementAray);

        // Assert
        Assert.AreEqual(expected, result);

    }

    [Test]
    public void Test_GetLis_UnsortedArray_ReturnsLongestIncreasingSubsequence()
    {
        // Arrange
        int[] oneElementAray = { 1, 8, 0, -1, 4 };
        string expected = "1 8";

        // Act
        string result = LongestIncreasingSubsequence.GetLis(oneElementAray);

        // Assert
        Assert.AreEqual(expected, result);

    }

    [Test]
    public void Test_GetLis_SortedArray_ReturnsItself()
    {
        // Arrange
        int[] oneElementAray = { 1, 2, 8, 11, 14 };
        string expected = "1 2 8 11 14";

        // Act
        string result = LongestIncreasingSubsequence.GetLis(oneElementAray);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
