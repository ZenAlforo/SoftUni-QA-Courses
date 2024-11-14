using NUnit.Framework;

namespace TestApp.UnitTests;

public class PrimeFactorTests
{
    [Test]
    public void Test_FindLargestPrimeFactor_PrimeNumber()
    {
        // Arrange
        long number = 7;
        long expected = 7;

        // Act
        long result = PrimeFactor.FindLargestPrimeFactor(number);

        // Assert
        Assert.AreEqual(expected, result);


    }

    [Test]
    public void Test_FindLargestPrimeFactor_LargeNumber()
    {
        // Arrange
        long number = 12;
        long expected = 3;

        // Act
        long result = PrimeFactor.FindLargestPrimeFactor(number);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
