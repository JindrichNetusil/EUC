using EUC.Services;
using System.Text.RegularExpressions;

namespace EUC.Logic.Validation
{
    public static class BirthNumberValidator
    {
        public static bool HasInvalidCharactersOrMultipleSlashes(string birthNumber)
        {
            return !Regex.IsMatch(birthNumber, @"^\d*\/?\d*$");
        }

        public static bool HasInvalidSlashPosition(string birthNumber)
        {
            return birthNumber.Contains('/') && !Regex.IsMatch(birthNumber, @"^\d{6}/\d{3,4}$");
        }

        public static bool HasInvalidDigitCount(string birthNumber)
        {
            return !Regex.IsMatch(birthNumber, @"^\d{9,10}$|^\d{6}/\d{3,4}$");
        }

        public static bool HasInvalidDateConversion(string birthNumber)
        {
            return BirthNumberService.TryCalculateBirthdate(birthNumber) == null;
        }
    }
}
