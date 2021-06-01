using SafetyBP.Domain.Enums;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.Wrappers.Base
{
    public abstract class SafetyBaseButtonWrapper<TModel> : SafetyBaseWrapper<TModel>
        where TModel : class
    {
        private Color _buttonPositiveColor;
        private Color _buttonNegativeColor;
        
        protected const string VALUE_YES = "1";
        protected const string VALUE_NO = "0";
        protected const string VALUE_NA = "-1";

        public ICommand ButtonPositiveCommand { get; set; }
        public ICommand ButtonNegativeCommand { get; set; }

        public string ButtonPositiveText { get; set; }
        public string ButtonNegativeText { get; set; }

        public Color ButtonPositiveColor
        {
            get { return _buttonPositiveColor; }
            set
            {
                _buttonPositiveColor = value;
                if (_buttonPositiveColor != Color.LightGray)
                {
                    ButtonNegativeColor = Color.LightGray;
                    SetModelValue(VALUE_YES);
                    CalculateStatus();
                    ResetColorBackgroundQuestion();
                }
                OnPropertyChanged();
            }
        }

        public Color ButtonNegativeColor
        {
            get { return _buttonNegativeColor; }
            set
            {
                _buttonNegativeColor = value;
                if (_buttonNegativeColor != Color.LightGray)
                {

                    ButtonPositiveColor = Color.LightGray;
                    SetModelValue(VALUE_NO);
                    CalculateStatus();
                    ResetColorBackgroundQuestion();
                }
                OnPropertyChanged();
            }
        }

        public bool IsButtonPositiveAssigned
        {
            get
            {
                return (GetModelValue() == VALUE_YES);
            }
        }

        public bool IsButtonNegativeAssigned
        {
            get
            {
                return (GetModelValue() == VALUE_NO);
            }
        }

        public SafetyBaseButtonWrapper(TModel model, CheckListQuestionTypes AType, ICommand saveCheckListCommand) : base(model, AType, saveCheckListCommand)
        {
            NAValue = VALUE_NA;
        }

        protected abstract void SetModelValue(string value);
        protected abstract string GetModelValue();

        public override void ResetColorBackgroundQuestion()
        {
            ColorBackgroundQuestion = Xamarin.Forms.Color.Default;
        }
    }
}
