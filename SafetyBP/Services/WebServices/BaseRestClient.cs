using Newtonsoft.Json;
using SafetyBP.Domain.Interfaces;
using SafetyBP.Domain.Interfaces.Helpers;
using SafetyBP.Domain.OperationsResult;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SafetyBP.Services.WebServices
{
    public class BaseRestClient
    {
        protected HttpClient HttpClientExecutor { get; private set; }

        protected ITokenBusiness TokenHelper { get; private set; }
        protected IOffLineHelper OffLineHelper { get; private set; }

        public BaseRestClient()
        {
            HttpClientExecutor = new HttpClient();
            TokenHelper = DependencyService.Get<ITokenBusiness>();
            OffLineHelper = DependencyService.Get<IOffLineHelper>();
        }

        public async Task<Result> ExecutePostCommand<Request, Result> (Request request, int requestId, string url, string module, Action<Result> callback)
            where Result : IOperationResult, new()
            where Request: class
        {
            var result = new Result();

            var serializateRequest = JsonConvert.SerializeObject(request);
            try
            {
                await OffLineHelper.Add(requestId, serializateRequest, url, module);
                result.Result = true;
                result.Message = "Working Offline";

                if (callback != null) callback.Invoke(result);
            }
            catch (Exception ex)
            {
                // Aca tiene que haber un logger
                result.Result = false;
                result.Message = ex.Message;
            }

            return result;
        }

        protected int GetHashCode<TRequest>(TRequest request)
            where TRequest: class, new()
        {
            var requestSerializated = JsonConvert.SerializeObject(request);
            return OffLineHelper.GetHashCode(requestSerializated);
        }

        public async Task CommitOperation(int operationId, Action<BooleanOperationResult> callback)
        {
            if (OffLineHelper.IsConnected()) await OffLineHelper.CommitOperation(operationId, callback);
            else {
                callback?.Invoke(new BooleanOperationResult()
                {
                    Result = true
                });
            }
        }
    }
}
