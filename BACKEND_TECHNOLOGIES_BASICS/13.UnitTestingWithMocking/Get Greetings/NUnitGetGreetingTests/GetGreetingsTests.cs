using GetGreeting;
using Moq;
using NUnitGetGreetingTests;

namespace NUnitGetGreetingTests

{
    public class GreetingsProviderTests
    {

        private GreetingProvider _greetingProvider;
        private Mock<ITimeProvider> _mockedTimeProvider;

        [SetUp]
        public void Setup()
        {
            _mockedTimeProvider = new Mock<ITimeProvider>();
            _greetingProvider = new GreetingProvider(_mockedTimeProvider.Object);  
        }

        [TestCase("Good morning!", 10)]
        [TestCase("Good evening!", 20)]
        [TestCase("Good night!", 3)]
        [TestCase("Good afternoon!", 14)]
        public void GetGreetings_ShouldReturnACorrectMessage_WhenItIsCertainTime(string expectedGreeting, int hour)
        {
            // Arrange
            _mockedTimeProvider.Setup(time => time.GetCurrentTime()).Returns(new DateTime(2025, 10, 9, hour, 58, 56));
            
            // Act
            var result = _greetingProvider.GetGreeting();

            // Assert
            Assert.That(result, Is.EqualTo(expectedGreeting));
        }
    }
}