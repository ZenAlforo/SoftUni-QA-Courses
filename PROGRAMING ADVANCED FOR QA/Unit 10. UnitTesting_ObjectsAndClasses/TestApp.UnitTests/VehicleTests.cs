using NUnit.Framework;

using System;
using System.Runtime.ConstrainedExecution;
using TestApp.Vehicle;

namespace TestApp.UnitTests;

public class VehicleTests
{
    private Vehicles _vehicle;

    [SetUp]
    public void SetUp()
    {
        this._vehicle = new();
    }

    // TODO: finish test
    [Test]
    public void Test_AddAndGetCatalogue_ReturnsSortedCatalogue()
    {
        // Arrange
        string[] vehicles = { "Car/Suzuki/Grand Vitara/250", "Truck/Man/101Raptor/1000", "Car/Ferrari/F20/340" };
        string expected = $"Cars:{Environment.NewLine}Ferrari: F20 - 340hp{Environment.NewLine}Suzuki: Grand Vitara - 250hp{Environment.NewLine}Trucks:{Environment.NewLine}Man: 101Raptor - 1000kg";
        // Act
        string result = _vehicle.AddAndGetCatalogue(vehicles);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_AddAndGetCatalogue_ReturnsEmptyCatalogue_WhenNoDataGiven()
    {
        // Arrange
        string[] vehicles = { };
        string expected = $"Cars:{Environment.NewLine}Trucks:";
        // Act
        string result = _vehicle.AddAndGetCatalogue(vehicles);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
