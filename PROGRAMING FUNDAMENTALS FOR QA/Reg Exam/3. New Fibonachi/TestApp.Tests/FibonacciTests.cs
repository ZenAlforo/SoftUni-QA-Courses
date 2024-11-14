using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

public class FibonacciTests
{

    [Test]
    public void Test_FibonacciInRange_StartNumberGreaterThanEndNumber_ReturnsErrorMessage()
    {
        // Arrange
        int a = 15;
        int b = 10;
        string expected = "Start number should be less than end number.";

        // Act
        string result = Fibonacci.FibonacciInRange(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FibonacciInRange_StartAndEndNumberEqualToZero_ReturnsZero()
    {
        // Arrange
        int a = 0;
        int b = 0;
        string expected = "0";

        // Act
        string result = Fibonacci.FibonacciInRange(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FibonacciInRange_StartAndEndNumberEqualToOne_ReturnsTwoTimesOne()
    {
        // Arrange
        int a = 1;
        int b = 1;
        string expected = "1 1";

        // Act
        string result = Fibonacci.FibonacciInRange(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FibonacciInRange_NoFibonacciNumberBetweenStartAndEndNumbers_ReturnsEmptyString()
    {
        // Arrange
        int a = 9;
        int b = 12;
        string expected = "";

        // Act
        string result = Fibonacci.FibonacciInRange(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FibonacciInRange_ValidRange_ReturnsFibonacciSequence()
    {
        // Arrange
        int a = 8;
        int b = 22;
        string expected = "8 13 21";

        // Act
        string result = Fibonacci.FibonacciInRange(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}

