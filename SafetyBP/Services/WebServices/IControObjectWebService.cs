using SafetyBP.Domain.OperationsResult;
using System;
using System.Threading.Tasks;

namespace SafetyBP.Services.WebServices
{
    public interface IControObjectWebService : IBaseRestClient
    {
        Task<BooleanOperationResult> MarkAsInactive(int rid, Action<BooleanOperationResult> callback);
        Task<BooleanOperationResult> MarkAsFinalize(int rid, bool review, Action<BooleanOperationResult> callback);
        Task<BooleanOperationResult> SaveStringAnswer(int rid, int pid, string answer, string dateAnswer, Action<BooleanOperationResult> callback);
        Task<BooleanOperationResult> SaveCheckListAnswer(int rid, int pid, string value, Action<BooleanOperationResult> callback);

        Task<BooleanOperationResult> SavePhoto(int rid, int cid, string photo, System.Action<BooleanOperationResult> callback);
        Task<BooleanOperationResult> SaveComment(int rid, int cid, string comment, Action<BooleanOperationResult> callback);

        Task<BooleanOperationResult> SaveQuestionPhoto(int rid, int cid, string photo, System.Action<BooleanOperationResult> callback);
        Task<BooleanOperationResult> SaveQuestionComment(int rid, int cid, string comment, Action<BooleanOperationResult> callback);
    }
}