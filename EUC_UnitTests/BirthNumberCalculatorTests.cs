using EUC.Logic.Calculations;

namespace EUC_UnitTests
{
    public class BirthNumberCalculatorTests
    {
        [Theory]
        [InlineData("9107030009", "1991-07-03")]
        [InlineData("010250000", null)]
        [InlineData("", null)]
        [InlineData("0107030011", "2001-07-03")]
        [InlineData("010703/0011", "2001-07-03")]
        public void TryCalculateBirthdate_ReturnsCorrectDateOrNull(string birthNumber, string expectedDate)
        {
            DateTime? result = BirthnumberCalculator.TryCalculateBirthdate(birthNumber);

            if (expectedDate == null)
            {
                Assert.Null(result);
            }
            else
            {
                Assert.NotNull(result);
                Assert.Equal(DateTime.Parse(expectedDate), result.Value);
            }
        }

        [Theory]
        [InlineData("845128/6219", true)]
        [InlineData("9107030009", false)]
        [InlineData("0102101", false)]
        [InlineData("", null)]
        public void IsFemale_ReturnsCorrectResult(string birthNumber, bool? expectedResult)
        {
            bool? result = BirthnumberCalculator.IsFemale(birthNumber);
            Assert.Equal(expectedResult, result);
        }
    }
}
