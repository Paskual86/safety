using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.ViewModels.Common
{
    public class DisplayAlertYesNoViewModel : BaseViewModel
    {
        private readonly ICommand _okCommandCallback;
        private readonly ICommand _cancelCommandCallback;

        public string Message { get; set; }
        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public string LabelButtonOk { get; set; }
        public string LabelButtonCancel { get; set; }

        public Color ColorButtonOk { get; set; }
        public Color ColorButtonCancel { get; set; }
        public DisplayAlertYesNoViewModel(string ATitle, string AMessage, ICommand callback) : base()
        {
            Title = ATitle;
            Message = AMessage;

            OkCommand = new Command(() =>
            {
                callback.Execute(true);
                OnCloseCommand.Execute(null);
            });

            CancelCommand = new Command(() =>
            {
                callback.Execute(false);
                OnCloseCommand.Execute(null);
            });

            LabelButtonOk = GetTranslateValue(Data.ApplicationWordsEnum.LabelButtonYes);
            LabelButtonCancel = GetTranslateValue(Data.ApplicationWordsEnum.LabelButtonNo);

            ColorButtonOk = Color.FromHex("#28b34b");
            ColorButtonCancel = Color.FromHex("#fc0025");
            OnPropertyChanged(nameof(LabelButtonOk));
            OnPropertyChanged(nameof(LabelButtonCancel));
            OnPropertyChanged(nameof(ColorButtonOk));
            OnPropertyChanged(nameof(ColorButtonCancel));
        }
    }
}