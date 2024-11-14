using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class PalindromeIntegersTests
{
    [Test]
    public void Test_FindPalindromes_EmptyList_ReturnsEmptyList()
    {
        // Arrange
        List<int> list = new List<int> { };
        List<int> expected = new();

        // Act
        PalindromeIntegers result = new();
        List<int> actual = result.FindPalindromes(list);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindPalindromes_NoPalindromes_ReturnsEmptyList()
    {
        // Arrange
        List<int> list = new List<int> {1233, 49949999, 3232,  80, 14};
        List<int> expected = new();

        // Act
        PalindromeIntegers result = new();
        List<int> actual = result.FindPalindromes(list);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindPalindromes_OnlySingleDigitsElements_ReturnsSameIntegersList()
    {
        // Arrange
        List<int> list = new List<int> { 4, 5, 6, 6, 7, 7, 8};
        List<int> expected = new List<int> { 4, 5, 6, 6, 7, 7, 8 };

        // Act
        PalindromeIntegers result = new();
        List<int> actual = result.FindPalindromes(list);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindPalindromes_AllElementsArePalindromes_ReturnsSameIntegersList()
    {
        // Arrange
        List<int> list = new List<int> { 121, 55, 345543, 1771 };
        List<int> expected = new() { 121, 55, 345543, 1771 };

        // Act
        PalindromeIntegers result = new();
        List<int> actual = result.FindPalindromes(list);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindPalindromes_PalimdromesAndNoPalindromesIntegers_ReturnsOnlyPalindromes()
    {
        // Arrange
        List<int> list = new List<int> {32, 33, 4, 8731, 19, 22 };
        List<int> expected = new() {33, 4, 22 };

        // Act
        PalindromeIntegers result = new();
        List<int> actual = result.FindPalindromes(list);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
