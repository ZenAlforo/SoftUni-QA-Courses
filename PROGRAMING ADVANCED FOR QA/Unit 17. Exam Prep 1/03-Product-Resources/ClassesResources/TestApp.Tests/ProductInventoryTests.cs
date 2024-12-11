using NUnit.Framework;
using System;
using TestApp.Product;

namespace TestApp.Tests;

[TestFixture]
public class ProductInventoryTests
{
    private ProductInventory _inventory = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._inventory = new();
    }
    
    [Test]
    public void Test_AddProduct_ProductAddedToInventory()
    {
        // Arrange
        string productName = "apples";
        double productPrice = 4.50;
        int quantity = 4;

        string expected = $"Product Inventory:{Environment.NewLine}" +
            $"{productName} - Price: ${productPrice:F2} - Quantity: {quantity}";

        // Act
        _inventory.AddProduct(productName, productPrice, quantity);
        string result = this._inventory.DisplayInventory();

        // Assert
        Assert.NotNull(this._inventory);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
    {
        // Arrange
        string expected = $"Product Inventory:";

        // Act
        
        string result = this._inventory.DisplayInventory();

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
    {
        // Arrange
        _inventory.AddProduct("cheese", 9.90, 1);
        _inventory.AddProduct("milk", 2.90, 3);
        _inventory.AddProduct("yellow cheese", 18.90, 1);

        string expected = $"Product Inventory:{Environment.NewLine}" +
            $"cheese - Price: $9.90 - Quantity: 1{Environment.NewLine}" +
            $"milk - Price: $2.90 - Quantity: 3{Environment.NewLine}" +
            $"yellow cheese - Price: $18.90 - Quantity: 1";

        // Act
        
        string result = this._inventory.DisplayInventory();

        // Assert
        Assert.NotNull(this._inventory);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
    {
        // Arrange, Act & Assert
        Assert.That(_inventory.CalculateTotalValue(), Is.EqualTo(0));
    }

    [Test]
    public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
    {
        // Arrange
        _inventory.AddProduct("cheese", 9.90, 1);
        _inventory.AddProduct("milk", 2.90, 3);
        _inventory.AddProduct("yellow cheese", 18.90, 1);

        double expected = 37.5;

        // Act

        double result = this._inventory.CalculateTotalValue();

        // Assert
        Assert.AreEqual(expected, result);
    }
}
