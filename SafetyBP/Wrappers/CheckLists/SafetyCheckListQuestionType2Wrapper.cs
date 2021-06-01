using SafetyBP.Data;
using SafetyBP.Domain.Models;
using System.Windows.Input;

namespace SafetyBP.Wrappers
{
    /// <summary>
    /// This type accepts two values Comply ot not comply
    /// </summary>
    public class SafetyCheckListQuestionType2Wrapper : SafetyCheckListQuestionButtonWrapper
    {
        public SafetyCheckListQuestionType2Wrapper(SafetyCheckListQuestion model, ICommand saveCheckListCommand) : base(model, saveCheckListCommand, Domain.Enums.CheckListQuestionTypes.Type2)
        {
            ButtonPositiveText = GetTranslateValue(ApplicationWordsEnum.LabelButtonComply);
            ButtonNegativeText = GetTranslateValue(ApplicationWordsEnum.LabelButtonNoComply);
            OnPropertyChanged(nameof(ButtonPositiveText));
            OnPropertyChanged(nameof(ButtonPositiveText));
            Initializating = false;
        }
    }
}
