using SafetyBP.ViewModels;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskBoardDetails : ToolbarPage
    {
        private readonly TaskBoardDetailsViewModel _viewModel;
        
        public TaskBoardDetails(TaskBoardDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel;
            
            _viewModel.SettledCommandCallBack = new Xamarin.Forms.Command(async () =>
            {
            }
            );
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await DisplayAlert(_viewModel.DisplayAlertTitle, _viewModel.TaskDetails.Model.Comments, _viewModel.DisplayAlertButtonOk);
        }
    }
}