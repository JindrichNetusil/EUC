using EUC.Locales;
using EUC.Logic.Validation;
using EUC.Models;
using System.Globalization;

namespace EUC.Services
{
    public static class ValidationService
    {
        public static bool IsQuestionnaireModelValid(QuestionnaireModel model)
        {
            if (model == null)
                return false;

            if (!IsNameValid(model.FirstName))
                return false;

            if (!IsNameValid(model.LastName))
                return false;

            if (!model.HasNoBirthNumber && !IsBirthNumberValid(model.BirthNumber))
                return false;

            if (model.Birthday >= DateTime.Today)
                return false;

            if (!model.Sex.HasValue)
                return false;

            if (!IsEmailValid(model.Email))
                return false;

            if (!model.Nationality.HasValue)
                return false;

            if (!model.DidAcceptGdpr)
                return false;

            return true;
        }

        public static bool IsNameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            if (NameValidator.HasInvalidCharacters(name))
                return false;

            return true;
        }

        public static bool IsBirthNumberValid(string birthNumber)
        {
            if (string.IsNullOrWhiteSpace(birthNumber))
                return false;

            if (BirthNumberValidator.HasInvalidCharactersOrMultipleSlashes(birthNumber))
                return false;

            if (BirthNumberValidator.HasInvalidSlashPosition(birthNumber))
                return false;

            if (BirthNumberValidator.HasInvalidDigitCount(birthNumber))
                return false;

            if (BirthNumberValidator.HasInvalidDateConversion(birthNumber))
                return false;

            return true;
        }

        public static bool IsEmailValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            if (EmailValidator.ContainsSpaces(email))
                return false;

            if (EmailValidator.DoesNotContainAt(email))
                return false;

            if (EmailValidator.HasInvalidFormat(email))
                return false;

            if (EmailValidator.HasEmptyParts(email))
                return false;

            if (EmailValidator.HasLocalPartCorrupted(email))
                return false;

            if (EmailValidator.HasDomainPartCorrupted(email))
                return false;

            return true;
        }

        /// <summary>
        /// Name validation for component MudTextField (requires string as return value)
        /// </summary>
        public static string GetNameErrors(string name)
        {
            if (!string.IsNullOrWhiteSpace(name) && NameValidator.HasInvalidCharacters(name))
            {
                return GetValidationMessage("Validation_Name_HasInvalidCharacters");
            }

            return string.Empty;
        }

        /// <summary>
        /// Birth number validation for component MudTextField (requires string as return value)
        /// </summary>
        public static string GetBirthNumberErrors(string birthNumber)
        {
            if (!string.IsNullOrWhiteSpace(birthNumber))
            {
                if (BirthNumberValidator.HasInvalidCharactersOrMultipleSlashes(birthNumber))
                    return GetValidationMessage("Validation_BirthNumber_OnlyDigitsOneSlash");

                if (BirthNumberValidator.HasInvalidSlashPosition(birthNumber))
                    return GetValidationMessage("Validation_BirthNumber_SlashPosition");

                if (BirthNumberValidator.HasInvalidDigitCount(birthNumber))
                    return GetValidationMessage("Validation_BirthNumber_DigitsCount");

                if (BirthNumberValidator.HasInvalidDateConversion(birthNumber))
                    return GetValidationMessage("Validation_BirthNumber_DateConversionFailed");
            }

            return string.Empty;
        }

        /// <summary>
        /// Email validation for component MudTextField (requires string as return value)
        /// </summary>
        public static string GetEmailErrors(string email)
        {
            if (!string.IsNullOrWhiteSpace(email))
            {
                if (EmailValidator.ContainsSpaces(email))
                    return GetValidationMessage("Validation_Email_NoSpaces");

                if (EmailValidator.DoesNotContainAt(email))
                    return GetValidationMessage("Validation_Email_MissingAt");

                if (EmailValidator.HasInvalidFormat(email))
                    return GetValidationMessage("Validation_Email_InvalidFormat");

                if (EmailValidator.HasEmptyParts(email))
                    return GetValidationMessage("Validation_Email_EmptyParts");

                if (EmailValidator.HasLocalPartCorrupted(email))
                    return GetValidationMessage("Validation_Email_InvalidLocalPart");

                if (EmailValidator.HasDomainPartCorrupted(email))
                    return GetValidationMessage("Validation_Email_InvalidDomain");
            }

            return string.Empty;
        }

        private static string GetValidationMessage(string key)
        {
            return Resource.ResourceManager.GetString(key, CultureInfo.CurrentUICulture) ?? key;
        }
    }
}
