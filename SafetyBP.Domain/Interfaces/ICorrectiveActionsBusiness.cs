using SafetyBP.Domain.Models.Modules.CorrectiveAction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafetyBP.Domain.Interfaces
{
    public interface ICorrectiveActionsBusiness : ICommonBusiness<CorrectiveActionSector>
    {
        Task SyncDatabaseAsync(IList<CorrectiveActionSector> correctiveActions);
        Task<IList<CorrectiveActionSector>> GetSectorsAsync();
        Task<IList<CorrectiveActionTopic>> GetTopicsAsync(long sectorId);
        Task<IList<CorrectiveActionTask>> GetTasksAsync(long topicId);

        Task UpdateTaskAsync(CorrectiveActionTask task, System.Action callback);
    }
}
