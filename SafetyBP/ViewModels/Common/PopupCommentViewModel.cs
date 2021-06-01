using SafetyBP.Interfaces;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.ViewModels.Common
{
    public class PopupCommentViewModel : BaseViewModel
    {

        private readonly ISpeachToTextBusiness _speachToTextBusiness;

        public string LabelPlaceholderText { get; set; }
        public string SpeachToTextLabel { get; set; }
        public string Text { get; set; }

        public ICommand SpeachToTextCommandCallback { get; set; }
        public ICommand SpeachToTextCommand { get; set; }

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private ICommand _cancelCommand { get; set; }
        public PopupCommentViewModel(ICommand save, ICommand cancel):base()
        {
            _speachToTextBusiness = DependencyService.Get<ISpeachToTextBusiness>();

            LabelPlaceholderText = GetTranslateValue(Data.ApplicationWordsEnum.LabelPlaceholderTextComments);
            SpeachToTextLabel = GetTranslateValue(Data.ApplicationWordsEnum.SpeachToTextLabel);
            SaveCommand = new Command(async () =>
            {
                save.Execute(Text);
                Toaster.Short(GetTranslateValue(Data.ApplicationWordsEnum.CommentSaveProperly));
                await ClosePopUp();
            });

            _cancelCommand = cancel;
            CancelCommand = new Command(async () =>
            {
                if(_cancelCommand != null) _cancelCommand.Execute(null);
                await ClosePopUp();
            });

            SpeachToTextCommandCallback = new Command<string>(parameter =>
            {

                Text = parameter;
                OnPropertyChanged(nameof(Text));
            });

            SpeachToTextCommand = new Command(() =>
            {
                _speachToTextBusiness.BeganToRecord(SpeachToTextCommandCallback);
            });
        }

        private async Task ClosePopUp() {
            await PopupNavigation.PopAsync();
        }
    }
}
