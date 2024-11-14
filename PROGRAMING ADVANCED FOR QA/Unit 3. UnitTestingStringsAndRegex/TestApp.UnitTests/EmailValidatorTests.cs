using NUnit.Framework;

namespace TestApp.UnitTests;

public class EmailValidatorTests
{
    // TODO: finish the test
    [TestCase("samuelsp_91@abv.bg")]
    [TestCase("zenalforo@yahoo.com")]
    [TestCase("samuel.pankov@yahoo.co.uk")]
    public void Test_ValidEmails_ReturnsTrue(string email)
    {
        // Arrange

        // Act
        bool result = EmailValidator.IsValidEmail(email);

        // Assert
        Assert.That(result, Is.True);
    }

    // TODO: finish the test
    [TestCase("samuelsp_91@abv.b")]
    [TestCase("zenalforo_yahoo")]
    [TestCase("samuel=pankov@yahoo.co.uk")]
    public void Test_InvalidEmails_ReturnsFalse(string email)
    {
        // Arrange

        // Act
        bool result = EmailValidator.IsValidEmail(email);
        
        // Assert
        Assert.That(result, Is.False);
    }
}
