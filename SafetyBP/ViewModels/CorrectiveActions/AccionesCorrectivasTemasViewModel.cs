using SafetyBP.Domain.Models.Modules.CorrectiveAction;
using SafetyBP.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.ViewModels
{
    public class AccionesCorrectivasTemasViewModel : BaseViewModel
    {
        public CorrectiveActionSector Sector { get; set; }
        public ObservableCollection<CorrectiveActionTopic> Topics { get; set; }
        public ICommand LoadDataCommand { get; set; }
        public AccionesCorrectivasTemasViewModel(CorrectiveActionSector sector) :base()
        {
            Sector = sector;
            Title = GetTranslateValue(Data.ApplicationWordsEnum.PageTitleTopics).ToUpper();
            LoadDataCommand = new Command(async () => await LoadData());
            OnNextCommand = new Command<object>(async parameter =>
            {
                await NextCommand(parameter);
            });

            LoadDataCommand.Execute(null);
        }

        public override async Task LoadData()
        {
            Topics = new ObservableCollection<CorrectiveActionTopic>(await CorrectiveActionsBusiness.GetTopicsAsync(Sector.Id));
            OnPropertyChanged(nameof(Topics));
        }

        private async Task NextCommand(object parameter)
        {
            await Navigation.PushAsync(new AccionesCorrectivasTareasPage(new AccionesCorrectivasTareasViewModel((CorrectiveActionTopic)parameter)));
        }
    }
}