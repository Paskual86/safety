using SafetyBP.Domain.Enums;
using SafetyBP.Domain.Models;
using SafetyBP.ViewModels.CheckList;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.Wrappers
{
    public class SafetyCheckListQuestionButtonWrapper : SafetyCheckListQuestionBaseWrapper
    {
        protected CheckListPopupMenuViewModel _popupMenu;

        public SafetyCheckListQuestionButtonWrapper(SafetyCheckListQuestion model, ICommand saveCheckListCommand, CheckListQuestionTypes AType) : base(model, AType, saveCheckListCommand)
        {
            _commandIsExecuting = false;

            ButtonPositiveCommand = new Command<SafetyCheckListQuestionBaseWrapper>(parameter => {
                OnButtonPositiveCommand(parameter);
            });

            ButtonNegativeCommand = new Command<SafetyCheckListQuestionBaseWrapper>(parameter => {
                OnButtonNegativeCommand(parameter);
            });

            NAValue = VALUE_NA;

            if (!Model.DoesNotApply)
            {
                switch (Model.Value.Trim())
                {
                    case VALUE_NO: ButtonNegativeColor = RedColor; break;
                    case VALUE_YES: ButtonPositiveColor = GreenColor; break;
                    case VALUE_NA:
                        {
                            Model.DoesNotApply = true;
                            SetColorBackgroundQuestion();
                        }
                        break;
                    default:
                        {
                            ButtonPositiveColor = ButtonNegativeColor = Color.LightGray;
                        }
                        break;
                }
            }
            else
            {
                SetColorBackgroundQuestion();
            }
        }

        protected override void Initializate()
        {
            if (!Model.DoesNotApply) ResetColorBackgroundQuestion();
            else SetColorBackgroundQuestion(OrangeColor);
        }

        protected override void CalculateStatus()
        {
            switch (Model.Value)
            {
                case VALUE_NO: Status = CheckListQuestionStatus.Negative; break;
                case VALUE_YES: Status = CheckListQuestionStatus.Positive; break;
                case VALUE_NA: Status = CheckListQuestionStatus.NonAssigned; break;
                default: Status = CheckListQuestionStatus.Unknown; break;
            }
        }

        public override void ResetQuestion()
        {
            ButtonPositiveColor = ButtonNegativeColor = Color.LightGray;
            if (!Model.DoesNotApply) Model.Value = string.Empty;
            CalculateStatus();
        }

        protected virtual void OnButtonPositiveCommand(SafetyCheckListQuestionBaseWrapper button)
        {
            if (!_commandIsExecuting)
            {
                if (!((SafetyCheckListQuestionButtonWrapper)button).IsButtonPositiveAssigned)
                {
                    _commandIsExecuting = true;
                    ((SafetyCheckListQuestionButtonWrapper)button).ButtonPositiveColor = GreenColor;
                    CheckoutAdditionalActions(button);
                }
            }
        }

        protected virtual void OnButtonNegativeCommand(SafetyCheckListQuestionBaseWrapper button)
        {
            if (!_commandIsExecuting)
            {
                if (!((SafetyCheckListQuestionButtonWrapper)button).IsButtonNegativeAssigned)
                {
                    _commandIsExecuting = true;
                    ((SafetyCheckListQuestionButtonWrapper)button).ButtonNegativeColor = RedColor;
                    CheckoutAdditionalActions(button);
                }
            }
        }


        protected virtual void CheckoutAdditionalActions(SafetyCheckListQuestionBaseWrapper checkList)
        {
            if (checkList != null)
            {
                if (checkList.Model.PhotoRequired)
                {
                    Toaster.Short(GetTranslateValue(Data.ApplicationWordsEnum.CameraInitialization));

                    _popupMenu = new CheckListPopupMenuViewModel(checkList.Model)
                    {
                        CallbackCameraError = new Command<SafetyCheckListQuestion>(parameter =>
                        {
                            if (parameter != null)
                            {
                                //Toaster.Short(GetTranslateValue(Data.ApplicationWordsEnum.PhotoIsRequired));
                                SaveCheckListInformation(checkList);
                            }
                        }),
                        CallbackCameraSuccessfully = new Command<SafetyCheckListQuestion>(parameter =>
                        {
                            if (parameter != null)
                            {
                                SaveCheckListInformation(checkList);
                            }
                        })
                    };
                    _popupMenu.OnCameraCommand.Execute(null);
                }
                else
                {
                    SaveCheckListInformation(checkList);
                }
            }
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
