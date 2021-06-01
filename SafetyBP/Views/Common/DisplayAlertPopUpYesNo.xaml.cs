using Rg.Plugins.Popup.Pages;
using SafetyBP.ViewModels.Common;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayAlertPopUpYesNo : PopupPage
    {
        public DisplayAlertPopUpYesNo(DisplayAlertYesNoViewModel model)
        {
            BindingContext = model;
            InitializeComponent();
        }
    }
}