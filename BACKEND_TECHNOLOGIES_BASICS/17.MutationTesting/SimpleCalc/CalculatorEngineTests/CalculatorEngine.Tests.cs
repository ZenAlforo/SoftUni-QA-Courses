using SimpleCalc;

namespace SimpleCalcTests
{
    public class Tests
    {
        public CalculatorEngine _calculatorEngine = new CalculatorEngine();

        [SetUp]
        public void Setup()
        {
        }

        [TestCase(10, 2, 12)]
        [TestCase(-10, 3, -7)]
        [TestCase(10, -2, 8)]
        public void SumMethod_ShouldReturnCorrectAnswer(int a, int b, int c)
        {
            // Act & Assert
            var result = _calculatorEngine.Sum(a, b);
            Assert.That(result, Is.EqualTo(c));
        }

        [TestCase(10, 2, 8)]
        [TestCase(-10, 3, -13)]
        [TestCase(10, -2, 12)]
        public void SubtractMethod_ShouldReturnCorrectAnswer(int a, int b, int c)
        {
            // Act & Assert
            var result = _calculatorEngine.Subtract(a, b);
            Assert.That(result, Is.EqualTo(c));
        }

        [TestCase(10, 2, 20)]
        [TestCase(-10, 3, -30)]
        [TestCase(10, -2, -20)]
        public void MultiplyMethod_ShouldReturnCorrectAnswer(int a, int b, int c)
        {
            // Act & Assert
            var result = _calculatorEngine.Multiply(a, b);
            Assert.That(result, Is.EqualTo(c));
        }

        [TestCase(10, 2, 5)]
        [TestCase(-10, 3, -3)]
        [TestCase(10, -2, -5)]
        public void DivisionMethod_ShouldReturnCorrectAnswer(int a, int b, int c)
        {
            // Act & Assert
            var result = _calculatorEngine.Division(a, b);
            Assert.That(result, Is.EqualTo(c));
        }

        [TestCase(10)]
        [TestCase(-3)]
        [TestCase(0)]
        public void DivisionMethod_ShouldReturnDivisionToZeroException_WhenNumberIsDividedToZero(int a)
        {
            // Act & Assert
            var result = Assert.Throws<DivideByZeroException>(() => _calculatorEngine.Division(a, 0));
        }
    }
}