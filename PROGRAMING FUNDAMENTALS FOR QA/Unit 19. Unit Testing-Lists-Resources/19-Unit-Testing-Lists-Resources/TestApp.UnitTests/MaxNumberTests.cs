using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class MaxNumberTests
{

    [Test]
    public void Test_FindMax_InputHasOneElement_ShouldReturnTheElement()
    {
        // Arrange
        List<int> myList = new List<int>() {22};
        int expected = 22;

        // Act
        int result = MaxNumber.FindMax(myList);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindMax_InputHasPositiveIntegers_ShouldReturnMaximum()
    {
        // Arrange
        List<int> myList = new List<int>() { 20, 40, 50, 60 };
        int expected = 60;

        // Act
        int result = MaxNumber.FindMax(myList);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindMax_InputHasNegativeIntegers_ShouldReturnMaximum()
    {
        // Arrange
        List<int> myList = new List<int>() { -20, -40, -55, };
        int expected = -20;

        // Act
        int result = MaxNumber.FindMax(myList);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindMax_InputHasMixedIntegers_ShouldReturnMaximum()
    {
        // Arrange
        List<int> myList = new List<int>() { -22, 9, 33, 0, 37, -222 };
        int expected = 37;

        // Act
        int result = MaxNumber.FindMax(myList);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindMax_InputHasDuplicateMaxValue_ShouldReturnMaximum()
    {
        // Arrange
        List<int> myList = new List<int>() { -22, -22, -3, 0, 22, 22 };
        int expected = 22;

        // Act
        int result = MaxNumber.FindMax(myList);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
