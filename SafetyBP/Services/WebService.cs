using Newtonsoft.Json;
using SafetyBP.Domain.Entities;
using SafetyBP.Dtos;
using SafetyBP.Models.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SafetyBP.Services
{
    public class WebService : IWebService
    {

        private readonly HttpClient httpClient;
        public WebService()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<RespuestaGet> Token_GetAsync(string pUsername, string pPassword)
        {
            RespuestaGet respuesta = new RespuestaGet();

            try
            {
                string url = "https://safetybp.com/admin/api/token.php";
                HttpRequestMessage httpRequest;
                HttpResponseMessage httpResponse;

                var parametros = new Dictionary<string, string>
                {
                    { "username", pUsername },
                    { "password", pPassword }
                };

                httpRequest = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(parametros)
                };
                httpResponse = await httpClient.SendAsync(httpRequest);
                respuesta.StatusCode = httpResponse.StatusCode;
                if (respuesta.StatusCode != HttpStatusCode.OK)
                {
                    return respuesta;
                }
                string httpResponseString = await httpResponse.Content.ReadAsStringAsync();
                Error error = JsonConvert.DeserializeObject<Error>(httpResponseString);
                respuesta.Error = error;
                if (error.Message == null)
                {
                    Domain.Entities.Tokens token = JsonConvert.DeserializeObject<Domain.Entities.Tokens>(httpResponseString);
                    respuesta.Token = token;
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                respuesta.StatusCode = HttpStatusCode.InternalServerError;
                return respuesta;
            }
        }

        public async Task<RespuestaGet> Usuarios_GetAsync(string pUId, string pToken)
        {
            RespuestaGet respuesta = new RespuestaGet();

            try
            {
                string url = "https://safetybp.com/admin/api/usuarios.php";
                HttpRequestMessage httpRequest;
                HttpResponseMessage httpResponse;

                var parametros = new Dictionary<string, string>
                {
                    { "uid", pUId },
                    { "token", pToken }
                };

                httpRequest = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(parametros)
                };
                httpResponse = await httpClient.SendAsync(httpRequest);
                respuesta.StatusCode = httpResponse.StatusCode;
                if (respuesta.StatusCode != HttpStatusCode.OK)
                {
                    return respuesta;
                }
                string httpResponseString = await httpResponse.Content.ReadAsStringAsync();
                Error error = JsonConvert.DeserializeObject<Error>(httpResponseString);
                respuesta.Error = error;
                if (error.Message == null)
                {
                    Usuarios usuario = JsonConvert.DeserializeObject<Usuarios>(httpResponseString);
                    respuesta.Usuario = usuario;
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                respuesta.StatusCode = HttpStatusCode.InternalServerError;
                return respuesta;
            }
        }

        public async Task<SynchronizationResponseDto> GetOfflineRecordsAsync(string pToken) {

            var result = new SynchronizationResponseDto
            {
                Response = null
            };

            try
            {
                string url = "https://safetybp.com/admin/api/db.php";
                HttpRequestMessage httpRequest;
                HttpResponseMessage httpResponse;

                var parametros = new Dictionary<string, string>
                {
                    { "token", pToken }
                };

                httpRequest = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(parametros)
                };
                
                httpResponse = await httpClient.SendAsync(httpRequest);
                result.StatusCode = (int) httpResponse.StatusCode;
                if (httpResponse.StatusCode != HttpStatusCode.OK) return result;

                string httpResponseString = await httpResponse.Content.ReadAsStringAsync();
                result.Response = JsonConvert.DeserializeObject<SynchronizationDto>(httpResponseString);
                return result;
            }
            catch (Exception ex)
            {
                result.StatusCode = (int)HttpStatusCode.InternalServerError;
                return result;
            }
        }

    }
}
