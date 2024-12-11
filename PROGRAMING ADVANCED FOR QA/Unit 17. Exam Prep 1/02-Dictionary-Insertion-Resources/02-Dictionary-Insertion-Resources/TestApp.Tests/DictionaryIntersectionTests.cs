using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{
    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>();
        Dictionary<string, int> dict2 = new Dictionary<string, int>();
        Dictionary<string, int> expected = new Dictionary<string, int>();

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.IsTrue(result.Count == expected.Count);
        Assert.AreEqual(expected, result);
        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>()
        {
            {"sugar", 1},
            {"lemons", 1},
            {"apples", 6},
            {"water", 10}
        };
        Dictionary<string, int> dict2 = new Dictionary<string, int>();
        Dictionary<string, int> expected = new Dictionary<string, int>();

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.IsTrue(result.Count == expected.Count);
        Assert.AreEqual(expected, result);
        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>()
        {
            {"sugar", 1},
            {"lemons", 1},
            {"apples", 6},
            {"water", 10}
        };
        Dictionary<string, int> dict2 = new Dictionary<string, int>()         {
            {"oil", 1},
            {"potatoes", 10},
            {"salt", 1},
            {"cheese", 2}
        }; ;
        Dictionary<string, int> expected = new Dictionary<string, int>();

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.IsTrue(result.Count == expected.Count);
        Assert.AreEqual(expected, result);
        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>()
        {
            {"sugar", 1},
            {"lemons", 1},
            {"apples", 6},
            {"water", 10}
        };
        Dictionary<string, int> dict2 = new Dictionary<string, int>()         {
            {"oil", 1},
            {"potatoes", 10},
            {"salt", 1},
            {"cheese", 2},
            {"lemons", 1},
        }; ;
        Dictionary<string, int> expected = new Dictionary<string, int>() { { "lemons", 1 }, };

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.IsTrue(result.Count == expected.Count);
        Assert.AreEqual(expected, result);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new Dictionary<string, int>()
        {
            {"sugar", 1},
            {"lemons", 1},
            {"apples", 6},
            {"water", 8}
        };
        Dictionary<string, int> dict2 = new Dictionary<string, int>()         
        {
            {"sugar", 4},
            {"lemons", 2},
            {"apples", 3},
            {"water", 10}
        };
        Dictionary<string, int> expected = new Dictionary<string, int>() {};

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.IsTrue(result.Count == expected.Count);
        Assert.AreEqual(expected, result);
        Assert.That(result, Is.EqualTo(expected));
        Assert.IsEmpty(result);
    }
}

