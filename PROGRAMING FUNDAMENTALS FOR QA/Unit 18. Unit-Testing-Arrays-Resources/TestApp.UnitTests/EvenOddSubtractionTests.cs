using NUnit.Framework;

using System;
using System.Security.Cryptography;

namespace TestApp.UnitTests;

public class EvenOddSubtractionTests
{
    [Test]
    public void Test_FindDifference_InputIsEmpty_ShouldReturnZero()
    {
        // Arrange
        int[] emptyArray = Array.Empty<int>();

        // Act
        int result = EvenOddSubtraction.FindDifference(emptyArray);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    // TODO: finish the test
    [Test]
    public void Test_FindDifference_InputHasOnlyEvenNumbers_ShouldReturnEvenSum()
    {
        // Arrange
        int[] evenNumbersOnly = new int[] { 2, 4, 6, 8 };
        int expected = 20;

        // Act
        int result = EvenOddSubtraction.FindDifference(evenNumbersOnly);

        // Assert
        Assert.That(result, Is.EqualTo(expected), "Result is not as expected");
    }

    [Test]
    public void Test_FindDifference_InputHasOnlyOddNumbers_ShouldReturnNegativeOddSum()
    {
        // Arrange
        int[] oddsOnlyArray = new int[] { 1, 3, 5, 9 };
        int expected = -18;

        // Act
        int result = EvenOddSubtraction.FindDifference(oddsOnlyArray);

        // Assert
        Assert.That(result, Is.EqualTo(expected), "There was an error in result");
    }

    [Test]
    public void Test_FindDifference_InputHasMixedNumbers_ShouldReturnDifference()
    {
        // Arrange
        int[] mixedNumArrays = new int[] { 2, 3, -5, 8, -10, 15};
        int expected = -13;

        // Act
        int result = EvenOddSubtraction.FindDifference(mixedNumArrays);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
