using SafetyBP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccionesCorrectivasSectoresPage : ToolbarPage
    {
        public AccionesCorrectivasSectoresPage(): base(new AccionesCorrectivasSectoresViewModel())
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Application.Current.Resources["NavigationPrimary"] = Application.Current.Resources["Naranja"];
        }

        private void listViewSectores_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ViewModel.OnNextCommand.Execute(e.Item);
        }
    }
}