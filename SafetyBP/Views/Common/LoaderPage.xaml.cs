using Rg.Plugins.Popup.Pages;
using SafetyBP.ViewModels.Common;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoaderPage : PopupPage
    {
        public LoaderPage(LoaderViewModel loaderViewModel)
        {
            InitializeComponent();
            BindingContext = loaderViewModel;
        }

        protected override bool OnBackButtonPressed()
        {
            // Return true if you don't want to close this popup page when a back button is pressed
            return true;
        }

        // Invoked when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return false if you don't want to close this popup page when a background of the popup page is clicked
            return false;
        }
    }
}