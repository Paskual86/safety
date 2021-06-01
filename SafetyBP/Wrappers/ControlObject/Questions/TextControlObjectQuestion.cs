using SafetyBP.Domain.Models.Modules.ControlObjects;
using System.Windows.Input;

namespace SafetyBP.Wrappers.ControlObject.Questions
{
    public class TextControlObjectQuestion : BaseControlObjectQuestion
    {

        private string _answer;
        public string Answer
        {
            get { return _answer; }
            set
            {
                Model.Answer = _answer = value;
                if (OnAnswerChangeCommand != null) OnAnswerChangeCommand.Execute(Model);
            }
        }

        public TextControlObjectQuestion(ControlObjectsQuestion model, ICommand command) : base(model, command)
        {
            Type = Domain.Enums.CheckListQuestionTypes.Type1;
            _answer = Model.Answer;
        }
    }

}
