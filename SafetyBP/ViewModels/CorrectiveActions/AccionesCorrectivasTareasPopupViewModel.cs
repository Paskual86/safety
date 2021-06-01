using SafetyBP.Domain.Models.Modules.CorrectiveAction;
using SafetyBP.ViewModels.Common;
using SafetyBP.Views.Common;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.ViewModels.CorrectiveActions
{
    public class AccionesCorrectivasTareasPopupViewModel : PopupMenuViewModel
    {
        private CorrectiveActionTask _task;
        private ICommand _saveComment;

        public ICommand CallbackCameraSuccessfully;
        public ICommand CallbackCameraError;

        public AccionesCorrectivasTareasPopupViewModel(CorrectiveActionTask task)
        {
            _task = task;
            
            ShowCameraButton = true;
            ShowCommentButton = true;
            ShowNAButton = false;
            ShowCheckButton = false;

            OnCameraCommand = new Command(async () => await OnCameraCommandEvent());
            _saveComment = new Command<string>(async parameter => await OnSaveCommandCallback(parameter));
            OnCommentsCommand = new Command(async () => await OnCommentsCommandEvent());
        }

        private async System.Threading.Tasks.Task OnCameraCommandEvent()
        {
            await CatchCameraFor(async photo =>
            {
                await CorrectiveActionRestClient.SavePhotoTaskAsync(_task.Id, photo.Content, response =>
                {
                    if (response.Result) Toaster.Short(GetTranslateValue(Data.ApplicationWordsEnum.PhotoSaveProperly));
                });

                if (CallbackCameraSuccessfully != null) CallbackCameraSuccessfully.Execute(_task);
            }, () =>
            {
                if (CallbackCameraError != null) CallbackCameraError.Execute(_task);
                return;
            });
        }

        private async System.Threading.Tasks.Task OnSaveCommandCallback(string value)
        {
            await CorrectiveActionRestClient.SaveCommentTaskAsync(_task.Id,value, null);
        }

        private async System.Threading.Tasks.Task OnCommentsCommandEvent()
        {
            var comment = new PopupCommentViewModel(_saveComment, null);
            await PopupNavigation.PushAsync(new PopupCommentPage(comment));
        }
    }
}
