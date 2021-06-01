using SafetyBP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccionesCorrectivasTemasPage : ToolbarPage
    {
        public AccionesCorrectivasTemasPage(AccionesCorrectivasTemasViewModel viewModel):base(viewModel)
        {
            InitializeComponent();
        }

        private void listViewTemas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ViewModel.OnNextCommand.Execute(e.Item);
        }
    }
}