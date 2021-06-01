using SafetyBP.Domain.OperationsResult;
using System.Threading.Tasks;

namespace SafetyBP.Services.WebServices
{
    public interface ICheckListRestClient : IBaseRestClient
    {
        Task<BooleanOperationResult> SaveCheckListAsync(int id, int surveyId, string value, System.Action<BooleanOperationResult> callback);
        Task<BooleanOperationResult> SaveCommentAsync(int Id, int surveyId, string comment, System.Action<BooleanOperationResult> callback);
        Task<BooleanOperationResult> SavePhotoAsync(int Id, int surveyId, string photo, System.Action<BooleanOperationResult> callback);
        Task<BooleanOperationResult> MarkAsFinalized(int surveyId, System.Action<BooleanOperationResult> callback);
    }
}