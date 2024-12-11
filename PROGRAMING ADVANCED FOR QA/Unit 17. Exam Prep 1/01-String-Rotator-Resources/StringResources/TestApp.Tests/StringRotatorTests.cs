using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class StringRotatorTests
{
    [Test]
    public void Test_RotateRight_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = string.Empty;
        int position = 2;

        // Act
        string result = StringRotator.RotateRight(input, position);

        // Assert
        Assert.IsEmpty(result);
        Assert.That(result, Is.EqualTo(input));
        Assert.That(result.Length, Is.EqualTo(input.Length));
        Assert.That(result.Length, Is.EqualTo(0));
        Assert.True(result.Equals(input));
        Assert.Pass(input, Is.EqualTo(result));
        Assert.Zero(result.Length);
        Assert.IsTrue(result.Equals(input));
    }

    [Test]
    public void Test_RotateRight_RotateByZeroPositions_ReturnsOriginalString()
    {
        // Arrange
        string input = "catalyst";
        int position = 0;

        // Act
        string result = StringRotator.RotateRight(input, position);

        // Assert
        Assert.That(result, Is.EqualTo(input));
        Assert.That(result.Length, Is.EqualTo(input.Length));
        Assert.True(result.Equals(input));
        Assert.Pass(input, Is.EqualTo(result));
        Assert.IsTrue(result.Equals(input));
        Assert.AreEqual(input, result); 
    }

    [Test]
    public void Test_RotateRight_RotateByPositivePositions_ReturnsRotatedString()
    {
        // Arrange
        string input = "catalyst";
        int position = 4;
        string expected = "lystcata";

        // Act
        string result = StringRotator.RotateRight(input, position);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
        Assert.That(result.Length, Is.EqualTo(expected.Length));
        Assert.True(result.Equals(expected));
        Assert.Pass(expected, Is.EqualTo(result));
        Assert.IsTrue(result.Equals(expected));
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_RotateRight_RotateByNegativePositions_ReturnsRotatedString()
    {
        // Arrange
        string input = "catalyst";
        int position = -3;
        string expected = "ystcatal";

        // Act
        string result = StringRotator.RotateRight(input, position);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
        Assert.That(result.Length, Is.EqualTo(expected.Length));
        Assert.True(result.Equals(expected));
        Assert.Pass(expected, Is.EqualTo(result));
        Assert.IsTrue(result.Equals(expected));
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_RotateRight_RotateByMorePositionsThanStringLength_ReturnsRotatedString()
    {
        // Arrange
        string input = "catalyst";
        int position = 15;
        string expected = "atalystc";

        // Act
        string result = StringRotator.RotateRight(input, position);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
        Assert.That(result.Length, Is.EqualTo(expected.Length));
        Assert.True(result.Equals(expected));
        Assert.Pass(expected, Is.EqualTo(result));
        Assert.IsTrue(result.Equals(expected));
        Assert.AreEqual(expected, result);
    }
}
