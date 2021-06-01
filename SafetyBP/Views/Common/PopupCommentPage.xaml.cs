using Rg.Plugins.Popup.Pages;
using SafetyBP.ViewModels.Common;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupCommentPage : PopupPage
    {
        public PopupCommentPage(PopupCommentViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}