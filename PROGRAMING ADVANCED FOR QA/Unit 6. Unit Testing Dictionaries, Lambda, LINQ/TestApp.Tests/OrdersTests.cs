using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class OrdersTests
{
    [Test]
    public void Test_Order_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = { };

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.IsEmpty(result);
    }

    
    [Test]
    public void Test_Order_WithMultipleOrders_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = {"apple 1.99 2", "apple 1.99 1", "banana 3.5 2", "banana 1.25 1", "orange 1.5 1", "orange 0.99 1"};
        string expected = $"apple -> 5.97" +
            $"{Environment.NewLine}banana -> 3.75" + $"{Environment.NewLine}orange -> 1.98";
      

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Order_WithRoundedPrices_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = { "Milk 2.50 3", "Milk 3 4" };
        string expected = $"Milk -> 21.00";

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Order_WithDecimalQuantities_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = { "Milk 1.2 3.20", "Cocoa 5.1 1.25", "Milk 2 2.20" };
        string expected = $"Milk -> 10.80" +
            $"{Environment.NewLine}Cocoa -> 6.38";
            

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
