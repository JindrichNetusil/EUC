using EUC.Logic.Validation;

namespace EUC_UnitTests
{
    public class EmailValidationTests
    {
        [Theory]
        [InlineData("test email@example.com", true)]
        [InlineData("testemail@example.com", false)]
        public void ContainsSpaces_ShouldDetectSpaces(string email, bool expected)
        {
            Assert.Equal(expected, EmailValidator.ContainsSpaces(email));
        }

        [Theory]
        [InlineData("testemail.com", true)]
        [InlineData("test@email.com", false)]
        public void DoesNotContainAt_ShouldDetectMissingAtSymbol(string email, bool expected)
        {
            Assert.Equal(expected, EmailValidator.DoesNotContainAt(email));
        }

        [Theory]
        [InlineData("test@email.com", false)]
        [InlineData("test@email@com", true)]
        [InlineData("testemail.com", true)]
        public void HasInvalidFormat_ShouldDetectInvalidFormat(string email, bool expected)
        {
            Assert.Equal(expected, EmailValidator.HasInvalidFormat(email));
        }

        [Theory]
        [InlineData("@domain.com", true)]
        [InlineData("local@", true)]
        [InlineData("test@email.com", false)]
        public void HasEmptyParts_ShouldDetectEmptyParts(string email, bool expected)
        {
            Assert.Equal(expected, EmailValidator.HasEmptyParts(email));
        }

        [Theory]
        [InlineData("test@email.com", false)]
        [InlineData("test!@email.com", true)]
        [InlineData("invalid@domain.com", false)]
        public void HasLocalPartCorrupted_ShouldDetectInvalidLocalPart(string email, bool expected)
        {
            Assert.Equal(expected, EmailValidator.HasLocalPartCorrupted(email));
        }

        [Theory]
        [InlineData("test@domain.com", false)]
        [InlineData("test@domain", true)]
        [InlineData("test@domain..com", true)]
        [InlineData("test@domain@com", true)]
        public void HasDomainPartCorrupted_ShouldDetectInvalidDomainPart(string email, bool expected)
        {
            Assert.Equal(expected, EmailValidator.HasDomainPartCorrupted(email));
        }
    }
}
