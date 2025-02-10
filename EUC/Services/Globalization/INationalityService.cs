
using EUC.Models;

namespace EUC.Services
{
    public interface INationalityService
    {
        Task<IEnumerable<NationalityInfo>> GetDropdownNationalityOptions();
    }
}