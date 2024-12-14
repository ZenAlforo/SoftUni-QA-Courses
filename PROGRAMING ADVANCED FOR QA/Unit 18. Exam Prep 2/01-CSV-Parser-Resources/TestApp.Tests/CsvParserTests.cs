using NUnit.Framework;
using System.Linq;

namespace TestApp.Tests;

[TestFixture]
public class CsvParserTests
{
    [Test]
    public void Test_ParseCsv_EmptyInput_ReturnsEmptyArray()
    {
        // Arrange
        string cvsData = string.Empty;

        // Act
        string[] result = CsvParser.ParseCsv(cvsData);

        // Assert
        Assert.AreEqual(0, result.Length);
        Assert.IsEmpty(result);
        Assert.That(result, Is.Empty);
        Assert.That(result.Count, Is.EqualTo(0));
    }

    [Test]
    public void Test_ParseCsv_SingleField_ReturnsArrayWithOneElement()
    {
        // Arrange
        string cvsData = "Samuel";
        string[] expected = { "Samuel" };

        // Act
        string[] result = CsvParser.ParseCsv(cvsData);

        // Assert
        Assert.That(result, Is.EqualTo (expected));
    }

    [Test]
    public void Test_ParseCsv_MultipleFields_ReturnsArrayWithMultipleElements()
    {
        // Arrange
        string cvsData = "Samuel,Cat,Dog";
        string[] expected = { "Samuel", "Cat", "Dog" };

        // Act
        string[] result = CsvParser.ParseCsv(cvsData);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_ParseCsv_TrimsWhiteSpace_ReturnsCleanArray()
    {
        // Arrange
        string cvsData = "   Samuel, Cat, Dog  ";
        string[] expected = { "Samuel", "Cat", "Dog" };

        // Act
        string[] result = CsvParser.ParseCsv(cvsData);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
