using SafetyBP.ViewModels;
using SafetyBP.Views.Common;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlObjetosRelevamientosPage : ToolbarPageWithQr
    {
        public ControlObjetosRelevamientosPage(ControlObjetosRelevamientosViewModel viewModel):base(viewModel)
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            // Se define el color de la vista
            Application.Current.Resources["NavigationPrimary"] = Application.Current.Resources["Azul"];
            base.OnAppearing();
        }

        private void listViewRelevamientos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ViewModel.OnNextCommand.Execute(e.Item);
        }

        protected override async Task ProcessQR(string qrValue)
        {
            await ((ControlObjetosRelevamientosViewModel)ViewModel).ProcessQR(qrValue);
        }
    }
}