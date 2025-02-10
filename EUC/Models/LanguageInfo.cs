using EUC.Locales;
using System.Globalization;
using static EUC.Models.QuestionnaireEnums;

namespace EUC.Models
{
    public class LanguageInfo(Language language, CultureInfo culture, string flagUrl)
    {
        public Language Language { get; set; } = language;
        public CultureInfo Culture { get; set; } = culture;
        public string FlagUrl { get; set; } = flagUrl;
        public string Text
        {
            get
            {
                return Resource.ResourceManager
                    .GetString($@"DropdownItem_Language_{Language}", CultureInfo.CurrentUICulture) ?? Language.ToString();
            }
        }
    }
}