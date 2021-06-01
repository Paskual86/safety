using SafetyBP.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafetyBP.Domain.Interfaces
{
    public interface IModuleCheckListsBusiness : ICommonBusiness<SafetyCheckList>
    {
        Task SyncDatabaseAsync(List<SafetyCheckList> tasks);
        Task<int> GetCountAsync();
        Task UpdateCheckListQuestionValue(SafetyCheckListQuestion value);
        Task SetNAStatusCheckListQuestion(int checkListId, bool status);
        Task SettleUpdateCheckListQuestionOperation(SafetyCheckListQuestion value);

        Task FinalizeCheckList(SafetyCheckListDetail value);
    }
}
