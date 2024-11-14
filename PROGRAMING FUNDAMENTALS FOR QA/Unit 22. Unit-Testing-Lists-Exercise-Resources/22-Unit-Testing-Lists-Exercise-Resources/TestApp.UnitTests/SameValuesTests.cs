using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class SameValuesTests
{
    [Test]
    public void Test_FindSameValues_EmptyFirstList_ReturnsEmptyList()
    {
        // Arrange
        List<int> firstList = new List<int>() { };
        List<int> secondList = new List<int>() { 2, 3, 4, 5};
        List<int> expected = new List<int>() { };

        // Act
        List<int> result = SameValues.FindSameValues(firstList, secondList);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindSameValues_EmptySecondList_ReturnsEmptyList()
    {
        // Arrange
        List<int> firstList = new List<int>() { 2, 3, 4, 5 };
        List<int> secondList = new List<int>() { };
        List<int> expected = new List<int>() { };

        // Act
        List<int> result = SameValues.FindSameValues(firstList, secondList);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindSameValues_NoSameValuesInBothLists_ReturnsEmptyList()
    {
        // Arrange
        List<int> firstList = new List<int>() { 66, 88, 34, 1};
        List<int> secondList = new List<int>() { 2, 3, 4, 5 };
        List<int> expected = new List<int>() { };

        // Act
        List<int> result = SameValues.FindSameValues(firstList, secondList);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindSameValues_BothListWithSameValues_ReturnsListWithSameValues()
    {
        // Arrange
        List<int> firstList = new List<int>() { 2, 3, 4, 5 };
        List<int> secondList = new List<int>() { 2, 3, 4, 5 };
        List<int> expected = new List<int>() { 2, 3, 4, 5 };

        // Act
        List<int> result = SameValues.FindSameValues(firstList, secondList);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }
}
