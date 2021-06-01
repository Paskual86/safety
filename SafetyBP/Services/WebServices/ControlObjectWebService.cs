using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Interfaces;
using SafetyBP.Domain.Interfaces.Helpers;
using SafetyBP.Domain.OperationsResult;
using SafetyBP.Dtos.Requests;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SafetyBP.Services.WebServices
{
    public class ControlObjectWebService : BaseRestClient, IControObjectWebService
    {
        private readonly HttpClient _httpClient;

        private const string URL = "https://safetybp.com/admin/api/objetos.php";

        private ITokenBusiness _tokenBusiness;
        private readonly IOffLineHelper _offLineHelper;

        public ControlObjectWebService()
        {
            _httpClient = new HttpClient();
            _tokenBusiness = DependencyService.Get<ITokenBusiness>();
            _offLineHelper = DependencyService.Get<IOffLineHelper>();
        }

        public async Task<BooleanOperationResult> MarkAsInactive(int rid, Action<BooleanOperationResult> callback)
        {
            var request = new SafetyControlObjectRequestSaveInactiveDto()
            {
                Id = rid,
                Token = await _tokenBusiness.GetTokenAsync()
            };

            return await ExecutePostCommand(request, GetHashCode(new SafetyControlObjectRequestSaveInactiveDto(rid)), URL, ModuleNameConstants.CONTROLOBJECT, callback);
        }

        public async Task<BooleanOperationResult> MarkAsFinalize(int rid, bool review, Action<BooleanOperationResult> callback)
        {
            var request = new SafetyControlObjectRequestFinalizateDto()
            {
                Id = rid,
                Review = review ? (byte)1 : (byte)0,
                Token = await _tokenBusiness.GetTokenAsync()
            };

            return await ExecutePostCommand(request, GetHashCode(new SafetyControlObjectRequestFinalizateDto(rid)), URL, ModuleNameConstants.CONTROLOBJECT, callback);
        }

        public async Task<BooleanOperationResult> SaveStringAnswer(int rid, int pid, string answer, string dateAnswer, Action<BooleanOperationResult> callback)
        {
            var request = new SafetyControlObjectRequestSaveAnswerDto()
            {
                Id = rid,
                Pid = pid,
                Answer = answer,
                AnswerDate = dateAnswer,
                Token = await _tokenBusiness.GetTokenAsync()
            };

            return await ExecutePostCommand(request, GetHashCode(new SafetyControlObjectRequestSaveAnswerDto(rid, pid)), URL, ModuleNameConstants.CONTROLOBJECT, callback);
        }

        public async Task<BooleanOperationResult> SaveCheckListAnswer(int rid, int pid, string value, Action<BooleanOperationResult> callback)
        {
            var request = new SafetyControlObjectRequestCheckListDto()
            {
                Id = rid,
                CodeId = pid,
                Value = value,
                Token = await _tokenBusiness.GetTokenAsync()
            };

            return await ExecutePostCommand(request, GetHashCode(new SafetyControlObjectRequestCheckListDto(rid, pid)), URL, ModuleNameConstants.CONTROLOBJECT, callback);
        }

        public async Task<BooleanOperationResult> SavePhoto(int rid, int cid, string photo, Action<BooleanOperationResult> callback)
        {

            var request = new SafetyControlObjectSavePhotoRequestDto()
            {
                Id = rid,
                CodeId = cid,
                Photo = photo,
                Token = await _tokenBusiness.GetTokenAsync()
            };

            return await ExecutePostCommand(request, GetHashCode(new SafetyControlObjectSavePhotoRequestDto(rid, cid)), URL, ModuleNameConstants.CONTROLOBJECT, callback);

        }

        public async Task<BooleanOperationResult> SaveComment(int rid, int cid, string comment, Action<BooleanOperationResult> callback) 
        {
            var request = new SafetyControlObjectSaveCommentRequestDto()
            {
                Id = rid,
                CodeId = cid,
                Comment = comment,
                Token = await _tokenBusiness.GetTokenAsync()
            };

            return await ExecutePostCommand(request, GetHashCode(new SafetyControlObjectSaveCommentRequestDto(rid, cid)), URL, ModuleNameConstants.CONTROLOBJECT, callback);

        }

        public async Task<BooleanOperationResult> SaveQuestionPhoto(int rid, int cid, string photo, Action<BooleanOperationResult> callback) 
        {            
            var request = new SafetyControlObjectSavePhotoQuestionRequestDto()
            {
                Id = rid,
                CodeId = cid,
                Photo = photo,
                Token = await _tokenBusiness.GetTokenAsync()
            };

            return await ExecutePostCommand(request, GetHashCode(new SafetyControlObjectSavePhotoQuestionRequestDto(rid, cid)), URL, ModuleNameConstants.CONTROLOBJECT, callback);
        }

        public async Task<BooleanOperationResult> SaveQuestionComment(int rid, int cid, string comment, Action<BooleanOperationResult> callback) 
        {
            var request = new SafetyControlObjectSaveCommentQuestionRequestDto()
            {
                Id = rid,
                CodeId = cid,
                Comment = comment,
                Token = await _tokenBusiness.GetTokenAsync()
            };

            return await ExecutePostCommand(request, GetHashCode(new SafetyControlObjectSaveCommentQuestionRequestDto(rid, cid)), URL, ModuleNameConstants.CONTROLOBJECT, callback);
        }
    }
}
