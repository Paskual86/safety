using SafetyBP.Domain.OperationsResult;
using System.Threading.Tasks;

namespace SafetyBP.Services.WebServices
{
    public interface ITaskBoardRestClient: IBaseRestClient
    {
        Task<BooleanOperationResult> SaveCommentAsync(int id, string comment, System.Action<BooleanOperationResult> callback);
        Task<BooleanOperationResult> SavePhotoAsync(int id, string photo, System.Action<BooleanOperationResult> callback);
        Task<BooleanOperationResult> SaveTaskAsync(int id, string value, System.Action<BooleanOperationResult> callback);
    }
}