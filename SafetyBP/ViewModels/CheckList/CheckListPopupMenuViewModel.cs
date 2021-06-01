using SafetyBP.Domain.Models;
using SafetyBP.ViewModels.Common;
using SafetyBP.Views.Common;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.ViewModels.CheckList
{
    public class CheckListPopupMenuViewModel : PopupMenuViewModel
    {
        public SafetyCheckListQuestion Model { get; private set; }
        public Command OnNACommand { get; set; }

        private ICommand _saveComment;
        public ICommand CallbackCameraSuccessfully;
        public ICommand CallbackCameraError;
        public ICommand CallbackNAEvent;

        public CheckListPopupMenuViewModel(SafetyCheckListQuestion question, ICommand callbackNAEvent) : base()
        {
            ShowCameraButton = true;
            ShowCommentButton = true;
            ShowNAButton = true;
            ShowCheckButton = false;

            _saveComment = new Command<string>(async parameter => await OnSaveCommandCallback(parameter));
            Model = question;
            CallbackNAEvent = callbackNAEvent;

            OnNACommand = new Command(async () => await OnNACommandEvent());
            OnCameraCommand = new Command(async () => await OnCameraCommandEvent());
            OnCommentsCommand = new Command(async () => await OnCommentsCommandEvent());

            if (Model.DoesNotApply)
            {
                IconNaButton = "CheckNAChecked.png";
            }
            else
            {
                IconNaButton = "navalue.png";
            }
        }

        public CheckListPopupMenuViewModel(SafetyCheckListQuestion question) :this(question, null)
        {

        }

        private async System.Threading.Tasks.Task OnSaveCommandCallback(string value)
        {
            
            await CheckListRestClient.SaveCommentAsync(Model.Code, Model.RelatedId, value, null);
        }

        private async System.Threading.Tasks.Task OnCameraCommandEvent()
        {
            await CatchCameraFor(async photo =>
            {
                var result = await CheckListRestClient.SavePhotoAsync(Model.Code, Model.RelatedId, photo.Content, response  => {
                    if (response.Result)
                    {
                        Toaster.Short(GetTranslateValue(Data.ApplicationWordsEnum.PhotoSaveProperly));
                        if (CallbackCameraSuccessfully != null) CallbackCameraSuccessfully.Execute(Model);
                    }
                    else
                    {
                        if (CallbackCameraError != null) CallbackCameraError.Execute(Model);
                    }
                });
            },
                () =>
                {
                    if (CallbackCameraError != null) CallbackCameraError.Execute(Model);
                });
        }

        private async System.Threading.Tasks.Task OnCommentsCommandEvent()
        {
            var comment = new PopupCommentViewModel(_saveComment, null);
            await PopupNavigation.PushAsync(new PopupCommentPage(comment));
        }

        private async System.Threading.Tasks.Task OnNACommandEvent()
        {            
            if (CallbackNAEvent != null) CallbackNAEvent.Execute(Model);
            await OnCloseCommandEvent();
        }
    }
}
