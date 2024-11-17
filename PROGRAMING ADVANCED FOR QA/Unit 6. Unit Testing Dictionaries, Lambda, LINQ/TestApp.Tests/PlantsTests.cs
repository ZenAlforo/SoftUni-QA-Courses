using NUnit.Framework;

using System;
using System.Numerics;

namespace TestApp.Tests;

public class PlantsTests
{
    [Test]
    public void Test_GetFastestGrowing_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] plants = new string[0];

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.IsEmpty(result);
    }


    [Test]
    public void Test_GetFastestGrowing_WithSinglePlant_ShouldReturnPlant()
    {
        // Arrange
        string[] plants = {"rose"};
        string expected = $"Plants with 4 letters:\nrose";

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMultiplePlants_ShouldReturnGroupedPlants()
    {
        // Arrange
        string[] plants = { "rose", "tulip", "ivy", "mint"};
        string expected = $"Plants with 3 letters:" +
            $"{Environment.NewLine}ivy" +
            $"{Environment.NewLine}Plants with 4 letters:" +
            $"{Environment.NewLine}rose" +
            $"{Environment.NewLine}mint" +
            $"{Environment.NewLine}Plants with 5 letters:" +
            $"{Environment.NewLine}tulip";

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMixedCasePlants_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] plants = { "Rose", "tulip", "iVy", "mInt" };
        string expected = $"Plants with 3 letters:" +
            $"{Environment.NewLine}iVy" +
            $"{Environment.NewLine}Plants with 4 letters:" +
            $"{Environment.NewLine}Rose" +
            $"{Environment.NewLine}mInt" +
            $"{Environment.NewLine}Plants with 5 letters:" +
            $"{Environment.NewLine}tulip";

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
