using Rg.Plugins.Popup.Pages;
using SafetyBP.ViewModels;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskBoardMoreInformationPage : PopupPage
    {
        private readonly TaskBoardMoreInformationViewModel _viewModel;
        public TaskBoardMoreInformationPage(TaskBoardMoreInformationViewModel value)
        {
            InitializeComponent();
            BindingContext =_viewModel = value;
        }
    }
}