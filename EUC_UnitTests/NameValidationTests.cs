using EUC.Logic.Validation;

namespace EUC_UnitTests
{
    public class NameValidationTests
    {
        [Theory]
        [InlineData("Jan", false)]
        [InlineData("Petr", false)]
        [InlineData("O'connor", false)]
        [InlineData("M@rek", true)]
        [InlineData("Marie-Antoinneta", false)]
        [InlineData("Jan Amos Komenský", false)]
        [InlineData("John_Doe", true)]
        public void HasInvalidCharacters_ShouldReturnExpectedResult(string name, bool expected)
        {
            var result = NameValidator.HasInvalidCharacters(name);
            
            Assert.Equal(expected, result);
        }
    }
}
