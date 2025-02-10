using System.Text.RegularExpressions;

namespace EUC.Logic.Validation
{
    public static class EmailValidator
    {
        public static bool ContainsSpaces(string email)
        {
            return email.Contains(" ");
        }

        public static bool DoesNotContainAt(string email)
        {
            return !email.Contains("@");
        }

        public static bool HasInvalidFormat(string email)
        {
            var parts = email.Split('@');
            return parts.Length != 2;
        }

        public static bool HasEmptyParts(string email)
        {
            var parts = email.Split('@');
            string localPart = parts[0];
            string domainPart = parts[1];

            return string.IsNullOrWhiteSpace(localPart) || string.IsNullOrWhiteSpace(domainPart);
        }

        public static bool HasLocalPartCorrupted(string email)
        {
            var parts = email.Split('@');
            string localPart = parts[0];

            return !Regex.IsMatch(localPart, @"^[a-zA-Z0-9._%+-]+$");
        }

        public static bool HasDomainPartCorrupted(string email)
        {
            var parts = email.Split('@');
            string domainPart = parts[1];

            return !Regex.IsMatch(domainPart, @"^[a-zA-Z0-9]+([.-][a-zA-Z0-9]+)*\.[a-zA-Z]{2,}$");
        }
    }
}
