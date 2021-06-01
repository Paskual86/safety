using SafetyBP.Domain.Enums;
using SafetyBP.Domain.Models;
using SafetyBP.Domain.Models.Modules.ControlObjects;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SafetyBP.Wrappers.ControlObject
{
    public class SafetyControlObjectQuestionSelect : SafetyControlObjectCheckListBaseWrapper
    {
        private ObservableCollection<SafetyCheckListQuestionAnswerType> _values;

        protected SafetyCheckListQuestionAnswerType _valueSelected;

        public SafetyCheckListQuestionAnswerType ValueSelected
        {
            get
            {
                return _valueSelected;
            }
            set
            {
                _valueSelected = value;
                if (_valueSelected != null)
                {
                    Model.Answer = _valueSelected.Value.ToString();
                    CalculateStatus();
                    SaveCheckListInformation(this);
                    ResetColorBackgroundQuestion();
                }
            }
        }

        public ObservableCollection<SafetyCheckListQuestionAnswerType> Values
        {
            get { return _values; }
            set
            {
                _values = value;
                OnPropertyChanged();
            }
        }

        public SafetyControlObjectQuestionSelect(ControlObjectsCheckList model, CheckListQuestionTypes AType, ICommand saveCheckListCommand) : base(model, AType, saveCheckListCommand)
        {
            Status = Domain.Enums.CheckListQuestionStatus.Unknown;
        }


        protected override void CalculateStatus()
        {
            if (_valueSelected != null) Status = _valueSelected.Sign;
            else
            {
                if (Model.SkipCheck) Status = CheckListQuestionStatus.NonAssigned;
                else Status = CheckListQuestionStatus.Unknown;
            }
        }

        public override void ResetQuestion()
        {
            ValueSelected = null;
            CalculateStatus();
        }
    }

}
