using SafetyBP.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafetyBP.Domain.Interfaces
{
    public interface ISafetySectorBusiness : ICommonBusiness<SafetySector>
    {
        Task SyncDatabaseAsync(List<SafetySector> tasks);
        Task<List<SafetySector>> GetAllSectorsAsync();
    }
}
