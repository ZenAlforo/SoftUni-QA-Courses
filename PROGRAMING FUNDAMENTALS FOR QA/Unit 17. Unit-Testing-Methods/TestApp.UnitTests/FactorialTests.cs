using NUnit.Framework;

namespace TestApp.UnitTests;

public class FactorialTests
{
    [Test]
    public void Test_CalculateFactorial_InputZero_ReturnsOne()
    {
        // Arrange
        int number = 0;

        // Act
        int input = Factorial.CalculateFactorial(number);
        int expected = 1;

        // Assert
        Assert.AreEqual(expected, input, "The factorial method did not work properly");
    }

    [Test]
    public void Test_CalculateFactorial_InputPositiveNumber_ReturnsCorrectFactorial()
    {
        // Arrange
        int number = 8;

        // Act
        int input = Factorial.CalculateFactorial(number);
        int expected = 40320;

        // Assert
        Assert.AreEqual(expected, input, "The factorial method did not work properly");
    }
}
