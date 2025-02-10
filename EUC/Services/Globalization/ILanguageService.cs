
using EUC.Models;

namespace EUC.Services
{
    public interface ILanguageService
    {
        Task<IEnumerable<LanguageInfo>> GetDropdownLanguagesOptions();
    }
}