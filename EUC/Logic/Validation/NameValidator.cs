using System.Text.RegularExpressions;

namespace EUC.Logic.Validation
{
    public static class NameValidator
    {
        public static bool HasInvalidCharacters(string name)
        {
            return !Regex.IsMatch(name, @"^[A-Za-zÁ-Žá-ž '-]+$");
        }
    }
}
