using SafetyBP.ViewModels;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlObjetosChecklistsPage : ToolbarPage
    {
        readonly ControlObjetosChecklistsViewModel viewModel;
        public ControlObjetosChecklistsPage(ControlObjetosChecklistsViewModel vm)
        {
            InitializeComponent();
            viewModel = vm;
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
        }
    }
}