using SafetyBP.Domain.Entities;
using SafetyBP.Domain.Interfaces;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SafetyBP.Core.Business
{
    public class TokenBusiness : ITokenBusiness
    {
        private static string _token = null;

        public async Task<string> GetTokenAsync()
        {
            if (_token == null) _token = await SecureStorage.GetAsync("token");
            return _token;
        }

        public bool RemoveToken()
        {
            _token = null;
            return SecureStorage.Remove("token");
        }

        public async Task SetTokenAsync(string token)
        {
            await SecureStorage.SetAsync("token", token);
        }

        public async Task SaveUserAndPassword(string username, string password) 
        {
            await SecureStorage.SetAsync("username", username);
            await SecureStorage.SetAsync("password", password);
        }

        public async Task<string> GetUsername() 
        { 
            return await SecureStorage.GetAsync("username");
        }

        public async Task<string> GetPassword() 
        {
            return await SecureStorage.GetAsync("password");
        }

        public async Task SaveUserInformation(Usuarios user) 
        {
            await SecureStorage.SetAsync("lastname", user.Apellido);
            await SecureStorage.SetAsync("clientnumber", user.Cliente);
            await SecureStorage.SetAsync("photourl", user.Foto);
            await SecureStorage.SetAsync("name", user.Nombre);

        }
        public async Task<string> GetUserInformation() 
        {
            string lastname = await SecureStorage.GetAsync("lastname");
            string name = await SecureStorage.GetAsync("name");
            string clientnumber = await SecureStorage.GetAsync("clientnumber");

            return $"{clientnumber} - {lastname}, {name}";
        }
    }
}
