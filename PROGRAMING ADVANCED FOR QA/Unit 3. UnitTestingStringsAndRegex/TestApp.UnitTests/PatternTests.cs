using NUnit.Framework;
using System;

namespace TestApp.UnitTests;

public class PatternTests
{
    // TODO: finish the test cases
    [TestCase("cat", 1, "cAt")]
    [TestCase("doge", 4, "dOgEdOgEdOgEdOgE")]
    [TestCase("owl", 3, "oWloWloWl")]
    public void Test_GeneratePatternedString_ValidInput_ReturnsExpectedResult(string input, 
        int repetitionFactor, string expected)
    {
        // Arrange

        // Act
        string result = Pattern.GeneratePatternedString(input, repetitionFactor);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GeneratePatternedString_EmptyInput_ThrowsArgumentException()
    {
        // Arrange
        string input = string.Empty;
        int repetitionFactor = 3;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(input, repetitionFactor));
    }

    [Test]
    public void Test_GeneratePatternedString_NegativeRepetitionFactor_ThrowsArgumentException()
    {
        // Arrange
        string input = "dog";
        int repetitionFactor = -4;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(input, repetitionFactor));
    }

    [Test]
    public void Test_GeneratePatternedString_ZeroRepetitionFactor_ThrowsArgumentException()
    {
        // Arrange
        string input = "dog";
        int repetitionFactor = 0;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(input, repetitionFactor));
    }
}
