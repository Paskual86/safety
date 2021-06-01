using SafetyBP.Domain.Models;
using SafetyBP.Domain.OperationsResult;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafetyBP.Services.WebServices
{
    public interface ISpontaneousDiversionRestClient : IBaseRestClient
    {
        Task<BooleanOperationResult> SaveAsync(List<SafetySpontaneousDiversion> value, System.Action<BooleanOperationResult> callback);
    }
}