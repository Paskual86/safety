using SafetyBP.ViewModels.SpontaneousDiversions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views.Modules.SpontaneousDiversions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpontaneousDiversionListFinalizate : ToolbarPage
    {
        public SpontaneousDiversionListFinalizate(SpontaneousDiversionListFinalizateViewModel value) : base(value)
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