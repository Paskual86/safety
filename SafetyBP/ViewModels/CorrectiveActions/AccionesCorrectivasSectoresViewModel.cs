using SafetyBP.Domain.Models.Modules.CorrectiveAction;
using SafetyBP.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SafetyBP.ViewModels
{
    public class AccionesCorrectivasSectoresViewModel : BaseViewModel
    {
        public new ObservableCollection<CorrectiveActionSector> Sectors { get; set; }
        private Command LoadDataCommand;
        public AccionesCorrectivasSectoresViewModel():base()
        {
            // Título de la página
            this.Title = GetTranslateValue(Data.ApplicationWordsEnum.PageTitleSector).ToUpper();

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
            Sectors = new ObservableCollection<CorrectiveActionSector>(await CorrectiveActionsBusiness.GetSectorsAsync());
            OnPropertyChanged(nameof(Sectors));
        }

        private async Task NextCommand(object parameter)
        {
            await Navigation.PushAsync(new AccionesCorrectivasTemasPage(new AccionesCorrectivasTemasViewModel((CorrectiveActionSector)parameter)));
        }
    }
}