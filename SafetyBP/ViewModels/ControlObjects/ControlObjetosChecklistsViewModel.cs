using Microsoft.EntityFrameworkCore.Internal;
using SafetyBP.Data;
using SafetyBP.Domain.Enums;
using SafetyBP.Domain.Models.Modules.ControlObjects;
using SafetyBP.Services.WebServices;
using SafetyBP.Views.Common;
using SafetyBP.Views.Modules.ControlObjects;
using SafetyBP.Wrappers.ControlObject;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.ViewModels
{
    public class ControlObjetosChecklistsViewModel : BaseViewModel
    {
        private IControObjectWebService _controObjectWebService;
        private bool _commandIsExecuting;

        public ControlObjectsSurvey Survey { get; set; }
        private IEnumerable<ControlObjectsCheckList> _checkLists;

        public ObservableCollection<SafetyControlObjectCheckListBaseWrapper> Checklists { get; set; }

        private ICommand NACommandCallBack { get; set; }
        private ICommand ErrorInitializateCommand { get; set; }
        public ICommand SaveCheckListCommand { get; set; }
        private ICommand CargarChecklistsCommand { get; set; }
        public ICommand FinalizarCommand { get; set; }

        private ICommand PostSaveCheckListAnswerCommand;

        private ICommand PostFinalizateCommand;

        private new ICommand BackToHomeCommand;
        public ControlObjetosChecklistsViewModel(ControlObjectsSurvey survey) :base(Data.ApplicationWordsEnum.PageTitleChecklist)
        {
            Survey = survey;

            _commandIsExecuting = false;
            _controObjectWebService = DependencyService.Get<IControObjectWebService>();

            BackToHomeCommand = new Command<bool>(async parameter => await BackToHome(parameter));

            PostSaveCheckListAnswerCommand = new Command<ControlObjectsCheckList>(async parameter => await HardwareBusiness.SaveCheckListAnswer(parameter));


            PostFinalizateCommand = new Command(async paramter => {
                
                await HardwareBusiness.MarkSurveyAsFinalizeAsync(Survey);
                // In this point i Send the information to the server
                await _controObjectWebService.CommitOperation(OperationId, result => BackToHomeCommand.Execute(Survey.Result));
            });

            // Comandos
            CargarChecklistsCommand = new Command(async () => await cargarChecklists());

            SaveCheckListCommand = new Command<ControlObjectsCheckList>(async parameter => {
                await OnSaveCheckListCommand(parameter);
            });

            ErrorInitializateCommand = new Command(async () =>
            {
                await PopupNavigation.PushAsync(new DisplayAlertPage(new Common.DisplayAlertViewModel(GetTranslateValue(Data.ApplicationWordsEnum.ToastMessageInformation)
                                                                    , GetTranslateValue(Data.ApplicationWordsEnum.ErrorInitializatePageCheckList))));
                await Navigation.PopToRootAsync();
            });

            FinalizarCommand = new Command(async () => await finalizar());
            CargarChecklistsCommand.Execute(null);
        }

        private async Task cargarChecklists()
        {

            var lstItems = new List<SafetyControlObjectCheckListBaseWrapper>();
            bool enumDoesntExist = false;
            // Trae los checklists de la db local
            _checkLists = await HardwareBusiness.GetCheckListsAsync(Survey.Id);

            foreach (var question in _checkLists)
            {
                switch (question.Type)
                {
                    case CheckListQuestionTypes.Type1: lstItems.Add(new SafetyControlObjectQuestionType1Wrapper(question, SaveCheckListCommand)); break;
                    case CheckListQuestionTypes.Type2: lstItems.Add(new SafetyControlObjectQuestionType2Wrapper(question, SaveCheckListCommand)); break;
                    case CheckListQuestionTypes.Type3: lstItems.Add(new SafetyControlObjectQuestionType3Wrapper(question, SaveCheckListCommand)); break;
                    case CheckListQuestionTypes.Type4: lstItems.Add(new SafetyControlObjectQuestionType4Wrapper(question, SaveCheckListCommand)); break;
                    case CheckListQuestionTypes.Type5: lstItems.Add(new SafetyControlObjectQuestionType5Wrapper(question, SaveCheckListCommand)); break;
                    case CheckListQuestionTypes.Type6: lstItems.Add(new SafetyControlObjectQuestionType6Wrapper(question, SaveCheckListCommand)); break;
                    case CheckListQuestionTypes.Type7: lstItems.Add(new SafetyControlObjectQuestionType7Wrapper(question, SaveCheckListCommand)); break;
                    default:
                        enumDoesntExist = true; break;
                }
            }

            if (enumDoesntExist)
            {
                ErrorInitializateCommand?.Execute(null);
                return;
            }
            else
            {
                Checklists = new ObservableCollection<SafetyControlObjectCheckListBaseWrapper>(lstItems.OrderBy(ob => ob.Model.Id));

                NACommandCallBack = new Command<ControlObjectsCheckList>(async parameter =>
                {
                    await ChangeStatusCheckListToNotApply(parameter);
                });

                OnMenuCommand = new Command<SafetyControlObjectCheckListBaseWrapper>(async parameter =>
                {
                    await PopupNavigation.PushAsync(new ControlObjetosPopupMenuPage(parameter.Model, NACommandCallBack));
                });
            }

            OnPropertyChanged(nameof(Checklists));
        }

        private async Task SaveCheckListAnswer(ControlObjectsCheckList value) 
        {
            await _controObjectWebService.SaveCheckListAnswer(value.SurveyId, value.Id, value.Answer, result => {
                PostSaveCheckListAnswerCommand.Execute(value);
            });
        }

        private async Task OnSaveCheckListCommand(ControlObjectsCheckList value)
        {
            await SaveCheckListAnswer(value);
        }

        private async Task ChangeStatusCheckListToNotApply(ControlObjectsCheckList value)
        {
            if (value != null)
            {
                var question = Checklists.FirstOrDefault(fo => fo.Model.Id == value.Id);
                if (question != null)
                {
                    question.Model.SkipCheck = value.SkipCheck;
                    question.Model.Answer = (question.Model.SkipCheck) ? question.NAValue : question.Model.Answer;

                    if (value.SkipCheck) {
                        question.SetColorBackgroundQuestion();
                    }
                    else {
                        question.ResetColorBackgroundQuestion();
                    }
                    await SaveCheckListAnswer(value);
                }
            }
        }

        private async Task BackToHome(bool negativeAnswer) 
        {
            await FinalizateLoaderPage();

            if (negativeAnswer)
                await PopupNavigation.PushAsync(new DisplayAlertPage(new Common.DisplayAlertViewModel(GetTranslateValue(Data.ApplicationWordsEnum.ToastMessageInformation)
                                                                        , GetTranslateValue(Data.ApplicationWordsEnum.ToastMessageObjectUnfit))));
            else
                Toaster.Short(GetTranslateValue(Data.ApplicationWordsEnum.ToastMessageCheckListUpdatedSuccessfully));            
            
            await Navigation.PopToRootAsync();            
        }
        
        private async Task finalizar()
        {

            if (!_commandIsExecuting)
            {
                _commandIsExecuting = true;
                try
                {
                    // First check out if there are questions
                    if (Checklists.Any(an => an.Status == Domain.Enums.CheckListQuestionStatus.Unknown && !an.Model.SkipCheck))
                    {
                        Toaster.Short(GetTranslateValue(ApplicationWordsEnum.ToastMessageThereAreQuestionsWithoutAnswer));
                        return;
                    }

                    var itemsCritica = Checklists.Where(wh => wh.Model.IsCritica && !wh.Model.SkipCheck).ToList();

                    Survey.Result = false;

                    if ((itemsCritica != null) && (itemsCritica.Any(an => an.Status == Domain.Enums.CheckListQuestionStatus.Negative))) Survey.Result = true;

                    await CatchLoadingFor("Guardando Informacion", async () =>
                    {
                        await _controObjectWebService.MarkAsFinalize(Survey.Id, Survey.Result, result => {
                            PostFinalizateCommand.Execute(null);
                        });
                    });
                }
                finally
                {
                    _commandIsExecuting = false;
                }
            }
        }        
    }
}