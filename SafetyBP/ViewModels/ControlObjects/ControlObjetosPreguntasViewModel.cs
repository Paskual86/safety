using Acr.UserDialogs;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models.Modules.ControlObjects;
using SafetyBP.Services.WebServices;
using SafetyBP.Views;
using SafetyBP.Views.Modules.ControlObjects;
using SafetyBP.Wrappers.ControlObject.Questions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.ViewModels
{
    public class ControlObjetosPreguntasViewModel : BaseViewModel
    {
        private IControObjectWebService _controObjectWebService;
        private List<ControlObjectsQuestion> _questions;

        public ControlObjectsSurvey Survey { get; set; }
        public ObservableCollection<BaseControlObjectQuestion> Questions { get; set; }
        public Command LoadDataCommand { get; set; }
        
        public Command ResponderPreguntasCommand { get; set; }
        public Command InactivoCommand { get; set; }

        private ICommand OnSendQuestionToServerCommand;
        public string LabelButtonInactive { get; set; }
        public string LabelButtonNext { get; set; }

        private ICommand OnMarkSurveyAsInactivePostActionCommand;
        public ControlObjetosPreguntasViewModel(ControlObjectsSurvey controlObjectsSurvey) : base()
        {
            Survey = controlObjectsSurvey;
            _controObjectWebService = DependencyService.Get<IControObjectWebService>();

            Title = GetTranslateValue(Data.ApplicationWordsEnum.PageTitleQuestions).ToUpper();
            LoadDataCommand = new Command(async () => await LoadData());
            ResponderPreguntasCommand = new Command(async () => await responderPreguntas());
            
            OnSendQuestionToServerCommand = new Command<ControlObjectsQuestion>(async parameter => await OnSendQuestionToServer(parameter));
            OnMarkSurveyAsInactivePostActionCommand = new Command<bool>(async parameter => await MarkSurveyAsInactivePostActionAsync(parameter));

            InactivoCommand = new Command(async () => await MarkSurveyAsInactiveAsync());

            OnMenuCommand = new Command<BaseControlObjectQuestion>(async parameter =>
            {
                await PopupNavigation.PushAsync(new ControlObjetosPopupMenuPage(parameter.Model));
            });

            LabelButtonInactive = GetTranslateValue(Data.ApplicationWordsEnum.LabelButtonInactive);
            LabelButtonNext = GetTranslateValue(Data.ApplicationWordsEnum.LabelButtonNext);
            LoadDataCommand.Execute(null);
            // Esta llamada se hace una vez,
            BeginOperationCommand.Execute(ModuleNameConstants.CONTROLOBJECT);
            OnPropertyChanged(nameof(Survey));
        }

        private async Task OnSendQuestionToServerInternal(ControlObjectsQuestion parameter) 
        {
            string respuestaTexto = string.Empty;
            string respuestaFecha = string.Empty;

            switch (parameter.Type)
            {
                case Domain.Enums.CheckListQuestionTypes.Type1:
                    {
                        respuestaTexto = parameter.Answer;
                        respuestaFecha = string.Empty;
                    }
                    break;
                case Domain.Enums.CheckListQuestionTypes.Type2:
                    {
                        respuestaTexto = string.Empty;
                        respuestaFecha = parameter.Answer;
                    }
                    break;
            }

            await _controObjectWebService.SaveStringAnswer(parameter.SurveyId, parameter.Id, respuestaTexto, respuestaFecha, result => { });
            await HardwareBusiness.SaveQuestionAnswerAsync(parameter);
        }

        private async Task OnSendQuestionToServer(ControlObjectsQuestion parameter)
        {
            
        }

        public override async Task LoadData()
        {
            _questions = new List<ControlObjectsQuestion>(await HardwareBusiness.GetQuestionsAsync(Survey.Id));
            if (_questions != null)
            {
                ObservableCollection<BaseControlObjectQuestion> questionAux = new ObservableCollection<BaseControlObjectQuestion>();

                foreach (var question in _questions)
                {
                    switch (question.Type)
                    {
                        case Domain.Enums.CheckListQuestionTypes.Type1:
                            questionAux.Add(new TextControlObjectQuestion(question, OnSendQuestionToServerCommand));
                            break;
                        case Domain.Enums.CheckListQuestionTypes.Type2:
                            questionAux.Add(new DateTimeControlObjectQuestion(question, OnSendQuestionToServerCommand));
                            
                            break;
                        default:
                            break;
                    }
                }
                Questions = new ObservableCollection<BaseControlObjectQuestion>(questionAux);
                OnPropertyChanged(nameof(Questions));
            }

        }

        private async Task GoToNextPage() 
        {
            await Navigation.PushAsync(new ControlObjetosChecklistsPage(new ControlObjetosChecklistsViewModel(Survey)));
        }

        private async Task responderPreguntas()
        {
            if (Questions.Any(an => string.IsNullOrEmpty(an.Model.Answer))) 
            {
                Toaster.Short(ToastMessages.GetMessage(Data.ToastMessagesEnum.ThereAreQuestionsWithoutAnswer));
                return;
            }
            
            foreach (var question in Questions) await OnSendQuestionToServerInternal(question.Model);
            
            Toaster.Short( ToastMessages.GetMessage( Data.ToastMessagesEnum.QuestionsUpdateSuccessfully ));
            await GoToNextPage();
        }
        
        private async Task MarkSurveyAsInactiveAsync()
        {
            bool confirmar = await UserDialogs.Instance.ConfirmAsync( ToastMessages.GetMessage(Data.ToastMessagesEnum.QuestionChangeStatus), 
                                                                        "", 
                                                                        ToastMessages.GetMessage(Data.ToastMessagesEnum.Ok), 
                                                                        ToastMessages.GetMessage(Data.ToastMessagesEnum.Cancel));

            if (!confirmar) return;

            Survey.IsActive = false;
            await _controObjectWebService.MarkAsInactive(Survey.Id, result => {
                OnMarkSurveyAsInactivePostActionCommand.Execute(result.Result);
            });
        }

        private async Task MarkSurveyAsInactivePostActionAsync(bool result)
        {
            await HardwareBusiness.MarkSurveyAsInactiveAsync(Survey.Id);
            Toaster.Short(ToastMessages.GetMessage(Data.ToastMessagesEnum.TheStatusWasUpdatedSuccessfully));
            await Navigation.PopToRootAsync();
        }
    }
}
