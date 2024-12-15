using System;
using System.Collections.Generic;

namespace TestApp;

public class ParkingSystem
{
    private List<string> cars;

    public int CarCount => cars.Count;

    public ParkingSystem()
    {
        this.cars = new List<string>();
    }
    public void ParkCar(string car)
    {
        if (string.IsNullOrWhiteSpace(car))
        {
            throw new ArgumentException("Car number cannot be empty or whitespace.");
        }
        cars.Add(car);
    }

    public void RemoveCar(string car)
    {
        if (!cars.Contains(car))
        {
            throw new ArgumentException("Car not found in the system.");
        }
        cars.Remove(car);
    }

    public List<string> GetAllParkedCars()
    {
        return new List<string>(cars);
    }
}   
