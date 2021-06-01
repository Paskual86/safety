using Rg.Plugins.Popup.Services;
using SafetyBP.Domain.Entities;
using SafetyBP.Domain.Enums;
using SafetyBP.Messages;
using SafetyBP.ViewModels;
using SafetyBP.ViewModels.CheckList;
using SafetyBP.ViewModels.ControlObjects;
using SafetyBP.Views.Modules.CheckLists;
using SafetyBP.Views.Modules.SpontaneousDiversions;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuCaminantesPage : ContentPage
    {
        readonly MenuCaminantesViewModel viewModel;
        private readonly ICommand LoadingPopup;
        public ZXingScannerPage scanPage;

        public MenuCaminantesPage(MenuCaminantesViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
            viewModel.CurrentPage = this;


            LoadingPopup = new Command(async () =>
            {
                if (PopupNavigation.Instance.PopupStack.Count == 0)
                    await PopupNavigation.Instance.PushAsync(new LoadingPage());
                else
                    await PopupNavigation.Instance.PopAsync();
            });
            viewModel.LoadingPopup = LoadingPopup;

            viewModel.SincronizacionCommand.Execute(null);

            MessagingCenter.Subscribe<SincronizacionMessage>(this, "DispararSincronizacion", async (obj) =>
            {
                if (obj.Disparar)
                {
                    await Navigation.PopToRootAsync();
                    viewModel.SincronizacionCommand.Execute(null);
                }
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.CargarItemsMenuCommand.Execute(null);
            Application.Current.Resources["NavigationPrimary"] = Application.Current.Resources["Blanco"];
        }

        private async void listViewMenuItems_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSeleccionado = (HomeMenuItem)e.Item;

            switch (itemSeleccionado.Id)
            {
                case HomeMenu.CheckList:
                    await Navigation.PushAsync(new CheckListPage(new CheckListViewModel()));
                    break;
                case HomeMenu.ControlObjetos:
                    await Navigation.PushAsync(new ControlObjetosEquiposPage());
                    break;
                case HomeMenu.AccionesCorrectivas:
                    await Navigation.PushAsync(new AccionesCorrectivasSectoresPage());
                    break;
                case HomeMenu.TaskBoard:
                    await Navigation.PushAsync(new TaskBoardPage());
                    break;
                case HomeMenu.SpontaneousDeflection:
                    await Navigation.PushAsync(new SpontaneousDiversionsPage());
                    break;
            }
        }

        private async void OnImageNameTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new UserSettings());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var customOverlay = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            scanPage = new ZXingScannerPage(customOverlay: customOverlay);
            scanPage.OnScanResult += (result) => {
                scanPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    await ProcessQR(result.Text);
                });
            };

            await Navigation.PushAsync(scanPage);
        }

        protected virtual async Task ProcessQR(string qrValue)
        {
            var controlObjects = new ControlObjectBaseViewModel
            {
                Navigation = Navigation
            };
            await controlObjects.ProcessQR(qrValue);
            
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            viewModel.LogoutCommand?.Execute(null);
        }

        private void RefreshAction(object sender, EventArgs e)
        {
            viewModel.SincronizacionCommand?.Execute(null);
        }
    }
}