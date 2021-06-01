using SafetyBP.Data;
using SafetyBP.Domain.Models.Modules.ControlObjects;
using System.Windows.Input;

namespace SafetyBP.Wrappers.ControlObject
{
    public class SafetyControlObjectQuestionType7Wrapper : SafetyControlObjectCheckListButtonWrapper
    {
        public SafetyControlObjectQuestionType7Wrapper(ControlObjectsCheckList model, ICommand saveCheckListCommand) : base(model, Domain.Enums.CheckListQuestionTypes.Type7, saveCheckListCommand)
        {
            ButtonPositiveText = GetTranslateValue(ApplicationWordsEnum.LabelButtonOk);
            ButtonNegativeText = GetTranslateValue(ApplicationWordsEnum.LabelButtonNoOk);
            OnPropertyChanged(nameof(ButtonPositiveText));
            OnPropertyChanged(nameof(ButtonPositiveText));
            Initializating = false;
        }
    }

}
