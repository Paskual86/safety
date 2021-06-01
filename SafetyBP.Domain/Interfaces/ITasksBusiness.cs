using SafetyBP.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafetyBP.Domain.Interfaces
{
    public interface ITasksBusiness : ICommonBusiness<SafetyTask> {
        Task SyncDatabaseAsync(List<SafetyTask> tasks);
        Task UpdateCheckListAsync(SafetyTaskCheckList checkList, System.Action callback);
        Task UpdateTaskDetailAsync(SafetyTaskDetails checkList);
        Task<int> GetCountAsync();
    }
}
