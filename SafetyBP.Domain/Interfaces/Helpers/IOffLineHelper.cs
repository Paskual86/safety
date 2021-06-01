using SafetyBP.Domain.Entities;
using SafetyBP.Domain.OperationsResult;
using System;
using System.Threading.Tasks;

namespace SafetyBP.Domain.Interfaces.Helpers
{
    public interface IOffLineHelper
    {
        Task Add(OffLineRequest request);
        Task Add(int requestId, string request, string url, string module);
        Task Remove(int requestId);
        Task Synchronize(string userId);
        string SerializateObject(object request);
        bool IsConnected();
        int GetHashCode(string request);
        Task<int> BeginOperation(string module);
        Task CommitOperation(int operationId, Action<BooleanOperationResult> callback);
    }
}
