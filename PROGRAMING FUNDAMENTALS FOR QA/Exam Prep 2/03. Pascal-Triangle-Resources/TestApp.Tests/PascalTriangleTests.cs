using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class PascalTriangleTests
{
    [TestCase(2, "1 \n1 1 \n")]
    [TestCase(-5, "")]
    [TestCase(3, "1 \n1 1 \n1 2 1 \n")]
    [TestCase(1, "1 \n")]
    [TestCase(0, "")]
    public void Test_PrintTriangle_ShouldReturnCorrectString(int n, string expected)
    {
        // Arrange & Act
        string result = PascalTriangle.PrintTriangle(n);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
