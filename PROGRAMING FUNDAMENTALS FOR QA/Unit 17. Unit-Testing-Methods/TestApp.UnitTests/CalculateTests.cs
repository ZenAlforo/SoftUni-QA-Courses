using NUnit.Framework;

namespace TestApp.UnitTests;

public class CalculateTests
{
    [Test]
    public void Test_Addition()
    {
        // Arrange
        Calculate calculator = new();

        // Act
        int actual = calculator.Addition(5, 2);

        // Assert
        Assert.AreEqual(7, actual, "Addition did not work properly.");
    }

    [Test]
    public void Test_Subtraction()
    {
        // Arrange
        Calculate calculator = new();
        
        // Act  
        int actual = calculator.Subtraction(7, 2);
        int expected = 5;

        // Assert
        Assert.That(expected, Is.EqualTo(actual), "Subraction didnt work out properly");
    }
}
