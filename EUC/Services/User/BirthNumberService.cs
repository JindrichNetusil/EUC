using EUC.Logic.Calculations;

namespace EUC.Services
{
    public static class BirthNumberService
    {
        public static DateTime? TryCalculateBirthdate(string birthNumber)
        {
            return BirthnumberCalculator.TryCalculateBirthdate(birthNumber);
        }

        public static bool? IsFemale(string birthNumber)
        {
            return BirthnumberCalculator.IsFemale(birthNumber);
        }
    }
}
