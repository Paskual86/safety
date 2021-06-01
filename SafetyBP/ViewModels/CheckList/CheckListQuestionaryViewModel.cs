using SafetyBP.Data;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models;
using SafetyBP.Domain.OperationsResult;
using SafetyBP.Views.Common;
using SafetyBP.Views.Modules.CheckLists;
using SafetyBP.Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.ViewModels.CheckList
{
    public class CheckListQuestionaryViewModel : BaseViewModel
    {
        private SafetyCheckListDetail _safetyCheckListDetail;
        
        public string Sector { get; set; }
        public DateTime DueDateTime { get; set; }
        public string NameCheckList { get; set; }

        public ObservableCollection<SafetyCheckListQuestionBaseWrapper> Questions { get; set; }

        public ICommand SaveCheckListCommand { get; set; }
        
        public ICommand FinalizeCommand { get; set; }
        
        private ICommand NACommandCallBack;
        private ICommand FinalizeCommandCallback { get; set; }

        private ICommand ErrorInitializateCommand { get; set; }
        private bool _commandIsExecuting;


        private ICommand _settleUpdateCheckListQuestionOperationCommand;

        private ICommand _markAsFinalizedCommand;
        private ICommand _markAsFinalizedPostCommitCommand;

        public CheckListQuestionaryViewModel(SafetyCheckListDetail safetyCheckList, string sector, ICommand AFinalizeCommandCallback)
            :base(ApplicationWordsEnum.PageTitleChecklist)
        {
            _safetyCheckListDetail = safetyCheckList;
            Sector = sector;
            DueDateTime = safetyCheckList.DueDateTime;
            NameCheckList = safetyCheckList.Name;
            FinalizeCommandCallback = AFinalizeCommandCallback;

            var lstItems = new List<SafetyCheckListQuestionBaseWrapper>();

            bool enumDoesntExist = false;

            ErrorInitializateCommand = new Command(async () =>
            {
                await BackToHomeErrorInInitializate();
            });

            SaveCheckListCommand = new Command<SafetyCheckListQuestion>(async parameter => {
                await OnSaveCheckListCommand(parameter);
            });

            _settleUpdateCheckListQuestionOperationCommand = new Command<SafetyCheckListQuestion>(async parameter =>
            {
                await ModuleCheckListsBusiness.SettleUpdateCheckListQuestionOperation(parameter);
            });

            _markAsFinalizedPostCommitCommand = new Command<BooleanOperationResult>(async rst =>
            {
                _safetyCheckListDetail.Complete = true;
                _safetyCheckListDetail.IsPendingToSyncronize = false;
                await ModuleCheckListsBusiness.FinalizeCheckList(_safetyCheckListDetail);
                if (FinalizeCommandCallback != null) FinalizeCommandCallback.Execute(null);

                var itemsCritica = Questions.Where(wh => wh.Model.IsCritica && !wh.Model.DoesNotApply).ToList();
                var response = "0";
                if ((itemsCritica != null) && (itemsCritica.Any(an => an.Status == Domain.Enums.CheckListQuestionStatus.Negative))) response = "1";

                await BackToHome(response == "1");
                await FinalizateLoaderPage();
            });

            _markAsFinalizedCommand = new Command<BooleanOperationResult>(async result =>
            {
                if (result.Result)
                {
                    await CheckListRestClient.CommitOperation(OperationId, response => _markAsFinalizedPostCommitCommand.Execute(response));
                }
                else
                {
                    await ShowPopupInformationMessage("Error", result.Message);
                }
            });

            foreach (var question in safetyCheckList.Questions)
            {
                switch (question.Type)
                {
                    case Domain.Enums.CheckListQuestionTypes.Type1: lstItems.Add(new SafetyCheckListQuestionType1Wrapper(question, SaveCheckListCommand)); break;
                    case Domain.Enums.CheckListQuestionTypes.Type2: lstItems.Add(new SafetyCheckListQuestionType2Wrapper(question, SaveCheckListCommand)); break;
                    case Domain.Enums.CheckListQuestionTypes.Type3: lstItems.Add(new SafetyCheckListQuestionType3Wrapper(question, SaveCheckListCommand)); break;
                    case Domain.Enums.CheckListQuestionTypes.Type4: lstItems.Add(new SafetyCheckListQuestionType4Wrapper(question, SaveCheckListCommand)); break;
                    case Domain.Enums.CheckListQuestionTypes.Type5: lstItems.Add(new SafetyCheckListQuestionType5Wrapper(question, SaveCheckListCommand)); break;
                    case Domain.Enums.CheckListQuestionTypes.Type6: lstItems.Add(new SafetyCheckListQuestionType6Wrapper(question, SaveCheckListCommand)); break;
                    case Domain.Enums.CheckListQuestionTypes.Type7: lstItems.Add(new SafetyCheckListQuestionType7Wrapper(question, SaveCheckListCommand)); break;
                    default:
                        enumDoesntExist = true;break;
                }
            }

            if (enumDoesntExist) 
            {
                ErrorInitializateCommand?.Execute(null);
                return;
            }
            else
            {
                Questions = new ObservableCollection<SafetyCheckListQuestionBaseWrapper>(lstItems.OrderBy(ob => ob.Model.Code));
                
                OnMenuCommand = new Command<SafetyCheckListQuestionBaseWrapper>(async parameter =>
                {
                    await PopupNavigation.PushAsync(new CheckListPopupMenuPage(parameter.Model, NACommandCallBack));
                });

                FinalizeCommand = new Command(async () =>
                {
                    await SettleCheckList();
                });

                NACommandCallBack = new Command<SafetyCheckListQuestion>(async parameter =>
                {
                    await ChangeStatusCheckListToNotApply(parameter);
                });
            }

            BeginOperationCommand.Execute(ModuleNameConstants.CHECKLIST);
        }

        private async Task OnSaveCheckListCommand(SafetyCheckListQuestion value) {

            await ModuleCheckListsBusiness.UpdateCheckListQuestionValue(value);
            var result = await CheckListRestClient.SaveCheckListAsync(value.Code, value.RelatedId, value.Value, response => {
                _settleUpdateCheckListQuestionOperationCommand.Execute(value);
            });
        }

        private async Task BackToHomeErrorInInitializate()
        {
            await PopupNavigation.PushAsync(new DisplayAlertPage(new Common.DisplayAlertViewModel(GetTranslateValue(Data.ApplicationWordsEnum.ToastMessageInformation)
                                                                    , GetTranslateValue(Data.ApplicationWordsEnum.ErrorInitializatePageCheckList))));
            await Navigation.PopToRootAsync();
        }

        private async Task BackToHome(bool negativeAnswer)
        {
            if (negativeAnswer)
                await PopupNavigation.PushAsync(new DisplayAlertPage(new Common.DisplayAlertViewModel(GetTranslateValue(Data.ApplicationWordsEnum.ToastMessageInformation)
                                                                        , GetTranslateValue(Data.ApplicationWordsEnum.ToastMessageObjectUnfit))));
            else
                Toaster.Short(GetTranslateValue(Data.ApplicationWordsEnum.ToastMessageCheckListUpdatedSuccessfully));
            await Navigation.PopToRootAsync();
        }

        private async Task SettleCheckList()
        {
            if (!_commandIsExecuting)
            {
                _commandIsExecuting = true;
                try
                {
                    // First check out if there are questions
                    if (Questions.Any(an => an.Status == Domain.Enums.CheckListQuestionStatus.Unknown && !an.Model.DoesNotApply))
                    {
                        Toaster.Short(GetTranslateValue(ApplicationWordsEnum.ToastMessageThereAreQuestionsWithoutAnswer));
                        return;
                    }

                    await CatchLoadingFor("Guardando Informacion", async () =>
                    {
                        await CheckListRestClient.MarkAsFinalized(_safetyCheckListDetail.Id, result =>
                        {
                            _markAsFinalizedCommand.Execute(result);
                        });
                    });
                    
                }
                finally 
                {
                    _commandIsExecuting = false;
                }
            }
        }

        private async Task ChangeStatusCheckListToNotApply(SafetyCheckListQuestion value) 
        {
            if (value != null) {
                var question = Questions.FirstOrDefault(fo => fo.Model.Id == value.Id);
                question.Model.DoesNotApply = !question.Model.DoesNotApply;
                question.Model.Value = (question.Model.DoesNotApply) ? question.NAValue : question.Model.Value;

                await ModuleCheckListsBusiness.SetNAStatusCheckListQuestion(value.Id, value.DoesNotApply);
                if (question != null)
                {
                    if (value.DoesNotApply)
                    {
                        await CheckListRestClient.SaveCheckListAsync(question.Model.Code, question.Model.RelatedId, question.Model.Value, response => {
                            question.SetColorBackgroundQuestion();
                        });
                    }
                    else
                    {
                        question.ResetColorBackgroundQuestion();
                    }
                    
                }
            }
        }

    }
}
