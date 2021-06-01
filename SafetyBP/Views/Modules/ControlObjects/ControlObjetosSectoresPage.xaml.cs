using SafetyBP.ViewModels;
using SafetyBP.Views.Common;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlObjetosSectoresPage : ToolbarPageWithQr
    {
        public ControlObjetosSectoresPage(ControlObjetosSectoresViewModel viewModel):base(viewModel)
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void listViewSectores_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ViewModel.OnNextCommand.Execute(e.Item);
        }

        protected override async Task ProcessQR(string qrValue)
        {
            await ((ControlObjetosSectoresViewModel)ViewModel).ProcessQR(qrValue);
        }
    }
}