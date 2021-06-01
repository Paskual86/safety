using SafetyBP.Domain.Models;
using SafetyBP.Interfaces;
using SafetyBP.Models.Common;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SafetyBP.ViewModels
{
    public class ComentarioViewModel : BaseViewModel
    {
        private readonly ISpeachToTextBusiness _speachToTextBusiness;

        private SafetyTaskCheckList xSafetyTaskCheck;

        public string LabelPlaceholderText { get; set; }
        public string SpeachToTextLabel { get; set; }

        public SafetyTaskCheckList SafetyTaskCheck 
        {
            get { return xSafetyTaskCheck; }
            set { SetProperty(ref xSafetyTaskCheck, value); }
        }

        private string xBackupComentario;
        public string BackupComentario
        {
            get { return xBackupComentario; }
            set { SetProperty(ref xBackupComentario, value); }
        }

        private string xText;
        public string Text
        {
            get { return xText; }
            set { SetProperty(ref xText, value); }
        }

        public ICommand SpeachToTextCommandCallback { get; set; }
        public ICommand SpeachToTextCommand { get; set; }

        public Command GuardarComentarioCommand { get; set; }
        public Command VolverCommand { get; set; }

        // Definidos en la vista
        public ICommand CerrarPopup { get; set; }
        private Command<SafetyTaskCheckList> _saveCommentCommand;
        public ComentarioViewModel(Command<SafetyTaskCheckList> saveCommentCommand) :this()
        {
            _saveCommentCommand = saveCommentCommand;
        }

        public ComentarioViewModel()
        {
            _speachToTextBusiness = DependencyService.Get<ISpeachToTextBusiness>();

            // Comandos
            this.GuardarComentarioCommand = new Command(async () => await guardarComentario());
            this.VolverCommand = new Command(async () => await volver());

            LabelPlaceholderText = GetTranslateValue(Data.ApplicationWordsEnum.LabelPlaceholderTextComments);
            SpeachToTextLabel = GetTranslateValue(Data.ApplicationWordsEnum.SpeachToTextLabel);

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

        private async Task guardarComentario()
        {
            RespuestaPost respuesta = new RespuestaPost { Message = "El comentario se guardo correctamente" };
            // Obtiene el token guardado en el celular
            var token = await SecureStorage.GetAsync("token");

            if (!string.IsNullOrEmpty(Text))
            {
                SafetyTaskCheck.Comments = Text;
                _saveCommentCommand.Execute(SafetyTaskCheck);
                Toaster.Short(respuesta.Message);
                CerrarPopup.Execute(null);
            }
        }

        private async Task volver()
        {
            CerrarPopup.Execute(null);
        }
    }
}
