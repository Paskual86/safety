using Rg.Plugins.Popup.Pages;
using SafetyBP.ViewModels.Common;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayAlertPage : PopupPage
    {
        public DisplayAlertPage(DisplayAlertViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}