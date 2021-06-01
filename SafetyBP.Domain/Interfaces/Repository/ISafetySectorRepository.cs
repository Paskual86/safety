using SafetyBP.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafetyBP.Domain.Interfaces.Repository
{
    public interface ISafetySectorRepository
    {
        Task SyncDatabaseAsync(List<SafetySector> sectors);
    }
}
