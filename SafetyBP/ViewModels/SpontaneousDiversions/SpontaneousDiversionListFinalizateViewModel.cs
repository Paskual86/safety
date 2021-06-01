using SafetyBP.Domain.Interfaces;
using SafetyBP.Domain.Models;
using SafetyBP.Domain.Wrappers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.ViewModels.SpontaneousDiversions
{
    public class SpontaneousDiversionListFinalizateViewModel : BaseViewModel
    {
        private const byte STATUS_PENDING = 1;
        private const byte STATUS_RESOLVED = 2;

        private readonly ISpontaneousDiversionBusiness _spontaneousDiversionBusiness;

        public ObservableCollection<WrapperAddColor<SafetySpontaneousDiversion>> ListDiversions { get; set; }
        public string NameOfRound { get; set; }
        public string NameOfRoundPlaceHolder { get; set; }

        public ICommand FinalizeCommand { get; set; }
        private readonly ICommand SendToServerCallbackCommand;
        private readonly ICommand SendToServerCallbackPostCommand;

        public SpontaneousDiversionListFinalizateViewModel(IEnumerable<SafetySpontaneousDiversion> lstdiversion)
        {
            _spontaneousDiversionBusiness = DependencyService.Get<ISpontaneousDiversionBusiness>();

            ListDiversions = new ObservableCollection<WrapperAddColor<SafetySpontaneousDiversion>>(lstdiversion
                                                                                                    .Select(sl => new WrapperAddColor<SafetySpontaneousDiversion>(sl) 
                                                                                                                                                    { Color = sl.Status == STATUS_PENDING? Color.Default : Color.FromHex("#28b34b") }));
            OnPropertyChanged(nameof(ListDiversions));

            LabelButtonFinalize = GetTranslateValue(Data.ApplicationWordsEnum.LabelButtonSave);
            NameOfRoundPlaceHolder = GetTranslateValue(Data.ApplicationWordsEnum.PlaceHolderNameOfRound);

            FinalizeCommand = new Command(async () => await OnFinalizeCommand());

            SendToServerCallbackCommand = new Command(async () =>
            {
                await SendToServerCallback();
            });

            SendToServerCallbackPostCommand = new Command(async () =>
            {
                await Navigation.PopToRootAsync();
                await FinalizateLoaderPage();
            });

        }

        private async Task OnFinalizeCommand()
        {
            if (await IsValid())
            {
                await CatchLoadingFor(
                    GetTranslateValue(Data.ApplicationWordsEnum.PopUpFinalizeSpontaneousDiversionLabel), async () =>
                    {
                        if (await _spontaneousDiversionBusiness.AnyPendingToFinalizeAsync())
                        {
                            await _spontaneousDiversionBusiness.SendToServer(NameOfRound, () =>
                                SendToServerCallbackCommand.Execute(null));
                        }
                        else
                        {
                            Toaster.Short(GetTranslateValue(Data.ApplicationWordsEnum
                                .ToastMessageSpontaneousDiversionThereAreNotItems));
                        }
                    });
            }
            else
            {
                Toaster.Short(GetTranslateValue(Data.ApplicationWordsEnum.ToastMessageMissingRoundName));
            }
        }

        private async Task<bool> IsValid()
        {
            var quantity = await _spontaneousDiversionBusiness.GetPendingToFinalizeListAsync();
            
            if (quantity.Count() > 1)
            {
                if (string.IsNullOrWhiteSpace(NameOfRound)) return false;
            }

            return true;
        }

        private async Task SendToServerCallback()
        {
            await SpontaneousDiversionRestClient.CommitOperation(OperationId, result =>
            {
                Toaster.Short(GetTranslateValue(Data.ApplicationWordsEnum.ToastMessageSpontaneousDiversionSaveProperly));
                SendToServerCallbackPostCommand.Execute(null);
            });
        }
    }
}
