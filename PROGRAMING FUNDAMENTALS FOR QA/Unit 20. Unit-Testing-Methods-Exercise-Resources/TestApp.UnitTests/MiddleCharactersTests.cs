using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class MiddleCharactersTests
{
    [Test]
    public void Test_GetMiddleChars_EmptyString_ReturnsEmptyStringMessage()
    {
        // Arrange
        string input = string.Empty;
        string expected = "Empty string";

        // Act
        string result = MiddleCharacters.GetMiddleChars(input);

        // Assert
        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void Test_GetMiddleChars_WhiteSpaceString_ReturnsEmptyStringMessage()
    {
        // Arrange
        string input = " ";
        string expected = "Empty string";

        // Act
        string result = MiddleCharacters.GetMiddleChars(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetMiddleChars_SingleCharacterString_ReturnsTheCharacter()
    {
        // Arrange
        string input = "g";
        
        // Act
        string result = MiddleCharacters.GetMiddleChars(input);

        // Assert
        Assert.That(result, Is.EqualTo("g"));
    }

    [Test]
    public void Test_GetMiddleChars_EvenStringLength_ReturnsTwoCharactersString()
    {
        // Arrange
        string input = "frog";
        string expected = "ro";

        // Act
        string result = MiddleCharacters.GetMiddleChars(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetMiddleChars_OddStringLength_ReturnsOneCharactersString()
    {
        // Arrange
        string input = "cat";
        string expected = "a";

        // Act
        string result = MiddleCharacters.GetMiddleChars(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
