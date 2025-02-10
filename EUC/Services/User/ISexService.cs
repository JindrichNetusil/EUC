
using EUC.Models;

namespace EUC.Services
{
    public interface ISexService
    {
        Task<IEnumerable<SexInfo>> GetDropdownSexOptions();
    }
}