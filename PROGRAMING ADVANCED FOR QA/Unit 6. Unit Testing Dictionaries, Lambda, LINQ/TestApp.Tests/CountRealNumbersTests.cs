using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class CountRealNumbersTests
{
    // TODO: finish test
    [Test]
    public void Test_Count_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        int[] input = { };

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Count_WithSingleNumber_ShouldReturnCountString()
    {
        // Arrange
        int[] input = { 1 };
        string expected = "1 -> 1";

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithMultipleNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] input = { 1, 3, 4, 5, 1, 1 };
        string expected = $"1 -> 3{Environment.NewLine}3 -> 1{Environment.NewLine}4 -> 1{Environment.NewLine}5 -> 1";

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithNegativeNumbers_ShouldReturnCountString()
    {
        int[] input = { -1, -3, -4, -5, -1, -1 };
        string expected = $"-5 -> 1" +
            $"{Environment.NewLine}-4 -> 1" +
            $"{Environment.NewLine}-3 -> 1" +
            $"{Environment.NewLine}-1 -> 3";
            

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithZero_ShouldReturnCountString()
    {
        int[] input = { 1, 3, -4, 5, 0, 1 };
        string expected = $"-4 -> 1{Environment.NewLine}0 -> 1{Environment.NewLine}1 -> 2{Environment.NewLine}3 -> 1{Environment.NewLine}5 -> 1";

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
