using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SafetyBP.Core.Interfaces;
using SafetyBP.Domain.Models;
using SafetyBP.Interfaces;
using SafetyBP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FotoComentarioPage : PopupPage
    {
        readonly SafetyTaskCheckList _safetyTaskCheckList;
        readonly IToastMessages ToastMessages;

        public FotoComentarioPage(SafetyTaskCheckList safetyTaskCheck)
        {
            InitializeComponent();
            _safetyTaskCheckList = safetyTaskCheck;
            ToastMessages = DependencyService.Get<IToastMessages>();
        }

        private async void btnClick(object sender, System.EventArgs e)
        {
            var boton = sender as ImageButton;

            if (boton == imgbtnComentario)
            {
                ComentarioViewModel viewModel = new ComentarioViewModel
                {
                   SafetyTaskCheck = _safetyTaskCheckList

                };
                await PopupNavigation.Instance.PushAsync(new ComentarioPage(viewModel));
            }
            else if (boton == imgbtnFoto)
            {
                var foto = await DependencyService.Get<ISafetyCamera>().GetPhotoAsync();

                if (foto.CameraNotAvailable)
                {
                    await DisplayAlert("Error", "La cámara del teléfono no está disponible.", "OK");
                    return;
                }
            }
            else
            {
                await PopupNavigation.Instance.PopAsync();
            }
        }
       
    }
}