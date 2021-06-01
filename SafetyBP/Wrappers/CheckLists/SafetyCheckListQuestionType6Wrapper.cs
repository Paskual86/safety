using SafetyBP.Domain.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SafetyBP.Wrappers
{
    public class SafetyCheckListQuestionType6Wrapper : SafetyCheckListQuestionSelect
    {
        public SafetyCheckListQuestionType6Wrapper(SafetyCheckListQuestion model, ICommand saveCheckListCommand) : base(model, Domain.Enums.CheckListQuestionTypes.Type6, saveCheckListCommand)
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

            if (!string.IsNullOrEmpty(Model.Value)) 
            {
                if (Model.Value != NAValue)
                {
                    if (int.TryParse(Model.Value, out int result))
                    {
                        ValueSelected = lstValues.FirstOrDefault(fo => fo.Value == result);
                    }
                }
                else
                {
                    Model.DoesNotApply = true;
                    SetColorBackgroundQuestion();
                }
            }
            Initializating = false;
        }
    }
}
