using Rg.Plugins.Popup.Services;
using SafetyBP.Core.Interfaces;
using SafetyBP.Interfaces;
using SafetyBP.ViewModels;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly LoginViewModel viewModel;
        private readonly ICommand LoadingPopup;
        private readonly IToast _toaster;
        private readonly IToastMessages _toastMessages;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = this.viewModel = new LoginViewModel();
            _toaster = DependencyService.Get<IToast>();
            _toastMessages = DependencyService.Get<IToastMessages>();

            entryUsername.Completed += (object sender, EventArgs e) =>
            {
                entryPassword.Focus();
            };

            LoadingPopup = new Command(async () =>
            {
                if (PopupNavigation.Instance.PopupStack.Count == 0)
                    await PopupNavigation.Instance.PushAsync(new LoadingPage());
                else
                    await PopupNavigation.Instance.PopAsync();
            });
            viewModel.LoadingPopup = LoadingPopup;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Application.Current.Resources["NavigationPrimary"] = Application.Current.Resources["Login"];
        }

        private async void btnValidarCredenciales_Clicked(object sender, EventArgs e)
        {
            bool offline = false;
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                _toaster.Short(_toastMessages.GetMessage(Data.ToastMessagesEnum.AppOfflineCouldNotLogin));
                return;
            }
            else
            {
                bool loginExitoso = await viewModel.ValidarCredenciales();
                if (!loginExitoso)
                {
                    return;
                }
            }

            MenuCaminantesViewModel vm = new MenuCaminantesViewModel
            {
                Offline = offline
            };
            Navigation.InsertPageBefore(new MenuCaminantesPage(vm), this);
            await Navigation.PopAsync();
        }
    }
}