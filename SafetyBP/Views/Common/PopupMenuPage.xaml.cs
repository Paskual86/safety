using Rg.Plugins.Popup.Pages;
using SafetyBP.ViewModels;
using SafetyBP.ViewModels.Common;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupMenuPage : PopupPage
    {
        protected IBaseViewModel ViewModel { get; set; }
        public PopupMenuPage(PopupMenuViewModel viewModel)
        {
            BindingContext = ViewModel = viewModel;
            InitializeComponent();
        }
    }
}