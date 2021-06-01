using SafetyBP.Domain.Enums;
using SafetyBP.Domain.Models;
using SafetyBP.Wrappers.Base;
using System.Windows.Input;

namespace SafetyBP.Wrappers
{
    public abstract class SafetyCheckListQuestionBaseWrapper : SafetyBaseButtonWrapper<SafetyCheckListQuestion>
    {
        public SafetyCheckListQuestionBaseWrapper(SafetyCheckListQuestion model, CheckListQuestionTypes AType, ICommand saveCheckListCommand) : base(model, AType, saveCheckListCommand)
        {
            
        }
        
        protected override void Initializate()
        {
            if (!Model.DoesNotApply) ResetColorBackgroundQuestion();
            else SetColorBackgroundQuestion(OrangeColor);
        }

        protected override void SetModelValue(string value)
        {
            Model.Value = value;
        }

        protected override string GetModelValue()
        {
            return Model.Value;
        }

        
    }
}
