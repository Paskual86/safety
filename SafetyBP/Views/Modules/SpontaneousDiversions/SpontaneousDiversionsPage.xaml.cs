using SafetyBP.ViewModels.SpontaneousDiversions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views.Modules.SpontaneousDiversions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpontaneousDiversionsPage : ToolbarPage
    {
        public SpontaneousDiversionsPage() : base(new SpontaneousDiversionsViewModel())
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Application.Current.Resources["NavigationPrimary"] = Application.Current.Resources["Rojo"];
            base.OnAppearing();
        }
    }
}