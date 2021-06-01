using SafetyBP.ViewModels.CheckList;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views.Modules.CheckLists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckListDetailPage : ToolbarPage
    {
        public CheckListDetailPage(CheckListDetailViewModel model):base(model)
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Application.Current.Resources["NavigationPrimary"] = Application.Current.Resources["Amarillo"];
            Application.Current.Resources["FORWARD_ICON"] = Application.Current.Resources["CHECKLISTNARROW"];
            base.OnAppearing();
        }

        private void listViewSectores_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ViewModel.OnNextCommand.Execute(e.Item);
        }
    }
}