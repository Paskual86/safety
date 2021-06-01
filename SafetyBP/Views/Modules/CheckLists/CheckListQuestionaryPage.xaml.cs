using SafetyBP.ViewModels.CheckList;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views.Modules.CheckLists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckListQuestionaryPage : ToolbarPage
    {
        public CheckListQuestionaryPage(CheckListQuestionaryViewModel viewModel): base(viewModel)
        {
            InitializeComponent();
        }
    }
}