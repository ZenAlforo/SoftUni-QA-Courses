using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class PalindromeTests
{
    // TODO: finish test
    [Test]
    public void Test_IsPalindrome_ValidPalindrome_ReturnsTrue()
    {
        // Arrange
        List<string> input = new List<string>() {"refer", "ama", "odo"};

        // Act
        bool result = Palindrome.IsPalindrome(input);

        // Assert
        Assert.IsTrue(result);
    }

    // TODO: finish test
    [Test]
    public void Test_IsPalindrome_EmptyList_ReturnsTrue()
    {
        // Arrange
        List<string> input = new List<string>();

        // Act
        bool result = Palindrome.IsPalindrome(input);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void Test_IsPalindrome_SingleWord_ReturnsTrue()
    {
        // Arrange
        List<string> input = new List<string>() { "refer"};

        // Act
        bool result = Palindrome.IsPalindrome(input);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void Test_IsPalindrome_NonPalindrome_ReturnsFalse()
    {
        // Arrange
        List<string> input = new List<string>() { "referal", "mama", "odor" };

        // Act
        bool result = Palindrome.IsPalindrome(input);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void Test_IsPalindrome_MixedCasePalindrome_ReturnsTrue()
    {
        // Arrange
        List<string> input = new List<string>() { "Level", "moM", "reFeR" };

        // Act
        bool result = Palindrome.IsPalindrome(input);

        // Assert
        Assert.IsTrue(result);
    }
}
