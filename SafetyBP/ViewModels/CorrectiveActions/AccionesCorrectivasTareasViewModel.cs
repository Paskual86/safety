using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models.Modules.CorrectiveAction;
using SafetyBP.Views.Modules.ControlObjects;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.ViewModels
{
    public class AccionesCorrectivasTareasViewModel : BaseViewModel
    {
        public CorrectiveActionTopic Topic { get; set; }
        public ObservableCollection<CorrectiveActionTask> Tasks { get; set; }

        private Command LoadDataCommand { get; set; }
        public Command UpdateTaskCommand { get; set; }

        private ICommand _updateTaskPostCommand;
        public AccionesCorrectivasTareasViewModel(CorrectiveActionTopic topic) :base()
        {
            Topic = topic;
            _updateTaskPostCommand = new Command(() =>
            {
                Toaster.Short(ToastMessages.GetMessage(Data.ToastMessagesEnum.TaskStatusUpdateSuccessfully));
                CorrectiveActionRestClient.CommitOperation(OperationId, result => { });
            });

            // Título de la vista
            this.Title = GetTranslateValue(Data.ApplicationWordsEnum.PageTitleTask).ToUpper();

            // Comandos
            LoadDataCommand = new Command(async () => await LoadData());
            UpdateTaskCommand = new Command<CorrectiveActionTask>(async parameter => await UpdateTask(parameter));

            OnMenuCommand = new Command<CorrectiveActionTask>(async parameter =>
            {
                await PopupNavigation.PushAsync(new ControlObjetosPopupMenuPage(parameter));
            });

            LoadDataCommand.Execute(null);
            BeginOperationCommand.Execute(ModuleNameConstants.CORRECTIVEACTIONS);
        }

        public override async Task LoadData()
        {
            Tasks = new ObservableCollection<CorrectiveActionTask>(await CorrectiveActionsBusiness.GetTasksAsync(Topic.Id));
            OnPropertyChanged(nameof(Tasks));
        }
        
        private async Task UpdateTask(CorrectiveActionTask task)
        {
            if (task != null)
            {
                if (task.Status == 1) task.Status = 2;
                else task.Status = 1;
                
                await CorrectiveActionsBusiness.UpdateTaskAsync(task, async () =>
                {
                    LoadDataCommand.Execute(null);

                    await CorrectiveActionRestClient.SaveTaskAsync(task.Id, task.Status, result => {
                        _updateTaskPostCommand.Execute(null);
                    });
                });

                
            }
        }
    }
}
