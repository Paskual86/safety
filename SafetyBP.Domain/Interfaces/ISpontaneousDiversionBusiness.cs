using SafetyBP.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafetyBP.Domain.Interfaces
{
    public interface ISpontaneousDiversionBusiness : ICommonBusiness<SafetySpontaneousDiversion>
    {
        Task AddSpontaneousDiversionAsync(SafetySpontaneousDiversion value);
        Task<bool> AnyPendingToFinalizeAsync();
        Task<IEnumerable<SafetySpontaneousDiversion>> GetPendingToFinalizeListAsync();
        Task SendToServer(string roundName, System.Action callbackSuccess);

        Task Clear();
    }
}
