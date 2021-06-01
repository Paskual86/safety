using SafetyBP.Domain.Constants;
using SafetyBP.Domain.OperationsResult;
using SafetyBP.Dtos.Requests.CheckList;
using System;
using System.Threading.Tasks;

namespace SafetyBP.Services.WebServices
{
    public class CheckListRestClient : BaseRestClient, ICheckListRestClient
    {
        private const string URL = "https://safetybp.com/admin/api/checklist.php";

        public async Task<BooleanOperationResult> MarkAsFinalized(int surveyId, Action<BooleanOperationResult> callback)
        {
            var request = new CheckListFinalizeRequestDto(surveyId)
            {
                Token = await TokenHelper.GetTokenAsync()
            };

            return await ExecutePostCommand(request, GetHashCode(new CheckListFinalizeRequestDto(surveyId)), URL, ModuleNameConstants.CHECKLIST, callback);
        }

        public async Task<BooleanOperationResult> SaveCheckListAsync(int id, int surveyId, string value, Action<BooleanOperationResult> callback)
        {
            var request = new CheckListSaveChecklistRequestDto(id,surveyId, value)
            {
                Token = await TokenHelper.GetTokenAsync()
            };

            return await ExecutePostCommand(request, GetHashCode(new CheckListSaveChecklistRequestDto(id, surveyId)), URL, ModuleNameConstants.CHECKLIST, callback);
        }

        public async Task<BooleanOperationResult> SaveCommentAsync(int Id, int surveyId, string comment, Action<BooleanOperationResult> callback)
        {
            var request = new CheckListSaveCommentRequestDto(Id, surveyId, comment)
            {
                Token = await TokenHelper.GetTokenAsync()
            };

            return await ExecutePostCommand(request, GetHashCode(new CheckListSaveCommentRequestDto(Id, surveyId)), URL, ModuleNameConstants.CHECKLIST, callback);
        }

        public async Task<BooleanOperationResult> SavePhotoAsync(int Id, int surveyId, string photo, Action<BooleanOperationResult> callback)
        {
            var request = new CheckListSavePhotoRequestDto(Id, surveyId, photo)
            {
                Token = await TokenHelper.GetTokenAsync()
            };

            return await ExecutePostCommand(request, GetHashCode(new CheckListSavePhotoRequestDto(Id, surveyId)), URL, ModuleNameConstants.CHECKLIST, callback);
        }
    }
}
