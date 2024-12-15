using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

public class DigitsExtractorTests
{
    [Test]
    public void Test_FindDigits_EmptyStringInput_ReturnsNoDigitsMessage()
    {
        // Arrange
        string input = string.Empty;
        string expected = "No digits!";

        // Act
        string result = DigitsExtractor.FindDigits(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindDigits_NoDIgitsInput_ReturnsNoDigitsMessage()
    {
        // Arrange
        string input = "The big bad wolf";
        string expected = "No digits!";

        // Act
        string result = DigitsExtractor.FindDigits(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindDigits_OnlyDigitsStringInpput_ReturnsSameDigitsString()
    {
        // Arrange
        string input = "1984";
        string expected = "1984";

        // Act
        string result = DigitsExtractor.FindDigits(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindDigits_DigitsAndLetters_ReturnsOnlyDigits()
    {
        // Arrange
        string input = "The big bad wolf was 20 years old";
        string expected = "20";

        // Act
        string result = DigitsExtractor.FindDigits(input);

        // Assert
        Assert.IsTrue(expected.Equals(result));
    }
}

