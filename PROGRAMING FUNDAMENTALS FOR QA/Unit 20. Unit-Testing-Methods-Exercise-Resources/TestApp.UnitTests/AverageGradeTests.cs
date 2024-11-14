using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class AverageGradeTests
{
    [Test]
    public void Test_GetGradeDefinition_AverageGradeUnderTwo_ReturnsErrorMessage()
    {
        // Arrange
        List<double> results = new List<double> { 2.8, 1.0, 2.0, 1.22, 2.33 };
        string expected = "Incorrect grades";

        // Act
        string result = AverageGrade.GetGradeDefinition(results);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetGradeDefinition_AverageGradeOverSix_ReturnsErrorMessage()
    {
        // Arrange
        List<double> results = new List<double> { 2.8, 11.0, 2.0, 7.22, 8.33 };
        string expected = "Incorrect grades";

        // Act
        string result = AverageGrade.GetGradeDefinition(results);

        // Assert
        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void Test_GetGradeDefinition_FailScoreAverageGrade_ReturnsFailDefinitionMessage()
    {
        // Arrange
        List<double> results = new List<double> { 2.8, 3.0, 2.0, 3.22, 2.33 };
        string expected = "Fail";

        // Act
        string result = AverageGrade.GetGradeDefinition(results);

        // Assert
        Assert.True(expected.Equals(result));
    }

    [Test]
    public void Test_GetGradeDefinition_PoorScoreAverageGrade_ReturnsPoorDefinitionMessage()
    {
        // Arrange
        List<double> results = new List<double> { 2.8, 3.0, 2.0, 5.22, 4.33 };
        string expected = "Poor";

        // Act
        string result = AverageGrade.GetGradeDefinition(results);

        // Assert
        Assert.AreSame(expected, result);
    }

    [Test]
    public void Test_GetGradeDefinition_GoodScoreAverageGrade_ReturnsGoodDefinitionMessage()
    {
        // Arrange
        List<double> results = new List<double> { 5.8, 3.0, 2.0, 4.22, 3.33 };
        string expected = "Good";

        // Act
        string result = AverageGrade.GetGradeDefinition(results);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetGradeDefinition_VeryGoodScoreAverageGrade_ReturnsVeryGoodDefinitionMessage()
    {
        // Arrange
        List<double> results = new List<double> { 3.8, 6.0, 4.0, 4.22, 5.33 };
        string expected = "Very good";

        // Act
        string result = AverageGrade.GetGradeDefinition(results);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetGradeDefinition_ExcellentScoreAverageGrade_ReturnsExcellentDefinitionMessage()
    {
        // Arrange
        List<double> results = new List<double> { 5.8, 5.0, 6.0, 5.22, 5.93 };
        string expected = "Excellent";

        // Act
        string result = AverageGrade.GetGradeDefinition(results);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
