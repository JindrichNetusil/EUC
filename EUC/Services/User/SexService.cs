using EUC.Models;

namespace EUC.Services
{
    public class SexService : ISexService
    {
        public async Task<IEnumerable<SexInfo>> GetDropdownSexOptions()
        {
            List<SexInfo> items =
            [
                new (QuestionnaireEnums.Sex.Man),
                new (QuestionnaireEnums.Sex.Woman),
                new (QuestionnaireEnums.Sex.Other)
            ];

            return items;
        }
    }
}
