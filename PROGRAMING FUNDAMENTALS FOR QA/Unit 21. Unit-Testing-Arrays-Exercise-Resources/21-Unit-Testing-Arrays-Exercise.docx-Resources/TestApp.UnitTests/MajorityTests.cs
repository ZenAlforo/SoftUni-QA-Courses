using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class MajorityTests
{
    [Test]
    public void Test_IsEvenOrOddMajority_EmpryArray_ReturnsZero()
    {
        // Arrange
        int[] ints = {};

        // Act
        int result = Majority.IsEvenOrOddMajority(ints);

        // Assert
        Assert.That(result, Is.Zero);
    }

    [Test]
    public void Test_IsEvenOrOddMajority_ArrayOnlyWithZeros_ReturnsZero()
    {
        // Arrange
        int[] ints = {0, 0, 0, 0 };

        // Act
        int result = Majority.IsEvenOrOddMajority(ints);

        // Assert
        Assert.That(result, Is.Zero);
    }

    [Test]
    public void Test_IsEvenOrOddMajority_EqualOddAndEvenNumbers_ReturnsZero()
    {
        // Arrange
        int[] ints = {2, 3, 4, 5, 6, 7 };
        int expected = 0;

        // Act
        int result = Majority.IsEvenOrOddMajority(ints);

        // Assert
        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void Test_IsEvenOrOddMajority_EvenMajority_ReturnsPositiveNumber()
    {
        // Arrange
        int[] ints = { 2, 3, 4, 5, 6, 7, 8, -10};
        int expected = 2;

        // Act
        int result = Majority.IsEvenOrOddMajority(ints);

        // Assert
        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void Test_IsEvenOrOddMajority_OddMajority_ReturnsNegativeNumber()
    {
        // Arrange
        int[] ints = { 2, 3, 4, 5, 6, 7, 3, -11 };
        int expected = -2;

        // Act
        int result = Majority.IsEvenOrOddMajority(ints);

        // Assert
        Assert.That(expected, Is.EqualTo(result));
    }
}
