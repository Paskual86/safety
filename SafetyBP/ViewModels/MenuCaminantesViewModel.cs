using SafetyBP.Data;
using SafetyBP.Domain.Models;
using SafetyBP.Domain.Models.Modules.ControlObjects;
using SafetyBP.Domain.Models.Modules.CorrectiveAction;
using SafetyBP.Helpers;
using SafetyBP.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.ViewModels
{
    public class MenuCaminantesViewModel : BaseViewModel
    {
        private readonly IMainMenuBusiness _mainMenuBusiness;

        public bool Offline { get; set; }
        public List<Domain.Entities.HomeMenuItem> MenuItems { get; set; }

        public Command CargarItemsMenuCommand { get; set; }
        public Command SincronizacionCommand { get; set; }
        public ICommand LoadingPopup { get; set; }
        public bool MenuConfigurationIsVisible { get; set; }

        public ICommand LogoutCommand { get; private set; }

        protected string TitleDisplayLogout { get; private set; }
        protected string TitleDisplaySynchronization { get; private set; }
        protected string MessageDisplayLogout { get; private set; }
        protected string ThereIsNotInternetConnection { get; private set; }

        private string ButtonOk { get; set; }
        private string ButtonYes { get; set; }
        private string ButtonNo { get; set; }
        public Page CurrentPage { get; set; }
        public MenuCaminantesViewModel():base()
        {
            MenuConfigurationIsVisible = true;
            
            SincronizacionCommand = new Command(async () => await Synchronize());
            CargarItemsMenuCommand = new Command(async () => await LoadMenuItems());
            
            _mainMenuBusiness = new MainMenuBusiness();

            LogoutCommand = new Command(async () => {
                var action = await CurrentPage.DisplayAlert(TitleDisplayLogout, MessageDisplayLogout, ButtonYes, ButtonNo);
                if (action)
                {
                    LoginAgain();
                }
                
            });

            TitleDisplayLogout = GetTranslateValue(ApplicationWordsEnum.TitleDisplayLogout);
            TitleDisplaySynchronization = GetTranslateValue(ApplicationWordsEnum.TitleDisplaySynchronization);
            MessageDisplayLogout = GetTranslateValue(ApplicationWordsEnum.MessageDisplayLogout);
            ThereIsNotInternetConnection = GetTranslateValue(ApplicationWordsEnum.MessageDisplayThereIsNotInternet);
            ButtonOk = GetTranslateValue(ApplicationWordsEnum.LabelButtonOk);
            ButtonNo = GetTranslateValue(ApplicationWordsEnum.LabelButtonNo);
            ButtonYes = GetTranslateValue(ApplicationWordsEnum.LabelButtonYes);
        }

        private async Task CatchExceptionFor(System.Action action)
        {
            try
            {
                action.Invoke();
            }
            catch(Exception ex)
            {

            }
        }

        private async Task Synchronize()
        {
            if (!IsConnected())
            {
                await CurrentPage.DisplayAlert(TitleDisplaySynchronization, ThereIsNotInternetConnection, ButtonOk);
                return;
            }
            
            await PopupNavigation.PushAsync(new SincronizandoPage());

            try
            {
                await OffLineHelper.Synchronize(string.Empty);
                var token = await TokenBusiness.GetTokenAsync();
                var respuesta = await WebService.GetOfflineRecordsAsync(token);

                if (respuesta.Response == null)
                {
                    ErrorWithCredentialLoginAgain();
                    return;
                }
                else
                {
                    using (var blogContext = new SafetyBP.Persistance.SafetyContext())
                    {
                        await blogContext.DropDatabase();
                    }
                }

                await CatchExceptionFor(() => HardwareBusiness.SyncDatabase(Mapper.Map<List<ControlObjectsHardware>>(respuesta.Response.Content.ObjectControls)));
                await CatchExceptionFor(() => TasksBusiness.SyncDatabaseAsync(Mapper.Map<List<SafetyTask>>(respuesta.Response.Content.Tasks)));
                await CatchExceptionFor(() => ModuleCheckListsBusiness.SyncDatabaseAsync(Mapper.Map<List<SafetyCheckList>>(respuesta.Response.Content.CheckLists)));
                await CatchExceptionFor(() => SafetySectorBusiness.SyncDatabaseAsync(Mapper.Map<List<SafetySector>>(respuesta.Response.Content.Sectors)));
                await CatchExceptionFor(() => CorrectiveActionsBusiness.SyncDatabaseAsync(Mapper.Map<List<CorrectiveActionSector>>(respuesta.Response.Content.CorrectiveActions)));


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                await PopupNavigation.PopAsync();
            }
        }
        
        private async Task<bool> LoadMenuItems()
        {
            MenuItems = _mainMenuBusiness.GetMenu().Where(wh => wh.Enabled).ToList();
            OnPropertyChanged(nameof(MenuItems));

            return await Task.FromResult(true);
        }
    }
}
