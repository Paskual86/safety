using SafetyBP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlObjetosPreguntasPage : ToolbarPage
    {
        public ControlObjetosPreguntasPage(ControlObjetosPreguntasViewModel viewModel):base(viewModel)
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Application.Current.Resources["NavigationPrimary"] = Application.Current.Resources["Azul"];
            base.OnAppearing();
        }
    }
}