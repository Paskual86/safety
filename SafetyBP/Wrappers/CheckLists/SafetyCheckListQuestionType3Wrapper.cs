using SafetyBP.Domain.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SafetyBP.Wrappers
{
    public class SafetyCheckListQuestionType3Wrapper : SafetyCheckListQuestionSelect
    {
        public SafetyCheckListQuestionType3Wrapper(SafetyCheckListQuestion model, ICommand saveCheckListCommand) : base(model, Domain.Enums.CheckListQuestionTypes.Type3, saveCheckListCommand)
        {
            var lstValues = new List<SafetyCheckListQuestionAnswerType>();
            for (int i = 0; i <= 10; i++)
                if (i <= 4)
                {
                    lstValues.Add(new SafetyCheckListQuestionAnswerType()
                    {
                        Description = i.ToString(),
                        Value = i,
                        Sign = Domain.Enums.CheckListQuestionStatus.Negative
                    });
                }
                else {
                    lstValues.Add(new SafetyCheckListQuestionAnswerType()
                    {
                        Description = i.ToString(),
                        Value = i,
                        Sign = Domain.Enums.CheckListQuestionStatus.Positive
                    });
                }
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
                else {
                    Model.DoesNotApply = true;
                    SetColorBackgroundQuestion();
                }
            }
            Initializating = false;
        }
    }
}
