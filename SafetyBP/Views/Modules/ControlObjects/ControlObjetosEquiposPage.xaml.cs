using SafetyBP.ViewModels;
using SafetyBP.Views.Common;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlObjetosEquiposPage : ToolbarPageWithQr
    {
        public ControlObjetosEquiposPage():base(new ControlObjetosEquiposViewModel())
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Application.Current.Resources["NavigationPrimary"] = Application.Current.Resources["Azul"];
        }

        private void listViewObjetos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ViewModel.OnNextCommand.Execute(e.Item);
        }

        protected override async Task ProcessQR(string qrValue)
        {
            await ((ControlObjetosEquiposViewModel)ViewModel).ProcessQR(qrValue);
        }
    }
}