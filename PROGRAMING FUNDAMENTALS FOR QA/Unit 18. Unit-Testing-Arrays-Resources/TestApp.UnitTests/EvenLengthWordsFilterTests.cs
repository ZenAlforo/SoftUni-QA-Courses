using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class EvenLengthWordsFilterTests
{
    [Test]
    public void Test_GetEvenWords_InputArrayWithEmptyStrings_ShouldReturnEmptyString()
    {
        // Arrange
        string[] text = new string[0];
        string expected = string.Empty;

        // Act
        string actual = EvenLengthWordsFilter.GetEvenWords(text);

        // Assert
        Assert.AreEqual(expected, actual, "There was an error in executing and displaying the right result");
    }

    [Test]
    public void Test_GetEvenWords_InputArrayWithOneOddLengthWord_ShouldReturnEmptyString()
    {
        // Arrange
        string[] text = new string[] {"kotka"};
        string expected = string.Empty;

        // Act
        string actual = EvenLengthWordsFilter.GetEvenWords(text);

        // Assert
        Assert.AreEqual(expected, actual, "The program did not sort the words correctly");
    }

    [Test]
    public void Test_GetEvenWords_InputArrayOnlyWithOddLengthWords_ShouldReturnEmptyString()
    {
        // Arrange
        string[] text = new string[] {"kotka", "Chete", "Kniga"};
        string expected = string.Empty;

        // Act
        string actual = EvenLengthWordsFilter.GetEvenWords(text);

        // Assert
        Assert.AreEqual(expected, actual, "There was an error in executing and displaying the right result");
    }

    [Test]
    public void Test_GetEvenWords_InputArrayWithOneEvenLengthWord_ShouldReturnSameWord()
    {
        // Arrange
        string[] text = new string[] {"jaba"};
        string expected = "jaba";

        // Act
        string actual = EvenLengthWordsFilter.GetEvenWords(text);

        // Assert
        Assert.AreEqual(expected, actual, "There was an error in executing and displaying the right result");
    }

    [Test]
    public void Test_GetEvenWords_InputArrayWithEvenAndOddLengthWords_ShouldReturnOnlyEvenLengthWords()
    {
        // Arrange
        string[] text = new string[] {"Imalo", "edno", "vreme", "edna", "kushta"};
        string expected = "edno edna kushta";

        // Act
        string actual = EvenLengthWordsFilter.GetEvenWords(text);

        // Assert
        Assert.AreEqual(expected, actual, "There was an error in executing and displaying the right result");
    }
}

