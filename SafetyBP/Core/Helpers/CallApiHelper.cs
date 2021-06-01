using Newtonsoft.Json.Linq;
using SafetyBP.Domain.Interfaces;
using SafetyBP.Domain.Interfaces.Helpers;
using SafetyBP.Domain.OperationsResult;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SafetyBP.Core.Helpers
{
    public class CallApiHelper : ICallApiHelper
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenBusiness _tokenBusiness;
        public CallApiHelper()
        {
            _httpClient = new HttpClient();
            _tokenBusiness = DependencyService.Get<ITokenBusiness>();
        }
        
        public async Task<BooleanOperationResult> SendRequest(string request, string url)
        {
            var result = new BooleanOperationResult();
            try
            {
                var token = await _tokenBusiness.GetTokenAsync();
                var obj2 = JToken.Parse(request);
                obj2["token"] = await _tokenBusiness.GetTokenAsync();
                
                var requestWS = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Post,
                    Content = new StringContent(request, Encoding.UTF8, "application/json")
                };
                var httpResponse = await _httpClient.SendAsync(requestWS);

                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    result.Message = await httpResponse.Content.ReadAsStringAsync();
                    result.Result = true;
                }
            }
            catch (Exception ex)
            {
                // Aca tiene que haber un logger
                result.Result = false;
                result.Message = ex.Message;
            }

            return await Task.FromResult(result);
        }
    }
}
