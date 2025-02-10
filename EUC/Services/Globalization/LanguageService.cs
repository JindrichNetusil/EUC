using EUC.Models;
using System.Globalization;

namespace EUC.Services
{
    public class LanguageService : ILanguageService
    {
        public async Task<IEnumerable<LanguageInfo>> GetDropdownLanguagesOptions()
        {
            List<LanguageInfo> languages =
            [
                new LanguageInfo
                (
                QuestionnaireEnums.Language.Czech,
                    CultureInfo.GetCultureInfo("cs-CZ"),
                    $@"https://upload.wikimedia.org/wikipedia/commons/c/cb/Flag_of_the_Czech_Republic.svg"
                ),
                new LanguageInfo
                (
                    QuestionnaireEnums.Language.English,
                    CultureInfo.GetCultureInfo("en-GB"),
                    $@"https://upload.wikimedia.org/wikipedia/commons/a/a5/Flag_of_the_United_Kingdom_%281-2%29.svg"
                )
            ];

            return languages;
        }
    }
}
