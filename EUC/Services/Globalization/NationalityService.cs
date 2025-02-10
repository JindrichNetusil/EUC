using EUC.Models;

namespace EUC.Services
{
    public class NationalityService : INationalityService
    {
        public async Task<IEnumerable<NationalityInfo>> GetDropdownNationalityOptions()
        {
            List<NationalityInfo> nationalities =
            [
                new NationalityInfo
                (
                    QuestionnaireEnums.Nationality.Czech, 
                    @$"https://upload.wikimedia.org/wikipedia/commons/c/cb/Flag_of_the_Czech_Republic.svg"
                ),
                new NationalityInfo
                (
                    QuestionnaireEnums.Nationality.Slovak, 
                    @$"https://upload.wikimedia.org/wikipedia/commons/e/e6/Flag_of_Slovakia.svg"
                ),
                new NationalityInfo
                (
                    QuestionnaireEnums.Nationality.Other, 
                    @$"https://upload.wikimedia.org/wikipedia/commons/b/b7/Flag_of_Europe.svg"
                ),
            ];

            return nationalities;
        }
    }
}
