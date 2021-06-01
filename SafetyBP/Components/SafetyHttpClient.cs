using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SafetyBP.Components
{
    public class SafetyHttpClient : HttpClient
    {
        private bool disposedValue = false;
        private readonly HttpClient _client;

        public SafetyHttpClient(Uri BaseAddress, TimeSpan DefaultTimeout)
        {
            SafetyTimeoutHandler timeoutHandler = new SafetyTimeoutHandler
            {
                DefaultTimeout = DefaultTimeout,
                InnerHandler = new HttpClientHandler()
            };

            _client = new HttpClient(timeoutHandler, true)
            {
                BaseAddress = BaseAddress
            };
        }

        public SafetyHttpClient(Uri BaseAddress, HttpClientHandler ClientHandler, TimeSpan DefaultTimeout)
        {
            SafetyTimeoutHandler timeoutHandler = new SafetyTimeoutHandler
            {
                DefaultTimeout = DefaultTimeout,
                InnerHandler = ClientHandler
            };

            _client = new HttpClient(timeoutHandler, true)
            {
                BaseAddress = BaseAddress
            };
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _client.Dispose();
                }

                disposedValue = true;
            }
        }

        public async Task<HttpResponseMessage> SendAsyncWithTimeout(string path, string Request)
        {
            try
            {
                return await PostJson(path, Request);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<HttpResponseMessage> PostJson(string path, string Request)
        {
            try
            {
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                StringContent content = new StringContent(Request, Encoding.UTF8, "application/json");
                return await _client.PostAsync(path, content);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
