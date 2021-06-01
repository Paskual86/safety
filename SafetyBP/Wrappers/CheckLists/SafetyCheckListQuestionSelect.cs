using SafetyBP.Domain.Enums;
using SafetyBP.Domain.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SafetyBP.Wrappers
{
    public class SafetyCheckListQuestionSelect : SafetyCheckListQuestionBaseWrapper
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
                Model.Value = _valueSelected.Value.ToString();
                CalculateStatus();
                SaveCheckListInformation(this);
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

        public SafetyCheckListQuestionSelect(SafetyCheckListQuestion model, CheckListQuestionTypes AType, ICommand saveCheckListCommand) : base(model, AType, saveCheckListCommand)
        {
            Status = Domain.Enums.CheckListQuestionStatus.Unknown;
        }


        protected override void CalculateStatus()
        {
            if (_valueSelected != null)
            {
                Status = _valueSelected.Sign;
            }
            else { 
                if (Model.DoesNotApply) Status = CheckListQuestionStatus.NonAssigned;
            }
        }
        
        public override void ResetQuestion()
        {
            _valueSelected = null;
            CalculateStatus();
        }
    }
}
