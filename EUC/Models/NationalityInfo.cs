using EUC.Locales;
using System.Globalization;
using static EUC.Models.QuestionnaireEnums;

namespace EUC.Models
{
    public class NationalityInfo(Nationality nationality, string flagUrl)
    {
        public Nationality Nationality { get; set; } = nationality;
        public string FlagUrl { get; set; } = flagUrl;
        public string Text
        {
            get
            {
                return Resource.ResourceManager
                    .GetString($@"DropdownItem_Nationality_{Nationality}", CultureInfo.CurrentUICulture) ?? Nationality.ToString();
            }
        }
    }
}