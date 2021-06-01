using SafetyBP.Domain.Enums;
using SafetyBP.Domain.Models;
using SafetyBP.Interfaces;
using SafetyBP.Views;
using Xamarin.Forms;

namespace SafetyBP.ViewModels
{
    public class TaskBoardAnswerCheckListViewModel : BaseViewModel
    {
        private readonly SafetyTaskCheckList _safetyTaskCheckList;

        private readonly Command<SafetyTaskCheckList> _onChangeStatusCommandCallback;
        private readonly Command<SafetyTaskCheckList> _onSaveCommandCallback;


        public Command OnNACommand { get; set; }
        public Command OnCheckCommand { get; set; }

        public TaskBoardAnswerCheckListViewModel(SafetyTaskCheckList checkList, Command<SafetyTaskCheckList> onChangeStatusCommandCallback)
        {
            _safetyTaskCheckList = checkList;
            _onChangeStatusCommandCallback = onChangeStatusCommandCallback;

            OnCloseCommand = new Command(async () => await OnCloseCommandEvent());
            OnCheckCommand = new Command(async () => await OnCheckCommandEvent());
            OnNACommand = new Command(async () => await OnNACommandEvent());
            OnCameraCommand = new Command(async () => await OnCameraCommandEvent());
            OnCommentsCommand = new Command(async () => await OnCommentsCommandEvent());

            _onSaveCommandCallback = new Command<SafetyTaskCheckList>(async parameter => await OnSaveCommandCallback(parameter));
        }

        private async System.Threading.Tasks.Task OnSaveCommandCallback(SafetyTaskCheckList value) {
            _safetyTaskCheckList.Comments = value.Comments;
            await TasksBusiness.UpdateCheckListAsync(_safetyTaskCheckList, () => {
                _onChangeStatusCommandCallback.Execute(_safetyTaskCheckList);
            });

            var wsResult = await TaskBoardRestClient.SaveCommentAsync(value.Id, value.Comments, result => {
                if (result.Result) _safetyTaskCheckList.Comments = string.Empty;
            });
        }

        private async System.Threading.Tasks.Task OnCameraCommandEvent()
        {
            var photo = await DependencyService.Get<ISafetyCamera>().GetPhotoAsync();
            if ((photo.CameraNotAvailable) || (photo.Content.Length == 0)) return;
            _safetyTaskCheckList.Photo = photo.Content;
            await TasksBusiness.UpdateCheckListAsync(_safetyTaskCheckList, () => { 
            
            });

            await TaskBoardRestClient.SavePhotoAsync(_safetyTaskCheckList.Id, _safetyTaskCheckList.Photo, null);
        }

        private async System.Threading.Tasks.Task OnCommentsCommandEvent()
        {
            ComentarioViewModel viewModel = new ComentarioViewModel(_onSaveCommandCallback)
            {
                SafetyTaskCheck = _safetyTaskCheckList
            };
            await PopupNavigation.PushAsync(new ComentarioPage(viewModel));
        }


        private async System.Threading.Tasks.Task OnCheckCommandEvent() {
            _safetyTaskCheckList.Status = (int)TaskCheckListStatus.Check;
            await TasksBusiness.UpdateCheckListAsync(_safetyTaskCheckList, () => {
                _onChangeStatusCommandCallback.Execute(_safetyTaskCheckList);
            });
            
            await OnCloseCommandEvent();
        }

        private async System.Threading.Tasks.Task OnNACommandEvent()
        {
            _safetyTaskCheckList.Status = (int)TaskCheckListStatus.NA;
            await TasksBusiness.UpdateCheckListAsync(_safetyTaskCheckList, () => {
                _onChangeStatusCommandCallback.Execute(_safetyTaskCheckList);
            });
            await OnCloseCommandEvent();
        }
    }
}
