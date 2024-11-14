using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class PrimeNumberFinderTests
{
    [Test]
    public void Test_GetAllPrimeNumbers_InputArrayWithLessThanOrEqualToOneElementsOnly_ReturnsEmptyArray()
    {
        // Arrange
        int[] num = new int[] {-1, 0, 1};
        int[] expected = {};

        // Act
        int[] actual = PrimeNumberFinder.GetAllPrimeNumbers(num);

        // Assert
        Assert.AreEqual(expected, actual, "There was an error logic of the execution");
    }

    [Test]
    public void Test_GetAllPrimeNumbers_InputArrayWithOnlyOneNonPrimeNumber_ReturnsEmptyArray()
    {
        // Arrange
        int[] num = new int[] {8};
        int[] expected = {};

        // Act
        int[] actual = PrimeNumberFinder.GetAllPrimeNumbers(num);

        // Assert
        Assert.AreEqual(expected, actual, "There was an error logic of the execution");
    }

    [Test]
    public void Test_GetAllPrimeNumbers_InputArrayWithNoPrimeNumbersOnly_ReturnsEmptyArray()
    {
        // Arrange
        int[] num = new int[] {4, 6, 8, 10};
        int[] expected = {};

        // Act
        int[] actual = PrimeNumberFinder.GetAllPrimeNumbers(num);

        // Assert
        Assert.AreEqual(expected, actual, "There was an error logic of the execution");
    }

    [Test]
    public void Test_GetAllPrimeNumbers_InputArrayWithOnlyOnePrimeNumber_ReturnsArrayWithTheSameNumber()
    {
        // Arrange
        int[] num = new int[] {2, 4, 6};
        int[] expected = new int[] {2};

        // Act
        int[] actual = PrimeNumberFinder.GetAllPrimeNumbers(num);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
        //Assert.AreEqual(expected, actual, "There was an error logic of the execution");
    }

    [Test]
    public void Test_GetAllPrimeNumbers_InputArrayWithMixedNumbers_ReturnsArrayOnlyWithPrimeNumbers()
    {
        // Arrange
        int[] num = new int[] {10, 2, 3, 4, 5, 6};
        int[] expected = {2, 3, 5};

        // Act
        int[] actual = PrimeNumberFinder.GetAllPrimeNumbers(num);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
