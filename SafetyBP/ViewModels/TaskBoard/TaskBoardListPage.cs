using SafetyBP.Data.Constants;
using SafetyBP.Domain.Models;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace SafetyBP.ViewModels
{
    public class TaskBoardListPage : BaseViewModel
    {
        public SafetyTask Task { get; private set; }
        public ObservableCollection<SafetyTaskDetails> TaskDetails { get; set; }
        public TaskBoardListPage(SafetyTask task):base(Data.ApplicationWordsEnum.PageTitleTask)
        {
            Task = task;
            TaskDetails = new ObservableCollection<SafetyTaskDetails>(task.Details.Where(wh => !wh.IsComplete));

            LabelDueDatetime = GetTranslateValue(Data.ApplicationWordsEnum.LabelDueDate).ToUpper();
            LabelStartDatetime = GetTranslateValue(Data.ApplicationWordsEnum.LabelStartDate).ToUpper();

            MessagingCenter.Subscribe<SafetyTaskDetails>(this, SafetyTaskMessages.UPDATESAFETYTASKDETAILS, (obj) =>
            {
                TaskDetails = new ObservableCollection<SafetyTaskDetails>(task.Details.Where(wh => !wh.IsComplete));
                OnPropertyChanged(nameof(TaskDetails));
            });
        }
    }
}
