using NUnit.Framework;
using System;

namespace TestApp.UnitTests;

public class TriangleTests
{
    [Test]
    public void Test_Triangle_OutputMatchesExpected_Size0()
    {
        // Arrange
        int size = 0;
        
        // Act
        string actual = Triangle.PrintTriangle(size);
        string expected = string.Empty;

        // Assert
        Assert.AreEqual(expected, actual, "The method did not work properly");
    }

    [Test]
    public void Test_Triangle_OutputMatchesExpected_Size3()
    {
        // Arrange
        int size = 3;

        // Act
        string actual = Triangle.PrintTriangle(size);
        
        string expected = 
            ( "1" + Environment.NewLine 
            + "1 2" + Environment.NewLine 
            + "1 2 3" + Environment.NewLine 
            + "1 2" + Environment.NewLine 
            + "1");

        // Assert
        Assert.AreEqual(expected, actual, "The resulting string was not the expected size");
    }

    [Test]
    public void Test_Triangle_OutputMatchesExpected_Size5()
    {
        // Arrange
        int size = 5;

        // Act
        string actual = Triangle.PrintTriangle(size);
        string expected = 
            ( "1" + Environment.NewLine 
            + "1 2" + Environment.NewLine 
            + "1 2 3" + Environment.NewLine
            + "1 2 3 4" + Environment.NewLine
            + "1 2 3 4 5" + Environment.NewLine
            + "1 2 3 4" + Environment.NewLine
            + "1 2 3" + Environment.NewLine
            + "1 2" + Environment.NewLine 
            + "1");

        // Assert
        Assert.AreEqual(expected, actual, "The resulting string was not the expected size");
    }
}
