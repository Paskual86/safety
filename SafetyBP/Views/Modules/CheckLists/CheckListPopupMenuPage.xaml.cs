
using SafetyBP.Domain.Models;
using SafetyBP.ViewModels.CheckList;
using SafetyBP.Views.Common;
using System.Windows.Input;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views.Modules.CheckLists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckListPopupMenuPage : PopupMenuPage
    {

        public CheckListPopupMenuPage(SafetyCheckListQuestion question, ICommand CallbackNA ) : base(new CheckListPopupMenuViewModel(question, CallbackNA))
        {
            InitializeComponent();
        }
    }
}