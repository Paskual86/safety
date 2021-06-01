using SafetyBP.Domain.Models;
using SafetyBP.Domain.Models.Modules.ControlObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SafetyBP.Wrappers.ControlObject
{
    public class SafetyControlObjectQuestionType5Wrapper : SafetyControlObjectQuestionSelect
    {
        public SafetyControlObjectQuestionType5Wrapper(ControlObjectsCheckList model, ICommand saveCheckListCommand) : base(model, Domain.Enums.CheckListQuestionTypes.Type5, saveCheckListCommand)
        {
            var lstValues = new List<SafetyCheckListQuestionAnswerType>();
            for (int i = 0; i <= 3; i++)
                if (i <= 2)
                {
                    lstValues.Add(new SafetyCheckListQuestionAnswerType()
                    {
                        Description = i.ToString(),
                        Value = i,
                        Sign = Domain.Enums.CheckListQuestionStatus.Negative
                    });
                }
                else
                {
                    lstValues.Add(new SafetyCheckListQuestionAnswerType()
                    {
                        Description = i.ToString(),
                        Value = i,
                        Sign = Domain.Enums.CheckListQuestionStatus.Positive
                    });
                }
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
