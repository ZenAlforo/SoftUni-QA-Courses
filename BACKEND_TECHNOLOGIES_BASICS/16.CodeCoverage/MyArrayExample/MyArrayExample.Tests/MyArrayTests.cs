namespace MyArrayExample.Tests
{
    public class MyArrayTests
    {
        [Test]
        public void Replace_ShouldReplace_IfPositionIsValid()
        {
            // Arrange
            int size = 10;
            int position = 3;
            int newValue = 4;
            MyArray testArray = new MyArray(size);

            // Act
            var result = testArray.Replace(position, newValue);

            // Assert
            Assert.IsTrue(result);
            Assert.That(testArray.Array[position], Is.EqualTo(newValue));
        }

        [Test]
        public void Replace_ShouldThrowArgumentException_IfPositionIsLessThanZero()
        {
            // Arrange
            int size = 10;
            int position = -2;
            int newValue = 4;
            MyArray testArray = new MyArray(size);

            // Act
            var result = Assert.Throws<ArgumentException>(() => testArray.Replace(position, newValue));

            // Assert
            Assert.That(result.Message, Is.EqualTo("Postion must not be less than zero"));
        }

        [Test]
        public void Replace_ShouldThrowArgumentException_IfPositionIsBiggerThanLength()
        {
            // Arrange
            int size = 10;
            int position = 22;
            int newValue = 4;
            MyArray testArray = new MyArray(size);

            // Act
            var result = Assert.Throws<ArgumentException>(() => testArray.Replace(position, newValue));

            // Assert
            Assert.That(result.Message, Is.EqualTo("Position must be valid"));
        }

        [Test]
        public void FindMax_ShouldReturnMaxArrayValue_IfArrayHasOneOrMoreElements()
        {
            // Arrange
            MyArray testArray = new MyArray(20);

            // Act
            var result = testArray.FindMax();

            // Assert
            Assert.NotNull(result);
            Assert.That(result, Is.EqualTo(19));
        }

        [Test]
        public void FindMax_ShouldThrowArgumentOutOfRangeException_IfArrayIsEmpty()
        {
            // Arrange
            MyArray testArray = new MyArray(0);

            // Act
            var result = Assert.Throws<InvalidOperationException>(() => testArray.FindMax());

            // Assert
            Assert.That(result.Message, Is.EqualTo("Array is empty!"));
        }
    }
}