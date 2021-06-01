using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SafetyBP.Core.Helpers
{
    public static class NetworkHelper
    {
        public static async Task<string> CheckInternetSpeed(string token)
        {
            DateTime dt1 = DateTime.Now;
            string internetSpeed = string.Empty;
            try
            {
                var client = new HttpClient();
                string url = "https://safetybp.com/admin/api/db.php";
                HttpRequestMessage httpRequest;
                HttpResponseMessage httpResponse;

                var parametros = new Dictionary<string, string>
                {
                    { "token", token }
                };

                httpRequest = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(parametros)
                };

                httpResponse = await client.SendAsync(httpRequest);

                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    byte[] data = await httpResponse.Content.ReadAsByteArrayAsync();
                    DateTime dt2 = DateTime.Now; Console.WriteLine("ConnectionSpeed: DataSize (kb) " + data.Length / 1024);
                    internetSpeed = "ConnectionSpeed: (kb/s) " + Math.Round((data.Length / 1024) / (dt2 - dt1).TotalSeconds, 2);
                }
                else {
                    internetSpeed = "Server not reached";
                }
            }
            catch (Exception ex)
            {
                internetSpeed = "ConnectionSpeed:Unknown Exception-" + ex.Message;
            }
            
            return internetSpeed;
        }
    }
}
