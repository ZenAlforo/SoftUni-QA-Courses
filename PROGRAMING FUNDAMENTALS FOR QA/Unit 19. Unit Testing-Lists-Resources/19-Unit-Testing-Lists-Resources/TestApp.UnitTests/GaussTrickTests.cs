using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class GaussTrickTests
{
    [Test]
    public void Test_SumPairs_InputIsEmptyList_ShouldReturnEmptyList()
    {
        // Arrange
        List<int> emptyList = new();
        List<int> expected = new();

        // Act
        List<int> result = GaussTrick.SumPairs(emptyList);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    // TODO: finish the test
    [Test]
    public void Test_SumPairs_InputHasSingleElement_ShouldReturnSameElement()
    {
        // Arrange
        List<int> ints = new List<int>() {8};
        List<int> expected = new() {8};
        // Act
        List<int> result = GaussTrick.SumPairs(ints);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    // TODO: finish the test
    [Test]
    public void Test_SumPairs_InputHasEvenCountElements_ShouldReturnSumPairs()
    {
        // Arrange
        List<int> myList = new List<int>() { 3, 4, 5, 6 };
        List<int> expected = new List<int>() {9, 9};

        // Act
        List<int> result = GaussTrick.SumPairs(myList);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_SumPairs_InputHasOddCountElements_ShouldReturnWithMiddleElement()
    {
        // Arrange
        List<int> intList = new List<int>() { 3, 5, 6, 7, 8 };
        List<int> expected = new List<int>() {11, 12, 6};

        // Act
        List<int> result = GaussTrick.SumPairs(intList);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_SumPairs_InputHasLargeEvenCountElements_ShouldReturnSumPairs()
    {
        // Arrange
        List<int> myList = new List<int>() {20, 40, 60, 80, 80, 80 };
        List<int> expected = new List<int>() {100, 120, 140};

        // Act
        List<int> result = GaussTrick.SumPairs(myList);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_SumPairs_InputHasLargeOddCountElements_ShouldReturnWithMiddleElement()
    {
        // Arrange
        List<int> myList = new List<int>() { 20, 40, 60, 80, 80, 80, 90 };
        List<int> expected = new List<int>() { 110, 120, 140, 80 };

        // Act
        List<int> result = GaussTrick.SumPairs(myList);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }
}
