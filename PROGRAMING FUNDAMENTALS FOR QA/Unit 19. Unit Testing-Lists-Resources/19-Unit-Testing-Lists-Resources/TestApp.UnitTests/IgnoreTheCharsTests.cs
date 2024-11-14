using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class IgnoreTheCharsTests
{
    [Test]
    public void Test_IgnoreChars_EmptyStringSentence_ReturnsEmptyString()
    {
        // Arrange
        string sentence = string.Empty;
        List<char> list = new List<char>();

        // Act
        string result = IgnoreTheChars.IgnoreChars(sentence, list);

        // Assert
        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_IgnoreChars_EmptyList_ReturnsSameSentence()
    {
        // Arrange
        string sentence = "Kotkata skacha na visoko";
        List<char> list = new List<char>() {};

        // Act
        string result = IgnoreTheChars.IgnoreChars(sentence, list);

        // Assert
        Assert.AreEqual(sentence, result);
    }

    [Test]
    public void Test_IgnoreChars_OneCharSentenceAndSameCharsForIgnoring_ReturnsEmptyString()
    {
        // Arrange
        string sentence = "b";
        List<char> list = new List<char>() {'b'};

        // Act
        string result = IgnoreTheChars.IgnoreChars(sentence, list);

        // Assert
        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_IgnoreChars_WholeSentenceAndFewCharsToIgnore_ReturnsCorrectString()
    {
        // Arrange
        string sentence = "Kotkata skacha";
        List<char> list = new List<char>() {'a', 'k'};
        string expected = "Kott sch";

        // Act
        string result = IgnoreTheChars.IgnoreChars(sentence, list);

        // Assert
        Assert.That(expected, Is.EqualTo(result));
    }
}
