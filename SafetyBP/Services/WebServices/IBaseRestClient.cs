using SafetyBP.Domain.OperationsResult;
using System;
using System.Threading.Tasks;

namespace SafetyBP.Services.WebServices
{
    public interface IBaseRestClient 
    {
        Task CommitOperation(int operationId, Action<BooleanOperationResult> callback);
    }
}