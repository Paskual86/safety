using SafetyBP.Domain.Models;
using SafetyBP.Domain.Models.Modules.ControlObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SafetyBP.Wrappers.ControlObject
{
    public class SafetyControlObjectQuestionType6Wrapper : SafetyControlObjectQuestionSelect
    {
        public SafetyControlObjectQuestionType6Wrapper(ControlObjectsCheckList model, ICommand saveCheckListCommand) : base(model, Domain.Enums.CheckListQuestionTypes.Type6, saveCheckListCommand)
        {
            var lstValues = new List<SafetyCheckListQuestionAnswerType>
            {
                new SafetyCheckListQuestionAnswerType
                {
                    Value = 1,
                    Description = "VACIO",
                    Sign = Domain.Enums.CheckListQuestionStatus.Negative
                },
                new SafetyCheckListQuestionAnswerType
                {
                    Value = 2,
                    Description = @"1/4",
                    Sign = Domain.Enums.CheckListQuestionStatus.Negative
                },
                new SafetyCheckListQuestionAnswerType
                {
                    Value = 3,
                    Description = "MEDIO",
                    Sign = Domain.Enums.CheckListQuestionStatus.Positive
                },
                new SafetyCheckListQuestionAnswerType
                {
                    Value = 4,
                    Description = "3/4",
                    Sign = Domain.Enums.CheckListQuestionStatus.Positive
                },
                new SafetyCheckListQuestionAnswerType
                {
                    Value = 5,
                    Description = "LLENO",
                    Sign = Domain.Enums.CheckListQuestionStatus.Positive
                }
            };
            Values = new ObservableCollection<SafetyCheckListQuestionAnswerType>(lstValues);

            if (!string.IsNullOrEmpty(Model.Answer))
            {
                if (Model.Answer != NAValue)
                {
                    if (int.TryParse(Model.Answer, out int result))
                    {
                        ValueSelected = lstValues.FirstOrDefault(fo => fo.Value == result);
                    }
                }else {
                    Model.SkipCheck = true;
                    SetColorBackgroundQuestion();
                }
            }
            Initializating = false;
        }
    }

}
