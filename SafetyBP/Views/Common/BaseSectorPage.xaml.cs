using SafetyBP.ViewModels;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseSectorPage : ToolbarPage
    {
        public BaseSectorPage(IBaseViewModel viewModel):base(viewModel)
        {
            InitializeComponent();
        }

        private void lstSectors_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            ViewModel.OnNextCommand.Execute(e.Item);
        }
    }
}