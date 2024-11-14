using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class ListManipulationTests
{
    [Test]
    public void Test_RemoveNegativesAndReverse_EmptyListInput_ReturnEmptyList()
    {
        // Arrange
        List<int> emptyList = new() {};
        List<int> expected = new() {};

        // Act
        List<int> result = ListManipulation.RemoveNegativesAndReverse(emptyList);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_RemoveNegativesAndReverse_OnlyNegativeNumbers_ReturnEmptyList()
    {
        // Arrange
        List<int> emptyList = new() {-1, -4, -23 };
        List<int> expected = new() { };

        // Act
        List<int> result = ListManipulation.RemoveNegativesAndReverse(emptyList);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_RemoveNegativesAndReverse_OnlyOnePositiveNumber_ReturnSameCollection()
    {
        // Arrange
        List<int> emptyList = new() {-2, 3, -8 };
        List<int> expected = new() {3};

        // Act
        List<int> result = ListManipulation.RemoveNegativesAndReverse(emptyList);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_RemoveNegativesAndReverse_OnlyPositiveNumbers_ReturnRevursedList()
    {
        // Arrange
        List<int> emptyList = new() {5, 6, 7};
        List<int> expected = new() {7, 6, 5 };

        // Act
        List<int> result = ListManipulation.RemoveNegativesAndReverse(emptyList);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_RemoveNegativesAndReverse_PostiveAndNegativeElements_ReturnPositiveNumbersInReversedOrder()
    {
        // Arrange
        List<int> emptyList = new() {-4, 3, 0, 5 };
        List<int> expected = new() {5, 0, 3};

        // Act
        List<int> result = ListManipulation.RemoveNegativesAndReverse(emptyList);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
