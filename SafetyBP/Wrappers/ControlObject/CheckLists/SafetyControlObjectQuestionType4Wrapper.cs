using SafetyBP.Domain.Models;
using SafetyBP.Domain.Models.Modules.ControlObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SafetyBP.Wrappers.ControlObject
{
    public class SafetyControlObjectQuestionType4Wrapper : SafetyControlObjectQuestionSelect
    {
        public SafetyControlObjectQuestionType4Wrapper(ControlObjectsCheckList model, ICommand saveCheckListCommand) : base(model, Domain.Enums.CheckListQuestionTypes.Type4, saveCheckListCommand)
        {
            var lstValues = new List<SafetyCheckListQuestionAnswerType>
            {
                new SafetyCheckListQuestionAnswerType
                {
                    Value = 1,
                    Description = "ALTA",
                    Sign = Domain.Enums.CheckListQuestionStatus.Negative
                },
                new SafetyCheckListQuestionAnswerType
                {
                    Value = 2,
                    Description = "MEDIA",
                    Sign = Domain.Enums.CheckListQuestionStatus.Positive
                },
                new SafetyCheckListQuestionAnswerType
                {
                    Value = 3,
                    Description = "BAJA",
                    Sign = Domain.Enums.CheckListQuestionStatus.Positive
                }
            };
            Values = new ObservableCollection<SafetyCheckListQuestionAnswerType>(lstValues);
            Status = Domain.Enums.CheckListQuestionStatus.Unknown;
            if (!string.IsNullOrEmpty(Model.Answer))
            {
                if (Model.Answer != NAValue)
                {
                    if (int.TryParse(Model.Answer, out int result))
                    {
                        ValueSelected = lstValues.FirstOrDefault(fo => fo.Value == result);
                    }
                }
                else
                {
                    Model.SkipCheck = true;
                    SetColorBackgroundQuestion();
                }
            }
            Initializating = false;
        }
    }

}
