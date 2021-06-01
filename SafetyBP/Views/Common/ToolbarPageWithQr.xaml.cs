using SafetyBP.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace SafetyBP.Views.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToolbarPageWithQr : ContentPage
    {
        protected IBaseViewModel ViewModel { get; set; }
        public ZXingScannerPage scanPage;

        public ToolbarPageWithQr()
        {
            InitializeComponent();
        }

        public ToolbarPageWithQr(IBaseViewModel viewModel)
        {
            BindingContext = ViewModel = viewModel;
            ViewModel.Navigation = Navigation;
            InitializeComponent();
        }

        private async void btnHome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void btnCallQr_Clicked(object sender, EventArgs e)
        {
            var customOverlay = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            scanPage = new ZXingScannerPage(customOverlay: customOverlay );
            scanPage.OnScanResult += (result) => {
                scanPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    await ProcessQR(result.Text);
                });
            };
            await Navigation.PushAsync(scanPage);

            //await ProcessQR("https://safetybp.com/admin/panel/r_objects/index.php?oid=684");
        }

        protected virtual async Task ProcessQR(string qrValue) 
        {
            await DisplayAlert("Scanned Barcode", qrValue, "OK");
        }
    }
}