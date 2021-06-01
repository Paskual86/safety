using SafetyBP.Core.Interfaces;
using SafetyBP.Data;
using SafetyBP.Interfaces;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SafetyBP.Core.Business
{
    public class ToastMessages : IToastMessages
    {
        private readonly ITranslateBusiness _translateBusiness;
        private Dictionary<ToastMessagesEnum, string> _messages;

        public ToastMessages()
        {
            _translateBusiness = DependencyService.Get<ITranslateBusiness>();
            _messages = new Dictionary<ToastMessagesEnum, string>
            {
                { ToastMessagesEnum.AppOffline, _translateBusiness.GetText(ApplicationWordsEnum.ToastMessageAppOffline)},
                { ToastMessagesEnum.AppOfflineCouldNotLogin, _translateBusiness.GetText(ApplicationWordsEnum.ToastMessageAppOfflineCouldNotLogin)},
                { ToastMessagesEnum.ErrorWithCredentialsPleaseLogin, _translateBusiness.GetText(ApplicationWordsEnum.ToastMessageErrorWithCredentialsPleaseLogin)},
                { ToastMessagesEnum.ThereWasAnErrorTryLater, _translateBusiness.GetText(ApplicationWordsEnum.ToastMessageThereWasAnErrorTryLater)},
                { ToastMessagesEnum.TheStatusWasUpdatedSuccessfully, _translateBusiness.GetText(ApplicationWordsEnum.ToastMessageTheStatusWasUpdatedSuccessfully)},
                { ToastMessagesEnum.ThereAreQuestionsWithoutAnswer, _translateBusiness.GetText(ApplicationWordsEnum.ToastMessageThereAreQuestionsWithoutAnswer)},
                { ToastMessagesEnum.TasksFinishedSuccessfully, _translateBusiness.GetText(ApplicationWordsEnum.ToastMessageTasksFinishedSuccessfully)},
                { ToastMessagesEnum.TaskStatusUpdateSuccessfully, _translateBusiness.GetText(ApplicationWordsEnum.ToastMessageTaskStatusUpdateSuccessfully)},
                { ToastMessagesEnum.TaskStatusUpdateUnsuccessfully, _translateBusiness.GetText(ApplicationWordsEnum.ToastMessageTaskStatusUpdateUnsuccessfully)},
                { ToastMessagesEnum.QuestionsUpdateSuccessfully, _translateBusiness.GetText(ApplicationWordsEnum.ToastMessageQuestionsUpdateSuccessfully)},
                { ToastMessagesEnum.QuestionChangeStatus, _translateBusiness.GetText(ApplicationWordsEnum.ToastMessageQuestionChangeStatus)},
                { ToastMessagesEnum.CheckListUpdatedSuccessfully, _translateBusiness.GetText(ApplicationWordsEnum.ToastMessageCheckListUpdatedSuccessfully)},
                { ToastMessagesEnum.Ok, _translateBusiness.GetText(ApplicationWordsEnum.ToastMessageOk)},
                { ToastMessagesEnum.Cancel, _translateBusiness.GetText(ApplicationWordsEnum.ToastMessageCancel)},
                { ToastMessagesEnum.Information, _translateBusiness.GetText(ApplicationWordsEnum.ToastMessageInformation)},
                { ToastMessagesEnum.ObjectUnfit, _translateBusiness.GetText(ApplicationWordsEnum.ToastMessageObjectUnfit)},
                { ToastMessagesEnum.IncorrectUserAndPassword, _translateBusiness.GetText(ApplicationWordsEnum.ToastMessageIncorrectUserAndPassword)},
                
                

            };
        }

        public string GetMessage(ToastMessagesEnum type)
        {
            return _messages[type];
        }
    }
}
