using GetGreeting;
using Moq;

namespace GetGreetingsTests
{
    public class GreetingProviderTests
    {
        // Declaration of fields
        private GreetingProvider _greetingProvider;
        private Mock<ITimeProvider> _mockedTimeProvider;

        [SetUp]
        public void Setup()
        {
            // Setup is same as a Constructor in XUnit (of the field created above);
            _mockedTimeProvider = new Mock<ITimeProvider>();
            _greetingProvider = new GreetingProvider(_mockedTimeProvider.Object);
        }

        [Test]
        public void GetGreetings_ShouldReturnAMorningGreetingMessage_WhenItIsMorning()
        {
            // Assert
            _mockedTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2000, 2, 2, 9, 9, 9));

            // Act
            var result = _greetingProvider.GetGreeting();

            // Assert
            Assert.AreEqual("Good morning!", result);
        }

        [Test]
        public void GetGreetings_ShouldReturnAnAfternoonGreetingMessage_WhenItIsAfternoon()
        {
            // Assert
            _mockedTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2000, 2, 2,13,10, 50));

            // Act
            var result = _greetingProvider.GetGreeting();

            // Assert
            Assert.AreEqual("Good afternoon!", result);
        }

        [Test]
        public void GetGreetings_ShouldReturnAnEveningGreetingMessage_WhenItIsEvening()
        {
            // Arrange
            _mockedTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2000, 2, 2, 19, 9, 9));

            // Act
            var result = _greetingProvider.GetGreeting();

            // Assert
            Assert.AreEqual("Good evening!", result);
        }

        [Test]
        public void GetGreetings_ShouldReturnANightGreetingMessage_WhenItIsNight()
        {
            // Arrange
            _mockedTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(1994, 4, 5, 23, 20, 20));

            // Act
            var result = _greetingProvider.GetGreeting();

            // Assert
            Assert.AreEqual("Good night!", result);
        }
    }
}