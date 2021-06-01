using SafetyBP.Domain.Models.Modules.ControlObjects;
using SafetyBP.ViewModels.ControlObjects;
using SafetyBP.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SafetyBP.ViewModels
{
    public class ControlObjetosRelevamientosViewModel : ControlObjectBaseViewModel
    {
        public ControlObjectsSector Sector { get; set; }
        public ObservableCollection<ControlObjectsSurvey> Surveys { get; set; }
        public Command LoadDataCommand { get; set; }
        public ControlObjetosRelevamientosViewModel(ControlObjectsSector sector) :base()
        {
            Sector = sector;
            Title = GetTranslateValue(Data.ApplicationWordsEnum.PageTitleObjects).ToUpper();
            // Comandos
            LoadDataCommand = new Command(async () => await LoadData());

            OnNextCommand = new Command<object>(async parameter =>
            {
                await NextCommand(parameter);
            });

            LoadDataCommand.Execute(null);

        }

        public override async Task LoadData()
        {
            Surveys = new ObservableCollection<ControlObjectsSurvey>(await HardwareBusiness.GetSurveysAsync(Sector.HardwareId, Sector.Id));
            OnPropertyChanged(nameof(Surveys));
        }

        private async Task NextCommand(object parameter)
        {
            await Navigation.PushAsync(new ControlObjetosPreguntasPage(new ControlObjetosPreguntasViewModel((ControlObjectsSurvey)parameter)));
        }
    }
}
