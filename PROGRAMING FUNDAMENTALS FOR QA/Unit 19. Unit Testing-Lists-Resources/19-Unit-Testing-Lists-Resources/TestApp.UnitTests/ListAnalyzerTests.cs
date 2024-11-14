using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class ListAnalyzerTests
{
    [Test]
    public void Test_Analyze_EmptyList_ShouldReturnNoElementsMsg()
    {
        // Arrange
        List<int> myList = new();
        string expected = "No elements!";

        // Act
        string result = ListAnalyzer.Analyze(myList);

        // Assert
        Assert.AreEqual(expected, result);

    }

    [Test]
    public void Test_Analyze_OneElement_ShouldReturnSameValueForMinMaxAvg()
    {
        // Arrange
        List<int> myList = new() {5};
        string expected = $"Element count: 1, Min value: 5, Max value: {5}, Avg: {5:F2}.";

        // Act
        string result = ListAnalyzer.Analyze(myList);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Analyze_OnlySameValueElements_ShouldReturnSameValueForMinMaxAvg()
    {
        // Arrange
        List<int> myList = new() {3, 3, 3, 3};
        string expected = $"Element count: 4, Min value: 3, Max value: {3}, Avg: {3:F2}.";

        // Act
        string result = ListAnalyzer.Analyze(myList);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_Analyze_DiffrentValues_ShouldReturnCorrectValues()
    {
        // Arrange
        List<int> myList = new() {3, 4, -2, 4, 5};
        string expected = $"Element count: 5, Min value: -2, Max value: {5}, Avg: {2.8:F2}."; ;

        // Act
        string result = ListAnalyzer.Analyze(myList);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
