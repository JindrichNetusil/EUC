using System.Globalization;

namespace EUC.Logic.Calculations
{
    public static class BirthnumberCalculator
    {
        public static DateTime? TryCalculateBirthdate(string birthNumber)
        {
            if (string.IsNullOrWhiteSpace(birthNumber)) return null;

            birthNumber = birthNumber.Replace("/", ""); // Odstranění lomítka
            if (birthNumber.Length != 9 && birthNumber.Length != 10) return null;

            // Získání roku, měsíce a dne
            int? year = GetBirthYear(birthNumber);

            if (!year.HasValue) return null;

            int month = int.Parse(birthNumber.Substring(2, 2));
            int day = int.Parse(birthNumber.Substring(4, 2));

            switch (month)
            {
                case > 70:
                    month -= 70; // Platí od roku 2024 pro ženy, v případě, že je časová řada posledního čtyřčíslí pro daný den už vyčerpána
                    break;
                case > 50:
                    month -= 50; // Pro ženy obecně
                    break;
                case > 20:
                    month -= 20; // Platí od roku 2024 pro muže, v případě, že je časová řada posledního čtyřčíslí pro daný den už vyčerpána
                    break;
                default:
                    break;
            }

            // Kontrola platnosti data
            if (DateTime.TryParseExact($"{year}-{month:D2}-{day:D2}", "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate))
            {
                return birthDate;
            }

            return null;
        }

        public static bool? IsFemale(string birthNumber)
        {
            if (string.IsNullOrWhiteSpace(birthNumber))
                return null;

            // Odstranění lomítka, pokud existuje
            birthNumber = birthNumber.Replace("/", "");

            // Ověření délky (minimálně 6 znaků pro rok, měsíc, den)
            if (birthNumber.Length < 6 || !birthNumber.All(char.IsDigit))
                return null;

            // Parsování měsíce narození
            if (!int.TryParse(birthNumber.Substring(2, 2), out int month))
                return null;

            // Ověření platnosti měsíce (1-12 pro muže, 51-62 pro ženy)
            if ((month < 1 || month > 12) && (month < 51 || month > 62))
                return null;

            // Pokud je měsíc větší než 50, jedná se o ženu
            return month > 50;
        }

        public static int? GetBirthYear(string birthNumber)
        {
            // Získání prvních dvou číslic (rok narození)
            int shortYear = int.Parse(birthNumber.Substring(0, 2));
            int fullYear;

            if (birthNumber.Length == 9)
            {
                if (shortYear < 54)
                {
                    fullYear = 1900 + shortYear;
                }
                else
                {
                    fullYear = 1800 + shortYear;
                }
            }
            else
            {
                // 10místná RČ mohou být z 1900–1999 nebo 2000–2099
                if (IsDivisibleByEleven(birthNumber))
                {
                    if (shortYear < 54)
                    {
                        if (shortYear > int.Parse(DateTime.Today.ToString("yy")))
                        {
                            return null; // Chyba, jedná se o dosud neexistující datum narození
                        }

                        fullYear = 2000 + shortYear;
                    }
                    else
                    {
                        fullYear = 1900 + shortYear;
                    }
                }
                else
                {
                    fullYear = 1900 + shortYear;
                }
            }

            return fullYear;
        }

        public static bool IsDivisibleByEleven(string birthNumber)
        {
            birthNumber = birthNumber.Replace("/", "");

            if (long.TryParse(birthNumber, out long numericBirthNumber))
            {
                return numericBirthNumber % 11 == 0;
            }
            else
            {
                return false;
            }
        }
    }
}
