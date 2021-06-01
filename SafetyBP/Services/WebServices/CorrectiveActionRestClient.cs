using SafetyBP.Domain.Constants;
using SafetyBP.Domain.OperationsResult;
using SafetyBP.Dtos.Requests.CorrectiveAction;
using System;
using System.Threading.Tasks;

namespace SafetyBP.Services.WebServices
{
    public class CorrectiveActionRestClient : BaseRestClient, ICorrectiveActionRestClient
    {
        private const string URL = "https://safetybp.com/admin/api/accion.php";

        public CorrectiveActionRestClient():base()
        {

        }
        public async Task<BooleanOperationResult> SaveCommentTaskAsync(long taskId, string content, Action<BooleanOperationResult> callback)
        {
            var saveTaskRequestDto = new SaveTaskCommentRequestDto(taskId, content)
            {
                Token = await TokenHelper.GetTokenAsync()
            };

            return await ExecutePostCommand(saveTaskRequestDto, GetHashCode(new SaveTaskCommentRequestDto(taskId)), URL, ModuleNameConstants.CORRECTIVEACTIONS, callback);
        }

        public async Task<BooleanOperationResult> SavePhotoTaskAsync(long taskId, string content, Action<BooleanOperationResult> callback)
        {
            var saveTaskRequestDto = new SaveTaskPhotoRequestDto(taskId, content)
            {
                Token = await TokenHelper.GetTokenAsync()
            };
            return await ExecutePostCommand(saveTaskRequestDto, GetHashCode(new SaveTaskPhotoRequestDto(taskId)), URL, ModuleNameConstants.CORRECTIVEACTIONS, callback);
        }

        public async Task<BooleanOperationResult> SaveTaskAsync(long taskId, short status, Action<BooleanOperationResult> callback)
        {
            var saveTaskRequestDto = new SaveTaskRequestDto(taskId, status)
            {
                Token = await TokenHelper.GetTokenAsync()
            };

            return await ExecutePostCommand(saveTaskRequestDto, GetHashCode(new SaveTaskRequestDto(taskId)), URL, ModuleNameConstants.CORRECTIVEACTIONS, callback);
        }
    }
}
