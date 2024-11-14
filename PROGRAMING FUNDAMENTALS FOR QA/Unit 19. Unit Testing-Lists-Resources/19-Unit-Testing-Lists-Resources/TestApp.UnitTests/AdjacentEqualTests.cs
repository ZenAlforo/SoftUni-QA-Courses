using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class AdjacentEqualTests
{
    // TODO: finish test
    [Test]
    public void Test_Sum_InputIsEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<int> emptyList = new();
        string expected = string.Empty;

        // Act
        string result = AdjacentEqual.Sum(emptyList);

        // Assert
        Assert.AreEqual(expected, result);
    }

    // TODO: finish test
    [Test]
    public void Test_Sum_NoAdjacentEqualNumbers_ShouldReturnOriginalList()
    {
        // Arrange
        List<int> myList = new List<int> { 1, 2, 3, 4, 6};
        string expected = "1 2 3 4 6";

        // Act
        string result = AdjacentEqual.Sum(myList);

        // Assert
        Assert.AreEqual(expected, result);
        
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersExist_ShouldReturnSummedList()
    {
        // Arrange
        List<int> myList = new List<int> { 1, 3, 3, 4, 6, 6, 7 };
        string expected = "1 6 4 12 7";

        // Act
        string result = AdjacentEqual.Sum(myList);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Sum_AllNumbersAreAdjacentEqual_ShouldReturnSingleSummedNumber()
    {
        // Arrange
        List<int> myList = new List<int> { 1, 1, 1, 1 };
        string expected = "4";

        // Act
        string result = AdjacentEqual.Sum(myList);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersAtBeginning_ShouldReturnSummedList()
    {
        // Arrange
        List<int> myList = new List<int>{ 1, 1, 3, 4, 5, 6 };
        string expected = "2 3 4 5 6";

        // Act
        string result = AdjacentEqual.Sum(myList);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersAtEnd_ShouldReturnSummedList()
    {
        // Arrange
        List<int> myList = new List<int>() { 1, 2, 3, 4, 5, 6, 6 };
        string expected = "1 2 3 4 5 12";

        // Act
        string result = AdjacentEqual.Sum(myList);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersInMiddle_ShouldReturnSummedList()
    {
        // Arrange
        List<int> myList = new List<int> { 1, 2, 3, 3, 4, 5, 6 };
        string expected = "1 2 6 4 5 6";

        // Act
        string result = AdjacentEqual.Sum(myList);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
