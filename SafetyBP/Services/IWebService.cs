using SafetyBP.Dtos;
using SafetyBP.Models.Common;
using System.Threading.Tasks;

namespace SafetyBP.Services
{
    public interface IWebService
    {
        Task<RespuestaGet> Token_GetAsync(string pUsername, string pPassword);
        Task<RespuestaGet> Usuarios_GetAsync(string pUId, string pToken);
        Task<SynchronizationResponseDto> GetOfflineRecordsAsync(string pToken);
    }
}


