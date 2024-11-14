using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class ListSplitterTests
{
    [Test]
    public void Test_SplitEvenAndOdd_EmptyListParameter_ReturnsEmptyEvenAndOddLists()
    {
        // Arrange
        List<int> list = new List<int>();

        // Act
        (List<int> evens, List<int> odds) result = ListSplitter.SplitEvenAndOdd(list);

        // Assert
        Assert.That(result.evens, Is.Empty);
        Assert.That(result.odds, Is.Empty);
    }

    [Test]
    public void Test_SplitEvenAndOdd_OnlyEvenValues_ReturnsEmptyOddList()
    {
        // Arrange
        List<int> list = new List<int>() { 4, 6, 8};

        // Act
        (List<int> evens, List<int> odds) result = ListSplitter.SplitEvenAndOdd(list);

        // Assert
        Assert.That(result.odds, Is.Empty);
    }

    [Test]
    public void Test_SplitEvenAndOdd_OnlyOddValues_ReturnsEmptyEvenList()
    {
        // Arrange
        List<int> list = new List<int>() { 1, 1, 1 };

        // Act
        (List<int> evens, List<int> odds) result = ListSplitter.SplitEvenAndOdd(list);

        // Assert
        Assert.That(result.evens, Is.Empty);
    }

    [Test]
    public void Test_SplitEvenAndOdd_EvenAndOddValues_ReturnsListWithCorrectValues()
    {
        // Arrange
        List<int> list = new List<int>() { 4, 6, 3, 7, 8 };
        List<int> expectedEvens = new() { 4, 6, 8 }; 
        List<int> expectedOdds = new() { 3, 7 };


        // Act
        (List<int> evens, List<int> odds) result = ListSplitter.SplitEvenAndOdd(list);

        // Assert
        Assert.That(expectedOdds, Is.EqualTo(result.odds));
        Assert.That(expectedEvens, Is.EqualTo(result.evens));
    }
}
