using SafetyBP.Domain.Constants;
using SafetyBP.Domain.OperationsResult;
using SafetyBP.Dtos.Requests;
using System;
using System.Threading.Tasks;

namespace SafetyBP.Services.WebServices
{
    public class TaskBoardRestClient : BaseRestClient, ITaskBoardRestClient
    {
        private const string URL = "https://safetybp.com/admin/api/tareas.php";

        public async Task<BooleanOperationResult> SaveCommentAsync(int id, string comment, Action<BooleanOperationResult> callback)
        {
            var request = new SafetyCommentRequestDto
            {
                Token = await TokenHelper.GetTokenAsync(),
                Id = id,
                Comment = comment
            };
            return await ExecutePostCommand(request, GetHashCode(new SafetyCommentRequestDto() { Id=id }), URL, ModuleNameConstants.TASKBOARD, callback);
        }

        public async Task<BooleanOperationResult> SavePhotoAsync(int id, string photo, Action<BooleanOperationResult> callback)
        {
            var request = new SafetyPhotoRequestDto
            {
                Token = await TokenHelper.GetTokenAsync(),
                Id = id,
                Photo = photo
            };
            return await ExecutePostCommand(request, GetHashCode(new SafetyPhotoRequestDto() { Id = id }), URL, ModuleNameConstants.TASKBOARD, callback);
        }

        public async Task<BooleanOperationResult> SaveTaskAsync(int id, string value, Action<BooleanOperationResult> callback)
        {
            var request = new SafetyTaskCheckRequestDto
            {
                Token = await TokenHelper.GetTokenAsync(),
                Id = id,
                Status = value
            };
            return await ExecutePostCommand(request, GetHashCode(new SafetyTaskCheckRequestDto() { Id = id }), URL, ModuleNameConstants.TASKBOARD, callback);
        }
    }

}
