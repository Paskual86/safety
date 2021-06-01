using SafetyBP.ViewModels;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccionesCorrectivasTareasPage : ToolbarPage
    {
        public AccionesCorrectivasTareasPage(AccionesCorrectivasTareasViewModel viewModel):base(viewModel)
        {
            InitializeComponent();
           
        }
    }
}