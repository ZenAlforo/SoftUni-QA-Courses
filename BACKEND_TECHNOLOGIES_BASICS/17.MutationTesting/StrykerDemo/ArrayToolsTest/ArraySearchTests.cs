using ArrayTools;
using FluentAssertions;

namespace ArrayToolsTest
{
    [TestFixture]
    public class ArraySearchTests
    {
        [Test]
        public void CheckArrayFindElement_ShouldReturnIndex_IfElementExist()
        {
            // Arrange
            int[] numbers = { 1, 3, 5, 2, 4 };
            int valueToFind = 2;
            int expected = 3;

            // Act
            int result = ArraySearch.FindIndex(numbers, valueToFind);

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public void CheckArrayFindElement_ShouldReturnMinusOne_IfElementDoesNotExist()
        {
            // Arrange
            int[] numbers = { 1, 3, 5, 2, 4 };
            int valueToFind = 8;
            int expected = -1;

            // Act
            int result = ArraySearch.FindIndex(numbers, valueToFind);

            // Assert
            result.Should().Be(expected);
        }
    }
}