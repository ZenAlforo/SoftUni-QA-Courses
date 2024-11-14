using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class PatternTests
{
    [Test]
    public void Test_SortInPattern_SortsIntArrayInPattern_SortsCorrectly()
    {
        // Arrange
        int[] numbers = { 5, 19, 2, 34, 2, 4, 6 };
        int[] expected = { 2, 34, 4, 19, 5, 6 };

        // Act
        int[] result = Pattern.SortInPattern(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_SortInPattern_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        int[] numbers = { };
        int[] expected = { };

        // Act
        int[] result = Pattern.SortInPattern(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_SortInPattern_SingleElementArray_ReturnsSameArray()
    {
        // Arrange
        int[] numbers = { 5 };
        int[] expected = { 5 };

        // Act
        int[] result = Pattern.SortInPattern(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
