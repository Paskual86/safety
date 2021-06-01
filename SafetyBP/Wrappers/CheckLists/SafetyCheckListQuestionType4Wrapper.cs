using SafetyBP.Domain.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SafetyBP.Wrappers
{
    public class SafetyCheckListQuestionType4Wrapper : SafetyCheckListQuestionSelect
    {
        public SafetyCheckListQuestionType4Wrapper(SafetyCheckListQuestion model, ICommand saveCheckListCommand) : base(model, Domain.Enums.CheckListQuestionTypes.Type4, saveCheckListCommand)
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
