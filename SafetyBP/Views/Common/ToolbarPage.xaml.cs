using SafetyBP.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToolbarPage : ContentPage
    {
        protected IBaseViewModel ViewModel { get; set; }
        
        public ToolbarPage()
        {
            InitializeComponent();          
        }

        public ToolbarPage(IBaseViewModel viewModel)
        {
            BindingContext = ViewModel = viewModel;
            ViewModel.Navigation = Navigation;
            InitializeComponent();
        }

        private async void btnHome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}