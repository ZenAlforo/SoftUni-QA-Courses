using System;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestApp.Tests;

public class DigitAndSymbolCounterTests
{

    [Test]
    public void Test_EmptyStringInput_ReturnsEmptyDictionary()
    {
        // Arrange
        string input = "";
        Dictionary<string, int> expected = new Dictionary<string, int>();

        // Act
        Dictionary<string, int> result = DigitAndSymbolCounter.CountDigitsAndSymbols(input);

        // Assert
        Assert.NotNull(result);
        Assert.That(result, Is.Empty);
        Assert.IsEmpty(result);
        Assert.That(result.Count, Is.EqualTo(0));
        Assert.AreEqual(expected, result);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_NoDigitsStringInput_ReturnsOnlyNonDigitsCount()
    {
        // Arrange
        string input = "My name is George!";
        Dictionary<string, int> expected = new Dictionary<string, int>()
        {
            { "non-digit symbol", 18 }
        };

        // Act
        Dictionary<string, int> result = DigitAndSymbolCounter.CountDigitsAndSymbols(input);


        // Assert
        Assert.NotNull(result);
        Assert.IsNotEmpty(result);
        Assert.That(result, Is.EqualTo(expected));
        Assert.That(result["non-digit symbol"], Is.EqualTo(input.Length));
    }

    [Test]
    public void Test_NoOddDigitsStringInput_ReturnsOnlyEvenDigitsAndNonDigitsCount()
    {
        // Arrange
        string input = "I am 22 years old.";
        Dictionary<string, int> expected = new Dictionary<string, int>()
        {
            { "even digit", 2 },
            { "non-digit symbol", 16 }
        };

        // Act
        Dictionary<string, int> result = DigitAndSymbolCounter.CountDigitsAndSymbols(input);

        // Assert
        Assert.NotNull(result);
        Assert.IsNotEmpty(result);
        CollectionAssert.AreEquivalent(expected, result);
    }

    [Test]
    public void Test_NoEvenDigitsStringInput_ReturnsOnlyOddDigitsAndNonDigitsCount()
    {
        // Arrange
        string input = "I have travelled for 17 years.";
        Dictionary<string, int> expected = new Dictionary<string, int>()
        {
            { "odd digit", 2 },
            { "non-digit symbol", 28 }
        };

        // Act
        Dictionary<string, int> result = DigitAndSymbolCounter.CountDigitsAndSymbols(input);


        // Assert
        Assert.NotNull(result);
        Assert.IsNotEmpty(result);
        Assert.That(result, Is.EqualTo(expected));
        Assert.That(result["non-digit symbol"], Is.EqualTo(input.Length - 2));
        Assert.That(result["odd digit"], Is.EqualTo(2));
    }

    [Test]
    public void Test_SymbolsEvenAndOddDigitsStringInput_ReturnsAllTypeOfCounts()
    {
        // Arrange
        string input = "I have lived for 61 years and I've travelled the world for 17 years.";
        Dictionary<string, int> expected = new Dictionary<string, int>()
        {
            { "even digit", 1 },
            { "odd digit", 3 },
            { "non-digit symbol", 64 }
        };

        // Act
        Dictionary<string, int> result = DigitAndSymbolCounter.CountDigitsAndSymbols(input);

        // Assert
        Assert.NotNull(result);
        Assert.IsNotEmpty(result);
        Assert.That(result, Is.EqualTo(expected));
        Assert.That(result["non-digit symbol"], Is.EqualTo(input.Length - 4));
        Assert.That(result["odd digit"], Is.EqualTo(3));
        Assert.That(result["even digit"], Is.EqualTo(1));
    }
}