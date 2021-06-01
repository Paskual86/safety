using SafetyBP.Domain.Enums;
using SafetyBP.Domain.Models.Modules.ControlObjects;
using System.Windows.Input;

namespace SafetyBP.Wrappers.ControlObject.Questions
{
    public class BaseControlObjectQuestion : BaseQuestionWrapper<ControlObjectsQuestion>
    {
        public string Question { get; set; }
        public CheckListQuestionTypes Type { get; set; }

        protected ICommand OnAnswerChangeCommand { get; set; }

        public BaseControlObjectQuestion(ControlObjectsQuestion model) : this(model, null)
        {
        }

        public BaseControlObjectQuestion(ControlObjectsQuestion model, ICommand onChangeAnswer) : base(model)
        {
            OnAnswerChangeCommand = onChangeAnswer;
            Question = model.QuestionDescription;
            OnPropertyChanged(nameof(Question));
        }
    }

}
