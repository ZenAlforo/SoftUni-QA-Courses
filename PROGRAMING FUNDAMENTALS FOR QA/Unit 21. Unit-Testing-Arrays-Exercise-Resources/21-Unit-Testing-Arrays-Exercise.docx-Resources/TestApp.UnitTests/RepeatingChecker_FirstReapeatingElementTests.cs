using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class RepeatingChecker_FirstReapeatingElementTests
{
    [Test]
    public void Test_FindFirstRepeatingElement_EmptyArray_ReturnsNegativeOne()
    {
        // Arrange
        int[] ints = {};
        int expected = -1;

        // Act
        int result = RepeatingChecker.FindFirstRepeatingElement(ints);


        // Assert
        Assert.AreEqual(expected, result);

    }

    [Test]
    public void Test_FindFirstRepeatingElement_ArrayWithOneInteger_ReturnsNegativeOne()
    {
        // Arrange
        int[] ints = { 3 };
        int expected = -1;

        // Act
        int result = RepeatingChecker.FindFirstRepeatingElement(ints);


        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindFirstRepeatingElement_ArrayWithManyNonRepeatingValues_ReturnsNegativeOne()
    {
        // Arrange
        int[] ints = {2, 4, 5, 6, -3, 11};
        int expected = -1;

        // Act
        int result = RepeatingChecker.FindFirstRepeatingElement(ints);


        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindFirstRepeatingElement_ArrayWithTwoReapeatingNegativeOneValue_ReturnsNegativeOne()
    {
        // Arrange
        int[] ints = { -1, -1, 4, 5};
        int expected = -1;

        // Act
        int result = RepeatingChecker.FindFirstRepeatingElement(ints);


        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindFirstRepeatingElement_ArrayWithManyIntegerWithSameValues_ReturnsTheIntegerValue()
    {
        // Arrange
        int[] ints = { 3, 3, 3, 3, 3, 3 };
        int expected = 3;

        // Act
        int result = RepeatingChecker.FindFirstRepeatingElement(ints);


        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindFirstRepeatingElement_ArrayWithAtLeastTwoReaptingValues_ReturnsTheRepeatingValue()
    {
        // Arrange
        int[] ints = { 3, 4, 5, 2, 8, 9, 2, 4 };
        int expected = 2;

        // Act
        int result = RepeatingChecker.FindFirstRepeatingElement(ints);


        // Assert
        Assert.AreEqual(expected, result);
    }
}
