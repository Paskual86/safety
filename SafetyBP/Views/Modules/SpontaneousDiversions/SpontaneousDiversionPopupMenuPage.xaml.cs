using SafetyBP.Domain.Models;
using SafetyBP.ViewModels.SpontaneousDiversions;
using SafetyBP.Views.Common;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views.Modules.SpontaneousDiversions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpontaneousDiversionPopupMenuPage : PopupMenuPage
    {
        public SpontaneousDiversionPopupMenuPage(SafetySpontaneousDiversion safetySpontaneous) : base(new SpontaneousDiversionPopupMenuViewModel(safetySpontaneous))
        {
            InitializeComponent();
        }
    }
}