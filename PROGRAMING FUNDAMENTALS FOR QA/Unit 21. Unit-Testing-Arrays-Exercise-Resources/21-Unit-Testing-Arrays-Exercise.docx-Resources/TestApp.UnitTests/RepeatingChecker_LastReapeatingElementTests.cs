using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class RepeatingChecker_LastReapeatingElementTests
{
    [Test]
    public void Test_FindLastRepeatingElement_EmptyArray_ReturnsNegativeOne()
    {
        // Arrange
        int[] ints = { };
        int expected = -1;

        // Act
        int result = RepeatingChecker.FindLastRepeatingElement(ints);


        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindLastRepeatingElement_ArrayWithOneInteger_ReturnsNegativeOne()
    {
        // Arrange
        int[] ints = { 3 };
        int expected = -1;

        // Act
        int result = RepeatingChecker.FindLastRepeatingElement(ints);


        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindLastRepeatingElement_ArrayWithManyNonRepeatingValues_ReturnsNegativeOne()
    {
        // Arrange
        int[] ints = { 2, 3, 4, 5};
        int expected = -1;

        // Act
        int result = RepeatingChecker.FindLastRepeatingElement(ints);


        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindLastRepeatingElement_ArrayWithTwoReapeatingNegativeOneValue_ReturnsNegativeOne()
    {
        // Arrange
        int[] ints = { -1, -1 };
        int expected = -1;

        // Act
        int result = RepeatingChecker.FindLastRepeatingElement(ints);


        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindLastRepeatingElement_ArrayWithManyIntegerWithSameValues_ReturnsTheIntegerValue()
    {
        // Arrange
        int[] ints = { 3, 3, 3, 3 };
        int expected = 3;

        // Act
        int result = RepeatingChecker.FindLastRepeatingElement(ints);


        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindLastRepeatingElement_ArrayWithAtLeastTwoRepeatingValues_ReturnsTheRepeatingValue()
    {
        // Arrange
        int[] ints = {2, 3, 4, 5, 6, 6, 7, 8, 9, 10, 9};
        int expected = 9;

        // Act
        int result = RepeatingChecker.FindLastRepeatingElement(ints);


        // Assert
        Assert.AreEqual(expected, result);
    }
}
