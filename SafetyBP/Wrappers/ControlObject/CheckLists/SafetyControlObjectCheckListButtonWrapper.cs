using SafetyBP.Domain.Enums;
using SafetyBP.Domain.Models.Modules.ControlObjects;
using SafetyBP.ViewModels.ControlObjects;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.Wrappers.ControlObject
{
    public class SafetyControlObjectCheckListButtonWrapper : SafetyControlObjectCheckListBaseWrapper
    {
        protected ControlObjectPopupMenuViewModel _popupMenu;

        public SafetyControlObjectCheckListButtonWrapper(ControlObjectsCheckList model, CheckListQuestionTypes AType, ICommand saveCheckListCommand) : base(model, AType, saveCheckListCommand)
        {
            _commandIsExecuting = false;

            ButtonPositiveCommand = new Command<SafetyControlObjectCheckListButtonWrapper>(parameter => {
                OnButtonPositiveCommand(parameter);
            });

            ButtonNegativeCommand = new Command<SafetyControlObjectCheckListButtonWrapper>(parameter => {
                OnButtonNegativeCommand(parameter);
            });

            NAValue = VALUE_NA;

            if (!Model.SkipCheck)
            {
                switch (Model.Answer.Trim())
                {
                    case VALUE_NO: ButtonNegativeColor = RedColor; break;
                    case VALUE_YES: ButtonPositiveColor = GreenColor; break;
                    case VALUE_NA:
                        {
                            ButtonNegativeColor = ButtonNegativeColor = Color.LightGray;
                            SetColorBackgroundQuestion();
                            Model.Answer = NAValue;
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

        protected override void CalculateStatus()
        {
            switch (Model.Answer)
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
            if (Model.Answer != NAValue) Model.Answer = string.Empty;
            CalculateStatus();
        }

        protected virtual void OnButtonPositiveCommand(SafetyControlObjectCheckListButtonWrapper button)
        {
            if (!_commandIsExecuting)
            {
                if (!button.IsButtonPositiveAssigned)
                {
                    _commandIsExecuting = true;
                    button.ButtonPositiveColor = GreenColor;
                    CheckoutAdditionalActions(button);
                }
            }
        }

        protected virtual void OnButtonNegativeCommand(SafetyControlObjectCheckListButtonWrapper button)
        {
            if (!_commandIsExecuting)
            {
                if (!button.IsButtonNegativeAssigned)
                {
                    _commandIsExecuting = true;
                    button.ButtonNegativeColor = RedColor;
                    CheckoutAdditionalActions(button);
                }
            }
        }

        protected virtual void CheckoutAdditionalActions(SafetyControlObjectCheckListBaseWrapper checkList)
        {
            if (checkList != null)
            {
                if (checkList.Model.IsPhotoRequired)
                {
                    Toaster.Short(GetTranslateValue(Data.ApplicationWordsEnum.CameraInitialization));

                    _popupMenu = new ControlObjectPopupMenuViewModel(checkList.Model)
                    {
                        CallbackCameraError = new Command<ControlObjectsCheckList>(parameter =>
                        {
                            if (parameter != null)
                            {
                                SaveCheckListInformation(checkList);
                                Toaster.Short(GetTranslateValue(Data.ApplicationWordsEnum.PhotoIsRequired));
                            }
                        }),

                        CallbackCameraSuccessfully = new Command<ControlObjectsCheckList>(parameter =>
                        {
                            if (parameter != null) SaveCheckListInformation(checkList);

                        })
                    };
                    _popupMenu.OnCameraCommand.Execute(null);
                }
                else
                {
                    SaveCheckListInformation(checkList);
                }
            }
            else {
                _commandIsExecuting = false;
            }

        }

        protected override void SetModelValue(string value)
        {
            Model.Answer = value;
        }

        protected override string GetModelValue()
        {
            return Model.Answer;
        }
    }
}
