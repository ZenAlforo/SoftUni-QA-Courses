using NUnit.Framework;

namespace TestApp.UnitTests;

public class StringReverseTests
{
    // TODO: finish test
    [Test]
    public void Test_Reverse_WhenGivenEmptyString_ReturnsEmptyString()
    {
        // Arrange
        StringReverse stringReverse = new();

        // Act
        string input = "";
        string actual = StringReverse.Reverse(input);
        string expected = "";

        // Assert
        Assert.AreEqual(expected, actual, "Reverse did not work properly");
    }

    [Test]
    public void Test_Reverse_WhenGivenSingleCharacterString_ReturnsSameCharacter()
    {
        StringReverse stringReverse = new();

        // Act
        string input = "e";
        string actual = StringReverse.Reverse(input);
        string expected = "e";

        // Assert
        Assert.AreEqual(expected, actual, "Reverse did not work properly");
    }

    [Test]
    public void Test_Reverse_WhenGivenNormalString_ReturnsReversedString()
    {
        StringReverse stringReverse = new StringReverse();

        // Act
        string input = "abcde";
        string actual = StringReverse.Reverse(input);
        string expected = "edcba";

        // Assert
        Assert.AreEqual(expected, actual, "Reverse did not work properly");
    }
}
