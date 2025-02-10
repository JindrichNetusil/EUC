using EUC.Locales;
using static EUC.Models.QuestionnaireEnums;
using System.Globalization;

namespace EUC.Models
{
    public class SexInfo(Sex sex)
    {
        public Sex Sex { get; set; } = sex;
        public string Text
        {
            get
            {
                return Resource.ResourceManager
                    .GetString($@"DropdownItem_Sex_{Sex}", CultureInfo.CurrentUICulture) ?? Sex.ToString();
            }
        }
    }
}
