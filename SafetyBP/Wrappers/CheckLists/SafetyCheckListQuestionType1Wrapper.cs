using SafetyBP.Data;
using SafetyBP.Domain.Models;
using System.Windows.Input;

namespace SafetyBP.Wrappers
{
    public class SafetyCheckListQuestionType1Wrapper : SafetyCheckListQuestionButtonWrapper
    {
        public SafetyCheckListQuestionType1Wrapper(SafetyCheckListQuestion model, ICommand saveCheckListCommand) : base(model, saveCheckListCommand, Domain.Enums.CheckListQuestionTypes.Type1)
        {
            ButtonPositiveText = GetTranslateValue(ApplicationWordsEnum.LabelButtonYes);
            ButtonNegativeText = GetTranslateValue(ApplicationWordsEnum.LabelButtonNo);
            OnPropertyChanged(nameof(ButtonPositiveText));
            OnPropertyChanged(nameof(ButtonPositiveText));
            Initializating = false;
        }
    }
}
