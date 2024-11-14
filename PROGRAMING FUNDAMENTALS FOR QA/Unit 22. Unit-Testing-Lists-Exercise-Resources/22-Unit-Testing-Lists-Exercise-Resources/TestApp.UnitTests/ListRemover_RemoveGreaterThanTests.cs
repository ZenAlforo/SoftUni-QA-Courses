using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class ListRemover_RemoveGreaterThanTests
{
    [Test]
    public void Test_RemoveElementsGreaterThan_EmptyListParameter_ReturnsEmptyList()
    {
        // Arrange
        List<int> list = new List<int>();
        int treshhold = 8;

        // Act
        List<int> result = ListRemover.RemoveElementsGreaterThan(list, treshhold);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_RemoveElementsGreaterThan_ListWithGreaterThanThresholdElements_ReturnsEmptyList()
    {
        // Arrange
        List<int> list = new List<int>() {9, 22, 34, 88};
        int treshhold = 8;

        // Act
        List<int> result = ListRemover.RemoveElementsGreaterThan(list, treshhold);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_RemoveElementsGreaterThan_ListWithLessThanOrEqualToThresholdElements_ReturnsSameList()
    {
        // Arrange
        List<int> list = new List<int>() { 4, 5, 99, 8};
        int treshhold = 99;
        List<int> expected = new() { 4, 5, 99, 8 };

        // Act
        List<int> result = ListRemover.RemoveElementsGreaterThan(list, treshhold);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RemoveElementsGreaterThan_ListWithLessThanEqualAndGreaterThanThresholdElements_ReturnsOnlyLessThanOrEqualToThreshold()
    {
        // Arrange
        List<int> list = new List<int>() { 4, 5, 99, 8 };
        int treshhold = 9;
        List<int> expected = new() { 4, 5, 8 };

        // Act
        List<int> result = ListRemover.RemoveElementsGreaterThan(list, treshhold);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
