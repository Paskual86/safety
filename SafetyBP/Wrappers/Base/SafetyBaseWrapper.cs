using SafetyBP.Data;
using SafetyBP.Domain.Enums;
using SafetyBP.Interfaces;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.Wrappers.Base
{
    public abstract class SafetyBaseWrapper<TModel> : ModelWrapper<TModel>
        where TModel : class
    {

        private ICommand _saveCheckListCommand;


        private Color _colorBackgroundQuestion;
        protected bool _commandIsExecuting;
        protected bool Initializating;
        
        public string NAValue { get; protected set; }
        public Color ColorBackgroundQuestion
        {
            get
            {
                return _colorBackgroundQuestion;
            }
            set
            {
                _colorBackgroundQuestion = value;
                OnPropertyChanged();
            }
        }

        protected ITranslateBusiness Translate { get; private set; }
        protected IToast Toaster { get; private set; }
        protected CheckListQuestionTypes CheckListType { get; private set; }
        public CheckListQuestionTypeGroup GroupType { get; private set; }

        public SafetyBaseWrapper(TModel model, CheckListQuestionTypes AType, ICommand saveCheckListCommand) : base(model)
        {
            Initializating = true;
            Translate = DependencyService.Get<ITranslateBusiness>();
            Toaster = DependencyService.Get<IToast>();

            CheckListType = AType;
            var lstButtons = new List<CheckListQuestionTypes>
            {
                CheckListQuestionTypes.Type1,
                CheckListQuestionTypes.Type2,
                CheckListQuestionTypes.Type7
            };

            var lstList = new List<CheckListQuestionTypes>
            {
                CheckListQuestionTypes.Type3,
                CheckListQuestionTypes.Type4,
                CheckListQuestionTypes.Type5,
                CheckListQuestionTypes.Type6,
            };

            if (lstButtons.Contains(CheckListType))
            {
                GroupType = CheckListQuestionTypeGroup.Button;
            }
            else
            {
                if (lstList.Contains(CheckListType)) GroupType = CheckListQuestionTypeGroup.List;
                else
                {
                    GroupType = CheckListQuestionTypeGroup.Unknown;
                }
            }
            _saveCheckListCommand = saveCheckListCommand;
            Initializate();
        }

        protected abstract void Initializate();

        public abstract void ResetColorBackgroundQuestion();
        public abstract void ResetQuestion();
        protected abstract void CalculateStatus();
        

        public void SetColorBackgroundQuestion()
        {
            SetColorBackgroundQuestion(OrangeColor);
        }

        public void SetColorBackgroundQuestion(Color color)
        {
            ColorBackgroundQuestion = color;
            ResetQuestion();
        }

        protected string GetTranslateValue(ApplicationWordsEnum applicationWords)
        {
            return Translate.GetText(applicationWords);
        }

        protected virtual void SaveCheckListInformation(SafetyBaseWrapper<TModel> checkList)
        {
            if ((checkList.Status != Domain.Enums.CheckListQuestionStatus.Unknown) && (!Initializating))
            {
                _saveCheckListCommand?.Execute(checkList.Model);
                _commandIsExecuting = false;
            }
        }

    }
}
