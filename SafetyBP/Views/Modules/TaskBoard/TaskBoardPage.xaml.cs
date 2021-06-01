using SafetyBP.Domain.Models;
using SafetyBP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskBoardPage : ToolbarPage
    {

        private readonly TaskBoardViewModel _viewModel;
        public TaskBoardPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new TaskBoardViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadViewCommand.Execute(null);
            Application.Current.Resources["NavigationPrimary"] = Application.Current.Resources["AzulFrancia"];
        }

        private async void listViewObjetos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new TaskBoardListPage( new ViewModels.TaskBoardListPage((SafetyTask)e.Item)));
        }
    }
}