using NUnit.Framework;

namespace TestApp.UnitTests;

public class GradesTests
{
    [TestCase(3.44, "Average")]
    [TestCase(3.58, "Good")]
    [TestCase(5.00, "Very Good")]
    [TestCase(2.05, "Fail")]
    [TestCase(3.80, "Good")]
    [TestCase(6, "Excellent")]
    [TestCase(1.00, "Invalid!")]
    public void Test_GradeAsWords_ReturnsCorrectString(double grade, string expected)
    {
        // Arrange
        
        // Act
        string actual = Grades.GradeAsWords(grade);

        // Assert
        Assert.AreEqual(expected, actual);
    }
    [TestCase(1.99, "Invalid!")]
    [TestCase(2.99, "Fail")]
    [TestCase(3.51, "Good")]
    [TestCase(5.50, "Excellent")]
    [TestCase(5.51, "Excellent")]
    [TestCase(6.01, "Invalid!")]
    [TestCase(-5.00, "Invalid!")]
    public void Test_GradeAsWords_ReturnsCorrectString_EdgeCases(double grade, string expected)
    {
        // Arrange

        // Act
        string actual = Grades.GradeAsWords(grade);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
