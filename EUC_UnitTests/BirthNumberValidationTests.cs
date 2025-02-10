using EUC.Logic.Validation;

namespace EUC_UnitTests
{
    public class BirthNumberValidatorTests
    {
        [Theory]
        [InlineData("930&1010510", true)]
        [InlineData("930101@0510", true)]
        [InlineData("930101//0510", true)]
        [InlineData("930101/0510", false)]
        [InlineData("9301010510", false)]
        public void HasInvalidCharactersOrMultipleSlashes_ShouldReturnExpectedResult(string birthNumber, bool expected)
        {
            var result = BirthNumberValidator.HasInvalidCharactersOrMultipleSlashes(birthNumber);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("123/4567890", true)]
        [InlineData("123/456789", true)]
        [InlineData("12/34567890", true)]
        [InlineData("123456/789", false)]
        [InlineData("123456/7890", false)]
        public void HasInvalidSlashPosition_ShouldReturnExpectedResult(string birthNumber, bool expected)
        {
            var result = BirthNumberValidator.HasInvalidSlashPosition(birthNumber);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("123456789", false)]
        [InlineData("1234567890", false)]
        [InlineData("123456/7890", false)]
        [InlineData("12345678900", true)]
        [InlineData("12345678", true)]
        public void HasInvalidDigitCount_ShouldReturnExpectedResult(string birthNumber, bool expected)
        {
            var result = BirthNumberValidator.HasInvalidDigitCount(birthNumber);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("5401234567", false)]
        [InlineData("9999999999", true)]
        public void HasInvalidDateConversion_ShouldReturnExpectedResult(string birthNumber, bool expected)
        {
            var result = BirthNumberValidator.HasInvalidDateConversion(birthNumber);
            Assert.Equal(expected, result);
        }
    }
}