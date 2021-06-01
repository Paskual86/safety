using SafetyBP.Domain.Helpers;
using SafetyBP.Domain.Models.Modules.ControlObjects;
using System;
using System.Windows.Input;

namespace SafetyBP.Wrappers.ControlObject.Questions
{
    public class DateTimeControlObjectQuestion : BaseControlObjectQuestion
    {
        private DateTime? _answer;
        public DateTime? Answer
        {
            get { return _answer; }
            set
            {
                _answer = value;
                Model.Answer = _answer.Value.ToString("dd-MM-yyyy");
                if (OnAnswerChangeCommand != null) OnAnswerChangeCommand.Execute(Model);
            }
        }

        public DateTimeControlObjectQuestion(ControlObjectsQuestion model, ICommand command) : base(model, command)
        {
            Type = Domain.Enums.CheckListQuestionTypes.Type2;
            _answer = DatetimeHelper.ConvertDatetimeFromString(Model.Answer);
            OnPropertyChanged(nameof(Answer));
        }
    }

}
