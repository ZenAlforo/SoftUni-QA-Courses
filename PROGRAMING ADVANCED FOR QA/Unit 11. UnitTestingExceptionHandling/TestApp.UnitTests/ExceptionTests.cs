using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "cat";
        string expected = "tac";

        // Act
        string result = _exceptions.ArgumentNullReverse(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null;
        string expected = "String cannot be null. (Parameter 's')";

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentNullReverse(input), Throws.ArgumentNullException);

        try
        {
            this._exceptions.ArgumentNullReverse(input);
        }
        catch (ArgumentNullException ex)
        {
            Assert.AreEqual(expected, ex.Message);
        }
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        // Arrange
        decimal price = 509;
        decimal discount = 35;
        decimal expected = 330.85m;

        // Act
        decimal result = _exceptions.ArgumentCalculateDiscount(price, discount);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal price = 500;
        decimal discount = -20;
        string expected = "Discount must be between 0 and 100. (Parameter 'discount')";

        // Act & Assert

        ArgumentException exception = Assert.Throws<ArgumentException>(()=> this._exceptions.ArgumentCalculateDiscount(price, discount));
        Assert.AreEqual(exception.Message, expected);

    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 110.0m;

        string expected = "Discount must be between 0 and 100. (Parameter 'discount')";

        // Act & Assert

        ArgumentException exception = Assert.Throws<ArgumentException>(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount));
        Assert.AreEqual(exception.Message, expected);

    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        // Arrange
        int[] array = { 1, 2, 3 };
        int index = 1;
        int expected = 2;

        // Act
        int result = _exceptions.IndexOutOfRangeGetElement(array, index);

        // Assert
        Assert.AreEqual(expected, result);
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 1, 2, 3 };
        int index = -2;
        string expected = "Index is out of range.";

        // Act & Assert
        IndexOutOfRangeException error = Assert.Throws<IndexOutOfRangeException>(() => _exceptions.IndexOutOfRangeGetElement(array, index));
        Assert.AreEqual(expected, error.Message);
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length;

        // Act & Assert
        IndexOutOfRangeException error = Assert.Throws<IndexOutOfRangeException>(() => _exceptions.IndexOutOfRangeGetElement(array, index));
        Assert.AreEqual("Index is out of range.", error.Message);
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = 7;

        // Act & Assert
        // checking the type of the exception thrown
        Assert.That(() => _exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());

        try
        {
            _exceptions.IndexOutOfRangeGetElement(array, index);
        } 
        catch (IndexOutOfRangeException ex) 
        {
            Assert.AreEqual("Index is out of range.", ex.Message);
        }
        // other way to do it
        //IndexOutOfRangeException error = Assert.Throws<IndexOutOfRangeException>(() => _exceptions.IndexOutOfRangeGetElement(array, index));
        //Assert.AreEqual("Index is out of range.", error.Message);
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        // Arrange
        bool input = true;
        string expected = "User logged in.";

        // Act
        string result = _exceptions.InvalidOperationPerformSecureOperation(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        // Arrange
        bool input = false;

        // Act & Assert
        var result = Assert.Throws<InvalidOperationException> (() => _exceptions.InvalidOperationPerformSecureOperation(input));
        Assert.That(result.Message, Is.EqualTo("User must be logged in to perform this operation."));
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        // Arrange
        string number = "333";
        int expected = 333;

        // Act
        int result = _exceptions.FormatExceptionParseInt(number);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        // Arrange
        string input = "233klm";
        string expected = "Input is not in the correct format for an integer.";

        // Act & Assert
        Assert.That(() => _exceptions.FormatExceptionParseInt(input), Throws.InstanceOf<FormatException>());

        try
        {
            _exceptions.FormatExceptionParseInt(input);
        }
        catch (FormatException ex)
        {
            Assert.AreEqual(expected, ex.Message);
        }
    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        // Arrange
        Dictionary<string, int> keyValuePairs = new Dictionary<string, int> { {"cat", 1}, { "dog", 2 }, { "parrot", 3 } };
        int expected = 2;

        // Act
        int result = _exceptions.KeyNotFoundFindValueByKey(keyValuePairs, "dog");

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, int> keyValuePairs = new Dictionary<string, int> { { "cat", 1 }, { "dog", 2 }, { "parrot", 3 } };
        string expected = "The specified key was not found in the dictionary.";

        // Act & Assert
        var error = Assert.Throws<KeyNotFoundException>(() => _exceptions.KeyNotFoundFindValueByKey(keyValuePairs, "monkey"));
        Assert.That(error.Message, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        // Arrange
        int a = 20;
        int b = 200000;
        int expectedSum = 200020;

        // Act
        int result = _exceptions.OverflowAddNumbers(a, b);

        // Assert
        Assert.AreEqual(expectedSum, result);
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        // Arrange
        int a = int.MaxValue;
        int b = 1;
        string expectedErrorMessage = "Arithmetic overflow occurred during addition.";

        // Act & Asser
        Assert.That(()=>  _exceptions.OverflowAddNumbers(a,b), Throws.TypeOf<OverflowException>());
        try
        {
            _exceptions.OverflowAddNumbers(a, b);
        }
        catch (OverflowException ex)
        {
            Assert.That(ex.Message, Is.EqualTo(expectedErrorMessage));
        }
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        // Arrange
        int a = int.MinValue;
        int b = -1;
        string expectedErrorMessage = "Arithmetic overflow occurred during addition.";

        // Act & Asser
        Assert.That(() => _exceptions.OverflowAddNumbers(a, b), Throws.TypeOf<OverflowException>());
        try
        {
            _exceptions.OverflowAddNumbers(a, b);
        }
        catch (OverflowException ex)
        {
            Assert.That(ex.Message, Is.EqualTo(expectedErrorMessage));
        }
    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        // Arrange
        int a = 20;
        int b = 2;
        int expectedSum = 10;

        // Act
        int result = _exceptions.DivideByZeroDivideNumbers(a, b);

        // Assert
        Assert.AreEqual(expectedSum, result);
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        int a = 212;
        int b = 0;
        string expectedErrorMessage = "Division by zero is not allowed.";

        // Act & Asser
        Assert.That(() => _exceptions.DivideByZeroDivideNumbers(a, b), Throws.TypeOf<DivideByZeroException>());
        try
        {
            _exceptions.DivideByZeroDivideNumbers(a, b);
        }
        catch (DivideByZeroException ex)
        {
            Assert.That(ex.Message, Is.EqualTo(expectedErrorMessage));
        }
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        // Arrange
        int[] numbers = new int[] { 1, 2, 3, 4 };
        int index = 3;
        int expected = 10;


        // Act
        int result = _exceptions.SumCollectionElements(numbers, index);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        // Arrange
        int[] numbers = null;
        int index = 2;
        string expected = "Collection cannot be null. (Parameter 'collection')";


        // Act & Assert
        Assert.That(() => _exceptions.SumCollectionElements(numbers, index), Throws.TypeOf<ArgumentNullException>());
        try
        {
            _exceptions.SumCollectionElements(numbers, index);
        }
        catch (ArgumentNullException ex)
        {
            Assert.That(ex.Message, Is.EqualTo(expected));
        }
    }

    [TestCase(-10)]
    [TestCase(-1)]
    [TestCase(4)]
    [TestCase(6)]
    [TestCase(100)]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException(int index)
    {
        // Arrange
        int[] numbers = new int[] { 1, 2, 3, 4 };
        string expected = "Index has to be within bounds.";

        // Act & Assert
        Assert.That(() => _exceptions.SumCollectionElements(numbers, index), Throws.TypeOf<IndexOutOfRangeException>());
        try
        {
            _exceptions.SumCollectionElements(numbers, index);
        }
        catch (IndexOutOfRangeException ex)
        {
            Assert.That(ex.Message, Is.EqualTo(expected));
        }
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        // Arrange
        Dictionary<string, string> testDict = new Dictionary<string, string>()
        {
            ["five"] = "2",
            ["cat"] = "green",
            ["length"] = "1200m"
        };

        string key = "five";
        int expected = 2;

        // Act
        int result = _exceptions.GetElementAsNumber(testDict, key);

        // Assert
        Assert.That(expected, Is.EqualTo(result));  
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, string> testDict = new Dictionary<string, string>()
        {
            ["five"] = "2",
            ["cat"] = "green",
            ["length"] = "1200m"
        };

        string key = "dog";
        string expectedErrorMessage = "Key not found in the dictionary.";

        // Act & Assert
        
        var error = Assert.Throws<KeyNotFoundException> (() => _exceptions.GetElementAsNumber(testDict, key));
        Assert.AreEqual(expectedErrorMessage, error.Message);

    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        // Arrange
        Dictionary<string, string> testDict = new Dictionary<string, string>()
        {
            ["five"] = "2",
            ["cat"] = "green",
            ["length"] = "1200m"
        };

        string key = "cat";
        string expectedErrorMessage = "Can't parse string.";

        // Act & Assert

        var error = Assert.Throws<FormatException>(() => _exceptions.GetElementAsNumber(testDict, key));
        Assert.AreEqual(expectedErrorMessage, error.Message);
        Assert.That(error.Message, Is.EqualTo(expectedErrorMessage));
        Assert.IsTrue(error.Message.Contains(expectedErrorMessage));
    }
}
