using SafetyBP.Domain.OperationsResult;
using System.Threading.Tasks;

namespace SafetyBP.Services.WebServices
{
    public interface ICorrectiveActionRestClient : IBaseRestClient
    {
        Task<BooleanOperationResult> SaveTaskAsync(long taskId, short status, System.Action<BooleanOperationResult> callback);
        Task<BooleanOperationResult> SavePhotoTaskAsync(long taskId, string content, System.Action<BooleanOperationResult> callback);
        Task<BooleanOperationResult> SaveCommentTaskAsync(long taskId, string content, System.Action<BooleanOperationResult> callback);
    }
}