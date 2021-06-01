using SafetyBP.Domain.Models;
using SafetyBP.ViewModels.Common;
using SafetyBP.Views.Common;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.ViewModels.SpontaneousDiversions
{
    public class SpontaneousDiversionPopupMenuViewModel : PopupMenuViewModel
    {
        public SafetySpontaneousDiversion Model { get; private set; }

        private ICommand _saveComment;

        public SpontaneousDiversionPopupMenuViewModel(SafetySpontaneousDiversion safetySpontaneous)
        {
            Model = safetySpontaneous;

            ShowCameraButton = true;
            ShowCommentButton = true;
            ShowNAButton = false;
            ShowCheckButton = false;

            _saveComment = new Command<string>(async parameter => await OnSaveCommandCallback(parameter));

            OnCameraCommand = new Command(async () => await OnCameraCommandEvent());
            OnCommentsCommand = new Command(async () => await OnCommentsCommandEvent());
        }


        private async System.Threading.Tasks.Task OnSaveCommandCallback(string value)
        {
            // Nothing to do
            Model.Comment = value;
            Toaster.Short(GetTranslateValue(Data.ApplicationWordsEnum.CommentSaveProperly));
        }

        private async System.Threading.Tasks.Task OnCameraCommandEvent()
        {
            await CatchCameraFor(photo =>
            {
                Model.Photo = photo.Content;
                Toaster.Short(GetTranslateValue(Data.ApplicationWordsEnum.PhotoSaveProperly));
            },
                () =>
                {
                    // En caso de error mostrar un pop up
                    //if (CallbackCameraError != null) CallbackCameraError.Execute(Model);
                });
        }

        private async System.Threading.Tasks.Task OnCommentsCommandEvent()
        {
            var comment = new PopupCommentViewModel(_saveComment, null);
            await PopupNavigation.PushAsync(new PopupCommentPage(comment));
        }
        
    }
}
