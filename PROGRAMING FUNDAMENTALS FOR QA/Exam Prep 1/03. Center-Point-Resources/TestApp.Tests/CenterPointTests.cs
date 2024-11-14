using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class CenterPointTests
{
    [Test]
    public void Test_GetClosest_WhenFirstPointIsCloser_ShouldReturnFirstPoint()
    {
        // Arrange
        double x1 = 1;
        double y1 = 2;
        double x2 = 3;
        double y2 = 4;
        string expected = $"({string.Join(", ", x1, y1)})";

        // Act
        string result = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expected, result);

    }

    [Test]
    public void Test_GetClosest_WhenSecondPointIsCloser_ShouldReturnSecondPoint()
    {
        // Arrange
        double x1 = 1;
        double y1 = 8;
        double x2 = 3;
        double y2 = 4;
        string expected = $"({string.Join(", ", x2, y2)})";

        // Act
        string result = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetClosest_WhenBothPointsHaveEqualDistance_ShouldReturnFirstPoint()
    {
        // Arrange
        double x1 = 1;
        double y1 = 2;
        double x2 = 3;
        double y2 = 0;
        string expected = $"({string.Join(", ", x1, y1)})";

        // Act
        string result = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetClosest_WhenFirstPointIsNegative_ShouldReturnFirstPoint()
    {
        // Arrange
        double x1 = -5;
        double y1 = 2;
        double x2 = 3;
        double y2 = 4;
        string expected = $"({string.Join(", ", x1, y1)})";

        // Act
        string result = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetClosest_WhenSecondPointIsNegative_ShouldReturnSecondPoint()
    {
        // Arrange
        double x1 = 1;
        double y1 = 2;
        double x2 = -2;
        double y2 = -1;
        string expected = $"({string.Join(", ", x2, y2)})";

        // Act
        string result = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
