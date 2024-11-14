using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class FoldSumTests
{
    [TestCase(new int[]{1, 5, 6, 12, 5, 7, 4, 8, 9, 6, 6, 7}, "18 10 8 11 14 15" )]
    [TestCase(new int[] { 1, 5, 6, 8, 9, 6, 6, 7 }, "11 9 16 12")]
    [TestCase(new int[] { 1, 5, 6, 12}, "6 18")]
    [TestCase(new int[] { 1, 5, 6, -3, 5, 7, 0, 8, -2, 6, 6, 1 }, "3 10 8 1 14 4")]
    [TestCase(new int[0], "")]
    [TestCase(new int[] {1, 1, 1, 1, 1, 1, 1, 1}, "2 2 2 2")]
    public void Test_FoldArray_ReturnsCorrectString(int[] arr, string expected)
    {
        // Arrange & Act
        string result = FoldSum.FoldArray(arr);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
