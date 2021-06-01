using SafetyBP.Data;
using SafetyBP.Domain.Models.Modules.ControlObjects;
using System.Windows.Input;

namespace SafetyBP.Wrappers.ControlObject
{
    public class SafetyControlObjectQuestionType1Wrapper : SafetyControlObjectCheckListButtonWrapper
    {
        public SafetyControlObjectQuestionType1Wrapper(ControlObjectsCheckList model, ICommand saveCheckListCommand) : base(model, Domain.Enums.CheckListQuestionTypes.Type1, saveCheckListCommand)
        {
            ButtonPositiveText = GetTranslateValue(ApplicationWordsEnum.LabelButtonYes);
            ButtonNegativeText = GetTranslateValue(ApplicationWordsEnum.LabelButtonNo);
            OnPropertyChanged(nameof(ButtonPositiveText));
            OnPropertyChanged(nameof(ButtonPositiveText));
            Initializating = false;
        }
    }

}
