using SafetyBP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views.Modules.CheckLists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckListPage : BaseSectorPage
    {
        public CheckListPage(IBaseViewModel viewModel):base(viewModel)
        {

        }

        protected override async void OnAppearing()
        {
            await ViewModel.LoadData();
            Application.Current.Resources["NavigationPrimary"] = Application.Current.Resources["Amarillo"];
            Application.Current.Resources["FORWARD_ICON"] = Application.Current.Resources["CHECKLISTNARROW"];
            Application.Current.Resources["CIRCLE_IMAGE"] = Application.Current.Resources["CHECKLISTICONSECTOR"];
            base.OnAppearing();
        }
    }
}