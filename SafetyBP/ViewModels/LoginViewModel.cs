using SafetyBP.Models.Common;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SafetyBP.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string xUsername;
        public string Username
        {
            get { return xUsername; }
            set { this.xUsername = value; OnPropertyChanged("Username"); }
        }

        private string xPassword;
        public string Password
        {
            get { return xPassword; }
            set { this.xPassword = value; OnPropertyChanged("Password"); }
        }

        private string xMensaje;
        public string Mensaje
        {
            get { return xMensaje; }
            set { this.xMensaje = value; OnPropertyChanged("Mensaje"); }
        }
        
        // Definidos en la vista
        public ICommand LoadingPopup { get; set; }

        public LoginViewModel():base()
        {

        }

        public async Task<bool> ValidarCredenciales()
        {
            LoadingPopup.Execute(null);

            try
            {
                RespuestaGet respuesta;
                
                // Se obtiene el token del usuario utilizando sus credenciales
                respuesta = await WebService.Token_GetAsync(Username.Trim(), Password);

                if (respuesta.StatusCode != HttpStatusCode.OK)
                {
                    ThereWasAnErrorTryLater();
                    return false;
                }

                await TokenBusiness.SaveUserAndPassword(Username.Trim(), Password);

                if (respuesta.Error.Tipo == 3)
                {
                    Toaster.Short(ToastMessages.GetMessage(Data.ToastMessagesEnum.IncorrectUserAndPassword));
                    return false;
                }

                // Se guarda el token que devuelve el webservice
                string idUsuario = respuesta.Token.Id;
                string token = respuesta.Token.Token;
                await TokenBusiness.SetTokenAsync(token);
                

                // Se obtienen los datos del usuario
                respuesta = await WebService.Usuarios_GetAsync(idUsuario, token);

                if (respuesta.StatusCode != HttpStatusCode.OK)
                {
                    ThereWasAnErrorTryLater();
                    return false;
                }

                if (respuesta.Error.Tipo == 1 || respuesta.Error.Tipo == 2)
                {
                    Toaster.Short(ToastMessages.GetMessage(Data.ToastMessagesEnum.ErrorWithCredentialsPleaseLogin));
                    TokenBusiness.RemoveToken();
                    return false;
                }

                // Se instancia un nuevo usuario que será guardado en la base de datos interna
                await TokenBusiness.SaveUserInformation(respuesta.Usuario);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                ThereWasAnErrorTryLater();
                return false;
            }
            finally
            {
                LoadingPopup.Execute(null);
            }
        }
    }
}
