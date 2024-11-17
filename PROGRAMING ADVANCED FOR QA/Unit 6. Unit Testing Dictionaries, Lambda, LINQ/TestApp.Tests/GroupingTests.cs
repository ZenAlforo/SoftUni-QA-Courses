using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.Tests;

public class GroupingTests
{
    // TODO: finish test
    [Test]
    public void Test_GroupNumbers_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<int> list = new List<int>();

        // Act
        string result = Grouping.GroupNumbers(list);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_GroupNumbers_WithEvenAndOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> list = new List<int>() { 1, 4, 56, 7, 8};
        string expected = $"Odd numbers: 1, 7{Environment.NewLine}Even numbers: 4, 56, 8";
        // Act
        string result = Grouping.GroupNumbers(list);

        // Assert
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Test_GroupNumbers_WithOnlyEvenNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> list = new List<int>() { 10, 4, 56, 70, 8 };
        string expected = $"Even numbers: 10, 4, 56, 70, 8";
        // Act
        string result = Grouping.GroupNumbers(list);

        // Assert
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Test_GroupNumbers_WithOnlyOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> list = new List<int>() { 1, 41, 561, 701, 85 };
        string expected = $"Odd numbers: 1, 41, 561, 701, 85";
        // Act
        string result = Grouping.GroupNumbers(list);

        // Assert
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Test_GroupNumbers_WithNegativeNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> list = new List<int>() { -1, -4, -561, -70, -85 };
        string expected = $"Odd numbers: -1, -561, -85{Environment.NewLine}Even numbers: -4, -70";
        // Act
        string result = Grouping.GroupNumbers(list);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
