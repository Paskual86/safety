using SafetyBP.Domain.Models;
using SafetyBP.ViewModels;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskBoardListPage : ToolbarPage
    {
        private readonly ViewModels.TaskBoardListPage _viewModel;

        public TaskBoardListPage(ViewModels.TaskBoardListPage viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel;
        }

        private void listViewSectores_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var itemSelected = (SafetyTaskDetails)e.Item;
            var viewModel = new TaskBoardDetailsViewModel(_viewModel.Task, itemSelected);

            Navigation.PushAsync(new TaskBoardDetails(viewModel));
        }
    }
}