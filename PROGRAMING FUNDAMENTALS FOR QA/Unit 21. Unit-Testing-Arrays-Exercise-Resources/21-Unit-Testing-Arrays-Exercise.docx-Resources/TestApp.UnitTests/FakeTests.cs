using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class FakeTests
{
    [Test]
    public void Test_RemoveStringNumbers_RemovesDigitsFromCharArray()
    {
        // Arrange
        char[] numbers = { '2', 'c', 'z', '#' };
        char[] expected = { 'c', 'z', '#' };

        // Act
        char[] result = Fake.RemoveStringNumbers(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RemoveStringNumbers_NoDigitsInInput_ReturnsSameArray()
    {
        // Arrange
        char[] numbers = { 's', 'c', 'z', '#' };
        char[] expected = { 's', 'c', 'z', '#' };

        // Act
        char[] result = Fake.RemoveStringNumbers(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_RemoveStringNumbers_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        char[] numbers = { };
        char[] expected = { };

        // Act
        char[] result = Fake.RemoveStringNumbers(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
