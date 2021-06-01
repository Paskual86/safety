using SafetyBP.Core;
using SafetyBP.Core.Business;
using SafetyBP.Core.Helpers;
using SafetyBP.Core.Interfaces;
using SafetyBP.Domain.Interfaces;
using SafetyBP.EntityMapper.Base;
using SafetyBP.Helpers;
using SafetyBP.Interfaces;
using SafetyBP.Messages;
using SafetyBP.Services;
using SafetyBP.Services.WebServices;
using SafetyBP.ViewModels;
using SafetyBP.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SafetyBP
{
    public partial class App : Application
    {
        private readonly ITokenBusiness _tokenBusiness;
        private readonly IToastMessages _toastMessages;

        public App()
        {
            InitializeComponent();
            DependencyService.Register<WebService>();

            DependencyService.Register<TranslateBusiness>();
            DependencyService.Register<TranslateHelpers>();
            DependencyService.Register<BaseMapper>();
            DependencyService.Register<HardwareBusiness>();
            DependencyService.Register<CorrectiveActionsBusiness>();
            DependencyService.Register<TasksBusiness>();
            DependencyService.Register<ToastMessages>();
            DependencyService.Register<TokenBusiness>();
            DependencyService.Register<SafetyCamera>();
            DependencyService.Register<ModuleCheckListsBusiness>();
            DependencyService.Register<SafetySectorBusiness>();
            DependencyService.Register<SpontaneousDiversionBusiness>();
            DependencyService.Register<ControlObjectWebService>();
            
            DependencyService.Register<CorrectiveActionRestClient>();
            DependencyService.Register<CheckListRestClient>();
            DependencyService.Register<TaskBoardRestClient>();
            DependencyService.Register<SpontaneousDiversionRestClient>();

            DependencyService.Register<CallApiHelper>();
            DependencyService.Register<OffLineHelper>();


            _tokenBusiness = DependencyService.Get<ITokenBusiness>();
            _toastMessages = DependencyService.Get<IToastMessages>();
        }

        protected override async void OnStart()
        {
            var tokenGuardado = await _tokenBusiness.GetTokenAsync();

            // SI NO HAY TOKEN, VA DIRECTAMENTE A LA LOGIN PAGE
            if (string.IsNullOrEmpty(tokenGuardado))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                // SI HAY TOKEN, VA DIRECTAMENTE A MENUCAMINANTES
                bool offline = false;
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    offline = true;
                    DependencyService.Get<IToast>().Short(_toastMessages.GetMessage( Data.ToastMessagesEnum.AppOffline));
                }

                MenuCaminantesViewModel vm = new MenuCaminantesViewModel
                {
                    Offline = offline
                };
                MainPage = new NavigationPage(new MenuCaminantesPage(vm));
            }
        }

        DateTime horaSleep;
        protected override void OnSleep()
        {
            horaSleep = DateTime.Now;
        }

        protected override void OnResume()
        {
            DateTime horaResumen = DateTime.Now;

            Double difEntreHoras = (horaResumen - horaSleep).TotalSeconds;

            // 15 min = 900 sec
            if (difEntreHoras >= 900 && Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                MessagingCenter.Send(new SincronizacionMessage() { Disparar = true }, "DispararSincronizacion");             
            }
        }


        
    }
}
