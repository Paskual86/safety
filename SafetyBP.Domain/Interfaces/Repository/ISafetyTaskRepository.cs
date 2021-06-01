using SafetyBP.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafetyBP.Domain.Interfaces.Repository
{
    public interface ISafetyTaskRepository
    {
        Task<IEnumerable<SafetyTask>> GetListAsync();
        Task SyncDatabaseAsync(List<SafetyTask> tasks);
        Task UpdateCheckListAsync(SafetyTaskCheckList checkList);
        Task UpdateTaskDetailAsync(SafetyTaskDetails checkList);
        Task<int> GetCountAsync();
    }
}
