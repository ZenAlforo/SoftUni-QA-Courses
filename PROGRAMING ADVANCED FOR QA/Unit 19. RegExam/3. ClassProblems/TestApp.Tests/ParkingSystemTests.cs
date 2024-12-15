using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

public class ParkingSystemTests
{
    private ParkingSystem _parkingSystem;
    
    [SetUp] 
    public void SetUp()
    {
        _parkingSystem = new ParkingSystem();
    }

    [Test]
    public void Test_Contructor_CheckInitialEmptyCarCollectionAndCount()
    {
        // Arrange & Act
        int carCount = _parkingSystem.CarCount;
        List<string> expected = new() { };
        List<string> cars = _parkingSystem.GetAllParkedCars();

        // Assert
        Assert.That(carCount, Is.EqualTo(0));
        Assert.That(cars, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ParkCar_ValidCarNumber_AddNewCar()
    {
        // Arrange
        string input = "CA9091BT";
        _parkingSystem.ParkCar(input);

        // Act
        List<string> result = _parkingSystem.GetAllParkedCars();     

        // Assert
        Assert.That(result.Count(), Is.EqualTo(1));
        Assert.That(result[0], Is.EqualTo(input));

    }

    [TestCase("")]
    [TestCase(null)]
    public void Test_ParkCar_NullOrEmptyCarNumber_ThrowsArgumentException(string carNumber)
    {
        // Arrange
        string input = carNumber;
        string expectedErrorMessage = "Car number cannot be empty or whitespace.";

        // Act & Assert
        var error = Assert.Throws<ArgumentException>(() => _parkingSystem.ParkCar(input));
        Assert.That(error.Message, Is.EqualTo(expectedErrorMessage));
    }

    [Test]
    public void Test_RemoveCar_ValidCarNumber_RemoveFirstCar()
    {
        // Arrange
        string input1 = "CA9091BT";
        string input2 = "CO5666AT";

        _parkingSystem.ParkCar(input1);
        _parkingSystem.ParkCar(input2);

        // Act
        _parkingSystem.RemoveCar(input1);
        List<string> result = _parkingSystem.GetAllParkedCars();

        // Assert
        Assert.That(result.Count(), Is.EqualTo(1));
        Assert.That(result[0], Is.EqualTo(input2));
    }

    [TestCase("")]
    [TestCase(null)]
    public void Test_RemoveCar_NullOrEmptyCarNumber_ThrowsArgumentException(string carToRemove)
    {
        // Arrange
        string input1 = "CA9091BT";
        string input2 = "CO5666AT";

        _parkingSystem.ParkCar(input1);
        _parkingSystem.ParkCar(input2);

        // Act & Assert
        
        var exception = Assert.Throws<ArgumentException>(() => _parkingSystem.RemoveCar(carToRemove));
        Assert.That(exception.Message, Is.EqualTo("Car not found in the system."));
        Assert.That(_parkingSystem.GetAllParkedCars().Count, Is.EqualTo(2));
    }

    [Test]
    public void Test_GetAllParkedCars_AddAndRemoveCar_ReturnsExpectedCarsCollection()
    {
        // Arrange
        string input1 = "CA9091BT";
        string input2 = "CO5666AT";
        string input3 = "CB1414BE";

        _parkingSystem.ParkCar(input1);
        _parkingSystem.ParkCar(input2);
        _parkingSystem.ParkCar(input3);

        List<string> expected = new() { "CA9091BT" , "CO5666AT", "CB1414BE" };

        // Act
        
        List<string> result = _parkingSystem.GetAllParkedCars();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
