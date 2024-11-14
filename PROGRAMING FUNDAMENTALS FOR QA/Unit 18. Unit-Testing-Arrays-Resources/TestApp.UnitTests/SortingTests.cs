using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.UnitTests;

public class SortingTests
{
    [Test]
    public void Test_ShallowAscendingSort_EmptyArrayParameter_ReturnsEmptyArray()
    {
        // Arrange
        double[] numbers = new double[] { };
        double[] expected = {};

        // Act
        double[] actual = Sorting.ShallowAscendingSort(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_DeepAscendingSort_EmptyArrayParameter_ReturnsEmptyArray()
    {
        // Arrange
        double[] numbers = Array.Empty<double>();
        double[] expected = {};

        // Act
        double[] actual = Sorting.DeepAscendingSort(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ShallowAscendingSort_UnOrderedArrayParam_ReturnsAscendingOrderedArrayAndDoesNotChangeTheOriginalArray()
    {
        // Arrange
        double[] numbers = new double[] { 5.3, 2, 8.5, 6, -1 };
        double[] expected = { -1, 2, 5.3, 6, 8.5};

        // Act
        double[] actual = Sorting.ShallowAscendingSort(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
        Assert.AreNotEqual(expected, numbers);
    }

    [Test]
    public void Test_DeepAscendingSort_UnOrderedArrayParam_ReturnsAscendingOrderedArrayAndDoesChangeTheOriginalArray()
    {
        // Arrange
        double[] numbers = new double[] {4.3, 3, 3.4, -9};
        double[] expected = {-9, 3, 3.4, 4.3};

        // Act
        double[] actual = Sorting.DeepAscendingSort(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
        Assert.AreEqual(expected, numbers);
    }
}
