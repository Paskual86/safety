using SafetyBP.Domain.Enums;
using SafetyBP.Domain.Models.Modules.ControlObjects;
using SafetyBP.Wrappers.Base;
using System.Windows.Input;

namespace SafetyBP.Wrappers.ControlObject
{
    public class SafetyControlObjectCheckListBaseWrapper : SafetyBaseButtonWrapper<ControlObjectsCheckList>
    {

        public SafetyControlObjectCheckListBaseWrapper(ControlObjectsCheckList model, CheckListQuestionTypes AType, ICommand saveCheckListCommand) : base(model, AType, saveCheckListCommand)
        {

        }

        protected override void Initializate()
        {
            if (!Model.SkipCheck) ResetColorBackgroundQuestion();
            else SetColorBackgroundQuestion(OrangeColor);
        }

        protected override void SetModelValue(string value)
        {
            Model.Answer = value;
        }

        protected override string GetModelValue()
        {
            return Model.Answer;
        }

        public override void ResetQuestion()
        {
            
        }

        protected override void CalculateStatus()
        {
            
        }
    }
}
