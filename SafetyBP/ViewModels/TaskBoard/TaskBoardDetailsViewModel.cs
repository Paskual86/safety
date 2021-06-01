using SafetyBP.Data.Constants;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Enums;
using SafetyBP.Domain.Models;
using SafetyBP.Views;
using SafetyBP.Wrappers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace SafetyBP.ViewModels
{
    public class TaskBoardDetailsViewModel : BaseViewModel
    {
        private SafetyTask xTask;

        public SafetyTask Task
        {
            get { return xTask; }
            set { SetProperty(ref xTask, value); }
        }

        public ObservableCollection<SafetyTaskCheckList> CheckList { get; set; }
        public SafetyTaskDetailsWrapper TaskDetails { get; set; }

        public Command SettledCommandCallBack { get; set; }
        public Command SettledCommand { get; set; }
        public Command<SafetyTaskDetailsWrapper> ShowMoreInformationCommand { get; set; }
        public Command AnswerCheckListCommand { get; set; }
        public Command<SafetyTaskCheckList> CheckCommand { get; set; }

        private Command<SafetyTaskCheckList> _onCommandCheckListEventUpdate { get; set; }

        
        public string LabelComments { get; set; }
        public string LabelButtonMoreInformation { get; set; }

        public string DisplayAlertTitle { get; set; }
        public string DisplayAlertMessage { get; set; }
        public string DisplayAlertButtonOk { get; set; }

        public TaskBoardDetailsViewModel(SafetyTask task, SafetyTaskDetails taskDetail) : base(Data.ApplicationWordsEnum.PageTitleTaskDetail)
        {
            Task = task;
            LabelComments = GetTranslateValue(Data.ApplicationWordsEnum.LabelComments).ToUpper();
            LabelButtonMoreInformation = GetTranslateValue(Data.ApplicationWordsEnum.LabelButtonMoreInformation);
            TaskDetails = new SafetyTaskDetailsWrapper(taskDetail);
            DisplayAlertMessage = GetTranslateValue(Data.ApplicationWordsEnum.LabelComments);
            DisplayAlertButtonOk = GetTranslateValue(Data.ApplicationWordsEnum.DisplayAlertUserSettingButtonOk);

            CheckList = new ObservableCollection<SafetyTaskCheckList>(taskDetail.CheckList);

            _onCommandCheckListEventUpdate = new Command<SafetyTaskCheckList>(async parameter => await OnCommandCheckListEventUpdate(parameter));

            AnswerCheckListCommand = new Command<SafetyTaskCheckList>(async parameter =>
            {
                await PopupNavigation.PushAsync(new TaskBoardAnswerCheckListPage(new TaskBoardAnswerCheckListViewModel(parameter, _onCommandCheckListEventUpdate)));
            });

            ShowMoreInformationCommand = new Command<SafetyTaskDetailsWrapper>(async parameter =>
            {
                await PopupNavigation.PushAsync(new TaskBoardMoreInformationPage(new TaskBoardMoreInformationViewModel(parameter.Model)));
            });

            SettledCommand = new Command( () => OnSettledCommand());

            CheckCommand = new Command<SafetyTaskCheckList>(async parameter => await OnCheckCommand(parameter));
            

            BeginOperationCommand.Execute(ModuleNameConstants.TASKBOARD);
        }

        private async System.Threading.Tasks.Task OnCommandCheckListEventUpdate(SafetyTaskCheckList value)
        {
            await TasksBusiness.UpdateCheckListAsync(value, () => {
                CheckList = new ObservableCollection<SafetyTaskCheckList>(TaskDetails.CheckList);
                OnPropertyChanged(nameof(CheckList));
            });

            if (ValidateAnswer(TaskDetails.CheckList)) 
            {
                TaskDetails.Model.IsComplete = true;
                await TasksBusiness.UpdateTaskDetailAsync(TaskDetails.Model);
                // Si se valida todo ok, mando la informacion al server.
                await TaskBoardRestClient.CommitOperation(OperationId, result => {
                    MessagingCenter.Send(TaskDetails, SafetyTaskMessages.UPDATESAFETYTASKDETAILS);
                    Toaster.Short(ToastMessages.GetMessage(Data.ToastMessagesEnum.TheStatusWasUpdatedSuccessfully));
                    SettledCommandCallBack?.Execute(null);
                });
            }
            
        }

        private void OnSettledCommand()
        {
            // First Validate all fields are complete
            if (!TaskDetails.CheckList.Any(any => any.Status == (int)TaskCheckListStatus.Uncheck))
            {
                Toaster.Short(ToastMessages.GetMessage(Data.ToastMessagesEnum.TheStatusWasUpdatedSuccessfully));
                SettledCommandCallBack?.Execute(null);
            }
            else {
                Toaster.Short(ToastMessages.GetMessage(Data.ToastMessagesEnum.ThereAreQuestionsWithoutAnswer));
            }
        }

        private async System.Threading.Tasks.Task OnCheckCommand(SafetyTaskCheckList value)
        {
            // Get if this was checked
            if (value != null)
            {
                if(value.Status!= (int)TaskCheckListStatus.Check) value.Status = (int)TaskCheckListStatus.Check;
                else value.Status = (int)TaskCheckListStatus.Uncheck;
                var result = await TaskBoardRestClient.SaveTaskAsync(value.Id, value.Status.ToString(), response => {
                    _onCommandCheckListEventUpdate.Execute(value);
                });
            }
        }

        private bool ValidateAnswer(ICollection<SafetyTaskCheckList> checkLists) {
            return (!checkLists.Any(chk => chk.Status != (int)TaskCheckListStatus.Check));
            
        }
    }
}
