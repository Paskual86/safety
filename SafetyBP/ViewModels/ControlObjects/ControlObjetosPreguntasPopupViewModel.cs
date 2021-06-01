using SafetyBP.Domain.Models.Modules.ControlObjects;
using SafetyBP.Services.WebServices;
using SafetyBP.ViewModels.Common;
using SafetyBP.Views.Common;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.ViewModels.ControlObjects
{
    public class ControlObjetosPreguntasPopupViewModel : PopupMenuViewModel
    {
        private ControlObjectsQuestion _question;
        private ICommand _saveComment;
        private IControObjectWebService _controObjectWebService;


        
        public ICommand CallbackCameraSuccessfully;
        public ICommand CallbackCameraError;

        public ControlObjetosPreguntasPopupViewModel(ControlObjectsQuestion question)
        {
            _question = question;

            _controObjectWebService = DependencyService.Get<IControObjectWebService>();
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
                await _controObjectWebService.SaveQuestionPhoto(_question.SurveyId, _question.Id, photo.Content, response =>
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

        private async System.Threading.Tasks.Task OnSaveCommandCallback(string value)
        {
            await _controObjectWebService.SaveQuestionComment(_question.SurveyId, _question.Id, value, result => { });
        }

        private async System.Threading.Tasks.Task OnCommentsCommandEvent()
        {
            var comment = new PopupCommentViewModel(_saveComment, null);
            await PopupNavigation.PushAsync(new PopupCommentPage(comment));
        }
    }
}
