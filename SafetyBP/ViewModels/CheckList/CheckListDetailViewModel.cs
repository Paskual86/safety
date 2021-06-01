using SafetyBP.Domain.Models;
using SafetyBP.Views.Modules.CheckLists;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.ViewModels.CheckList
{
    public class CheckListDetailViewModel : BaseViewModel
    {
        public ObservableCollection<SafetyCheckListDetail> Details { get; set; }
        private IList<SafetyCheckListDetail> _details;
        private ICommand FinalizateSafetyCheckListDetail;
        public CheckListDetailViewModel(IList<SafetyCheckListDetail> details):base(Data.ApplicationWordsEnum.PageTitleChecklist)
        {
            _details = details;
            Details = new ObservableCollection<SafetyCheckListDetail>(GetPendingCheckList());

            OnNextCommand = new Command<object>(async parameter =>
            {
                await NextCommand(parameter);
            });

            FinalizateSafetyCheckListDetail = new Command(parameter => {
                Details = new ObservableCollection<SafetyCheckListDetail>(GetPendingCheckList());
            });
        }

        private IList<SafetyCheckListDetail> GetPendingCheckList() 
        {
            return _details?.Where(wh => !wh.Complete).ToArray();
        }

        private async Task NextCommand(object parameter)
        {
            var itemSelected = (SafetyCheckListDetail)parameter;
            await Navigation.PushAsync(new CheckListQuestionaryPage(new CheckListQuestionaryViewModel(itemSelected, itemSelected.CheckList.Sector, FinalizateSafetyCheckListDetail)));
        }
    }
}
