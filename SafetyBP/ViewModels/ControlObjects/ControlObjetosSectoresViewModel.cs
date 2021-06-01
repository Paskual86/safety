using SafetyBP.Domain.Models.Modules.ControlObjects;
using SafetyBP.ViewModels.ControlObjects;
using SafetyBP.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SafetyBP.ViewModels
{
    public class ControlObjetosSectoresViewModel : ControlObjectBaseViewModel
    {
        public ControlObjectsHardware Hardware { get; set; }
        public new ObservableCollection<ControlObjectsSector> Sectors { get; set; }
        public Command LoadDataCommand { get; set; }
        public ControlObjetosSectoresViewModel(ControlObjectsHardware hardware) :base()
        {
            Hardware = hardware;
            Title = GetTranslateValue(Data.ApplicationWordsEnum.PageTitleSector).ToUpper();
            LoadDataCommand = new Command(async () => await LoadData());
            LoadDataCommand.Execute(null);

            OnNextCommand = new Command<object>(async parameter =>
            {
                await NextCommand(parameter);
            });
        }

        public override async Task LoadData()
        {
            Sectors = new ObservableCollection<ControlObjectsSector>(await HardwareBusiness.GetSectorsAsync(Hardware.Id));
            OnPropertyChanged(nameof(Sectors));
        }

        private async Task NextCommand(object parameter)
        {
            await Navigation.PushAsync(new ControlObjetosRelevamientosPage(new ControlObjetosRelevamientosViewModel((ControlObjectsSector)parameter)));
        }

    }
}

