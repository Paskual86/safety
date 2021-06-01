using SafetyBP.Domain.Models.Modules.ControlObjects;
using SafetyBP.ViewModels.ControlObjects;
using SafetyBP.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SafetyBP.ViewModels
{
    public class ControlObjetosEquiposViewModel : ControlObjectBaseViewModel
    {
        private IList<ControlObjectsHardware> _hardware;
        public ObservableCollection<ControlObjectsHardware> Hardware { get; set; }
        public Command LoadHardware { get; set; }
        public ControlObjetosEquiposViewModel():base(Data.ApplicationWordsEnum.PageTitleHardware)
        {
            OnNextCommand = new Command<object>(async parameter =>
            {
                await NextCommand(parameter);
            });

            // Comandos
            LoadHardware = new Command(async () => await LoadData());
            LoadHardware.Execute(null);
        }

        public override async Task LoadData()
        {
            _hardware = new List<ControlObjectsHardware>(await HardwareBusiness.GetListAsync());
            Hardware = new ObservableCollection<ControlObjectsHardware>(_hardware);
            OnPropertyChanged(nameof(Hardware));
        }

        private async Task NextCommand(object parameter)
        {
            await Navigation.PushAsync(new ControlObjetosSectoresPage(new ControlObjetosSectoresViewModel((ControlObjectsHardware)parameter)));
        }

    }
}
