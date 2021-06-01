using SafetyBP.Domain.PreviousEntities;
using System.Threading.Tasks;

namespace SafetyBP.Domain.Interfaces
{
    public interface ITokenBusiness
    {
        Task<string> GetTokenAsync();
        bool RemoveToken();
        Task SetTokenAsync(string token);
        Task SaveUserAndPassword(string username, string password);
        Task<string> GetUsername();
        Task<string> GetPassword();
        Task SaveUserInformation(Usuarios user);
        Task<string> GetUserInformation();
    }
}