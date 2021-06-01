using SafetyBP.Data;
using SafetyBP.Domain.Models;
using System.Windows.Input;

namespace SafetyBP.Wrappers
{
    public class SafetyCheckListQuestionType7Wrapper : SafetyCheckListQuestionButtonWrapper
    {
        public SafetyCheckListQuestionType7Wrapper(SafetyCheckListQuestion model, ICommand saveCheckListCommand) : base(model, saveCheckListCommand, Domain.Enums.CheckListQuestionTypes.Type7)
        {
            ButtonPositiveText = GetTranslateValue(ApplicationWordsEnum.LabelButtonOk);
            ButtonNegativeText = GetTranslateValue(ApplicationWordsEnum.LabelButtonNoOk);
            OnPropertyChanged(nameof(ButtonPositiveText));
            OnPropertyChanged(nameof(ButtonPositiveText));
            Initializating = false;
        }
    }
}
