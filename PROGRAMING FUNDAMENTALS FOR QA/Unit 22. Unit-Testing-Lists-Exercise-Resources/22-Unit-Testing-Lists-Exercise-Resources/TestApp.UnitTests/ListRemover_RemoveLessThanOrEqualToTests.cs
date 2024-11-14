using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class ListRemover_RemoveLessThanOrEqualToTests
{
    [Test]
    public void Test_RemoveElementsLessThanOrEqualTo_EmptyListParameter_ReturnsEmptyList()
    {
        // Arrange
        List<int> list = new List<int>() ;
        int treshhold = 99;
        List<int> expected = new();

        // Act
        List<int> result = ListRemover.RemoveElementsLessThanOrEqualTo(list, treshhold);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RemoveElementsLessThanOrEqualTo_ListWithLessThanOrEqualToThresholdElements_ReturnsEmtyList()
    {
        // Arrange
        List<int> list = new List<int>() { 5, 77, 8, 99};
        int treshhold = 99;
        List<int> expected = new();

        // Act
        List<int> result = ListRemover.RemoveElementsLessThanOrEqualTo(list, treshhold);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RemoveElementsLessThanOrEqualTo_ListWithOnlyGreaterThanThresholdElements_ReturnsSameList()
    {
        // Arrange
        List<int> list = new List<int>() { 101, 222, 898};
        int treshhold = 99;
        List<int> expected = new() { 101, 222, 898 };

        // Act
        List<int> result = ListRemover.RemoveElementsLessThanOrEqualTo(list, treshhold);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RemoveElementsLessThanOrEqualTo_ListWithLessThanEqualAndGreaterThanThresholdElements_ReturnsOnlyGreaterThanThreshold()
    {
        // Arrange
        List<int> list = new List<int>() { 101, 22, 898, -22 };
        int treshhold = 99;
        List<int> expected = new() { 101, 898 };

        // Act
        List<int> result = ListRemover.RemoveElementsLessThanOrEqualTo(list, treshhold);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
