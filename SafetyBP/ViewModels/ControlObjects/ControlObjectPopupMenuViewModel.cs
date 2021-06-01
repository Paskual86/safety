using SafetyBP.Domain.Models.Modules.ControlObjects;
using SafetyBP.Services.WebServices;
using SafetyBP.ViewModels.Common;
using SafetyBP.Views.Common;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.ViewModels.ControlObjects
{
    public class ControlObjectPopupMenuViewModel : PopupMenuViewModel
    {
        private readonly ControlObjectsCheckList _question;
        private ICommand _saveComment;
        private IControObjectWebService _controObjectWebService;

        public ICommand OnNACommand { get; set; }
        public ICommand CallbackCameraSuccessfully;
        public ICommand CallbackCameraError;
        public ICommand CallbackNAEvent;

        public ControlObjectPopupMenuViewModel(ControlObjectsCheckList question, ICommand callbackNAEvent) : base()
        {
            _controObjectWebService = DependencyService.Get<IControObjectWebService>();
            ShowCameraButton = true;
            ShowCommentButton = true;
            ShowNAButton = true;
            ShowCheckButton = false;

            OnNACommand = new Command(async () => await OnNACommandEvent());
            OnCameraCommand = new Command(async () => await OnCameraCommandEvent());
            _saveComment = new Command<string>(async parameter => await OnSaveCommandCallback(parameter));
            OnCommentsCommand = new Command(async () => await OnCommentsCommandEvent());
            _question = question;
            CallbackNAEvent = callbackNAEvent;

            if (_question.SkipCheck)
            {
                IconNaButton = "CheckNAChecked.png";
            }
            else
            {
                IconNaButton = "navalue.png";
            }
        }

        public ControlObjectPopupMenuViewModel(ControlObjectsCheckList question) : this(question, null)
        {

        }

        private async System.Threading.Tasks.Task OnSaveCommandCallback(string value)
        {
            await _controObjectWebService.SaveComment(_question.SurveyId, _question.Id, value, result => { });
        }

        protected void ErrorTakingPhoto() {
            if (CallbackCameraError != null) CallbackCameraError.Execute(_question);
        }

        private async System.Threading.Tasks.Task OnCameraCommandEvent()
        {
            await CatchCameraFor(async photo =>
            {
                await _controObjectWebService.SavePhoto(_question.SurveyId, _question.Id, photo.Content, response =>
                {
                    if (response.Result)
                    {
                        Toaster.Short(GetTranslateValue(Data.ApplicationWordsEnum.PhotoSaveProperly));

                    }
                });

                if (CallbackCameraSuccessfully != null) CallbackCameraSuccessfully.Execute(_question);
            }, () =>
            {
                if (CallbackCameraError != null) CallbackCameraError.Execute(_question);
                return;
            });
        }

        private async System.Threading.Tasks.Task OnCommentsCommandEvent()
        {
            var comment = new PopupCommentViewModel(_saveComment, null);
            await PopupNavigation.PushAsync(new PopupCommentPage(comment));
        }

        private async System.Threading.Tasks.Task OnNACommandEvent()
        {
            _question.SkipCheck = !_question.SkipCheck;
            if (CallbackNAEvent != null) CallbackNAEvent.Execute(_question);
            await OnCloseCommandEvent();
        }

    }
}
