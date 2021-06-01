using Rg.Plugins.Popup.Pages;
using SafetyBP.ViewModels;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskBoardAnswerCheckListPage : PopupPage
    {
        private readonly TaskBoardAnswerCheckListViewModel _viewModel;
        public TaskBoardAnswerCheckListPage(TaskBoardAnswerCheckListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel;
        }

    }
}