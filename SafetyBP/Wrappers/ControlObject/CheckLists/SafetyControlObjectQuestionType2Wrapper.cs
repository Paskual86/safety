using SafetyBP.Data;
using SafetyBP.Domain.Models.Modules.ControlObjects;
using System.Windows.Input;

namespace SafetyBP.Wrappers.ControlObject
{
    public class SafetyControlObjectQuestionType2Wrapper : SafetyControlObjectCheckListButtonWrapper
    {
        public SafetyControlObjectQuestionType2Wrapper(ControlObjectsCheckList model, ICommand saveCheckListCommand) : base(model, Domain.Enums.CheckListQuestionTypes.Type2, saveCheckListCommand)
        {
            ButtonPositiveText = GetTranslateValue(ApplicationWordsEnum.LabelButtonComply);
            ButtonNegativeText = GetTranslateValue(ApplicationWordsEnum.LabelButtonNoComply);
            OnPropertyChanged(nameof(ButtonPositiveText));
            OnPropertyChanged(nameof(ButtonPositiveText));
            Initializating = false;
        }
    }

}
