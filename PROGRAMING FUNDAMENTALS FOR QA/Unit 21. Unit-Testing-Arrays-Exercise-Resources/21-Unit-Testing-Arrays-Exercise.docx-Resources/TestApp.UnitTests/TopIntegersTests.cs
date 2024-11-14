using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class TopIntegersTests
{
    [Test]
    public void Test_FindTopIntegers_EmptyArrayParameter_ReturnEmptyString()
    {
        // Arrange
        int[] numbers = { };
        string expected = "";
        TopIntegers tops = new TopIntegers();

        // Act
        string result = tops.FindTopIntegers(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindTopIntegers_AllElementsAreTopIntegers_ReturnStringWithAllElements()
    {
        // Arrange
        int[] numbers = { 100, 60, 44, 12, 5};
        string expected = "100 60 44 12 5";
        TopIntegers tops = new TopIntegers();

        // Act
        string result = tops.FindTopIntegers(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindTopIntegers_OnlyOneElementArray_ReturnStringWithOneInteger()
    {
        // Arrange
        int[] numbers = { 3 };
        string expected = "3";
        TopIntegers tops = new TopIntegers();

        // Act
        string result = tops.FindTopIntegers(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindTopIntegers_OnlySomeElementsAreTopIntegers_ReturnStringWithOnlyTopIntegers()
    {
        // Arrange
        int[] numbers = {3, 12, 3, 18, 340, 2, -45};
        string expected = "340 2 -45";
        TopIntegers tops = new TopIntegers();

        // Act
        string result = tops.FindTopIntegers(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}

