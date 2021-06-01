using AutoMapper;
using Rg.Plugins.Popup.Contracts;
using SafetyBP.Core.Interfaces;
using SafetyBP.Data;
using SafetyBP.Domain.Interfaces;
using SafetyBP.Domain.Interfaces.Helpers;
using SafetyBP.EntityMapper.Base;
using SafetyBP.Interfaces;
using SafetyBP.Services;
using SafetyBP.Services.WebServices;
using SafetyBP.Views;
using SafetyBP.Views.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, IBaseViewModel
    {
        protected static int OperationId { get { return SafetyOperation.OperationId; } }
        public IWebService WebService => DependencyService.Get<IWebService>();
        protected IHardwareBusiness HardwareBusiness { get; private set; }
        protected ITasksBusiness TasksBusiness { get; private set; }
        protected IModuleCheckListsBusiness ModuleCheckListsBusiness { get; private set; } // TODO: This should be rename and remove the other when I have time
        protected ISafetySectorBusiness SafetySectorBusiness { get; private set; }
        protected ICorrectiveActionsBusiness CorrectiveActionsBusiness { get; private set; }
        protected ITokenBusiness TokenBusiness { get; private set; }
        protected IOffLineHelper OffLineHelper { get; set; }
        protected IToastMessages ToastMessages { get; private set; }
        protected IToast Toaster { get; private set; }
        protected IMapper Mapper { get; private set; }
        protected ITranslateBusiness Translate { get; private set; }

        protected ICorrectiveActionRestClient CorrectiveActionRestClient { get; private set; }
        protected ICheckListRestClient CheckListRestClient { get; private set; }
        protected ITaskBoardRestClient TaskBoardRestClient { get; private set; }
        protected ISpontaneousDiversionRestClient SpontaneousDiversionRestClient { get; private set; }

        protected ICommand BeginOperationCommand { get; private set; }
        protected ICommand BackToHomeCommand { get; private set; }
        public ICommand OnNextCommand { get ; set ; }
        public ICommand OnMenuCommand { get; set; } // Call the menu of 3 points
        public ICommand OnCloseCommand { get; set; }
        public ICommand OnCommentsCommand { get; set; }
        public ICommand OnCameraCommand { get; set; }


        bool isEnabled = true;

        // Labels 
        public string LabelButtonFinalize { get; set; }
        public string LabelButtonSave { get; set; }
        public string LabelButtonBack { get; set; }
        public string LabelDueDatetime { get; set; }
        public string LabelStartDatetime { get; set; }
        public string WhiteSpace { get; set; }

        // Navigation for sectors
        public ObservableCollection<IBaseEntity> Sectors { get; set; }
        
        public INavigation Navigation { get; set; }
        public IPopupNavigation PopupNavigation { get; set; }
        protected Color GreenColor { get { return Color.FromHex("#259b24"); } }
        protected Color RedColor { get { return Color.FromHex("#fc0025"); } }

        protected Color GrayColor { get { return Color.FromHex("#403f3e"); } }

        public BaseViewModel() : this(ApplicationWordsEnum.Empty)
        {
        }

        public BaseViewModel(ApplicationWordsEnum appType)
        {
            HardwareBusiness = DependencyService.Get<IHardwareBusiness>();
            TasksBusiness = DependencyService.Get<ITasksBusiness>();
            ModuleCheckListsBusiness = DependencyService.Get<IModuleCheckListsBusiness>(); // TODO: This should be rename and remove the other when I have time
            TokenBusiness = DependencyService.Get<ITokenBusiness>();
            ToastMessages = DependencyService.Get<IToastMessages>();
            Toaster = DependencyService.Get<IToast>();
            Translate = DependencyService.Get<ITranslateBusiness>();
            Mapper = DependencyService.Get<IBaseMapper>().Mapper;
            SafetySectorBusiness = DependencyService.Get<ISafetySectorBusiness>();
            CorrectiveActionsBusiness = DependencyService.Get<ICorrectiveActionsBusiness>();
            OffLineHelper = DependencyService.Get<IOffLineHelper>();
            CorrectiveActionRestClient = DependencyService.Get<ICorrectiveActionRestClient>();
            CheckListRestClient = DependencyService.Get<ICheckListRestClient>();
            TaskBoardRestClient = DependencyService.Get<ITaskBoardRestClient>();
            SpontaneousDiversionRestClient = DependencyService.Get<ISpontaneousDiversionRestClient>();
            SetCommonLabels();

            if (appType != ApplicationWordsEnum.Empty)
            {
                Title = GetTranslateValue(appType).ToUpper();
            }

            OnCloseCommand = new Command(async () => await OnCloseCommandEvent());
            WhiteSpace = " ";

            PopupNavigation = Rg.Plugins.Popup.Services.PopupNavigation.Instance;

            BackToHomeCommand = new Command(async () => await Navigation.PopToRootAsync());
            BeginOperationCommand = new Command<string>(async module => await BeginOperation(module));
        }

        private void SetCommonLabels()
        {
            LabelButtonSave = GetTranslateValue(ApplicationWordsEnum.LabelButtonSave);
            LabelButtonBack = GetTranslateValue(ApplicationWordsEnum.LabelButtonBack);
            LabelDueDatetime = GetTranslateValue(Data.ApplicationWordsEnum.LabelDueDate).ToUpper();
            LabelStartDatetime = GetTranslateValue(Data.ApplicationWordsEnum.LabelStartDate).ToUpper();
            LabelButtonFinalize = GetTranslateValue(Data.ApplicationWordsEnum.LabelButtonFinalize);
            OnPropertyChanged(nameof(LabelButtonSave));
            OnPropertyChanged(nameof(LabelButtonBack));
            OnPropertyChanged(nameof(LabelDueDatetime));
            OnPropertyChanged(nameof(LabelStartDatetime));
            OnPropertyChanged(nameof(LabelButtonFinalize));
        }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetProperty(ref isEnabled, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public bool IsConnected()
        {            
            return OffLineHelper.IsConnected();
        }

        protected void Logout() 
        {
            TokenBusiness.RemoveToken();
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }

        protected void LoginAgain() 
        {
            TokenBusiness.RemoveToken();
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
        protected void ErrorWithCredentialLoginAgain()
        {
            Toaster.Short(ToastMessages.GetMessage(Data.ToastMessagesEnum.ErrorWithCredentialsPleaseLogin));
            LoginAgain();
        }

        protected virtual void ThereWasAnErrorTryLater()
        {
            Toaster.Short(ToastMessages.GetMessage(Data.ToastMessagesEnum.ThereWasAnErrorTryLater));
        }

        protected string GetTranslateValue(ApplicationWordsEnum applicationWords)
        {
            return Translate.GetText(applicationWords);
        }

        protected virtual async System.Threading.Tasks.Task OnCloseCommandEvent()
        {
            await PopupNavigation.PopAsync();
        }

        protected byte[] ImageDataFromResource(string r)
        {
            // Ensure "this" is an object that is part of your implementation within your Xamarin forms project
            var assembly = this.GetType().GetTypeInfo().Assembly;
            byte[] buffer = null;

            using (System.IO.Stream s = assembly.GetManifestResourceStream(r))
            {
                if (s != null)
                {
                    long length = s.Length;
                    buffer = new byte[length];
                    s.Read(buffer, 0, (int)length);
                }
            }

            return buffer;
        }

        public virtual async Task LoadData() {
            await Task.FromResult(0);
        }


        public virtual async Task ProcessQR(string qrValue)
        {
            await PopupNavigation.PushAsync(new DisplayAlertPage(new Common.DisplayAlertViewModel(GetTranslateValue(Data.ApplicationWordsEnum.ToastMessageInformation)
                                                                        , qrValue)));
        }

        protected async Task FinalizateLoaderPage() {
            await PopupNavigation.PopAsync();
        }

        protected async Task CatchLoadingFor(string AMessage, System.Action action, System.Action finalEvent = null) 
        {

            await PopupNavigation.PushAsync(new LoaderPage(new Common.LoaderViewModel() { LabelMessageLoader=AMessage }));
            await Task.Delay(1000);
            try
            {
                action.Invoke();
                
                /*
                 * El codigo debajo en teoria esperaria a que ejecutaria, y terminaria la tarea, pero esto no pasa, asi que no hay nada que hacer...
                 * action.BeginInvoke(async a => 
                {
                    action.EndInvoke(a);
                    
                }, action);*/
            }
            catch
            {

            }
            finally 
            {
                finalEvent?.Invoke();
            }
        }

        protected async Task ShowPopupInformationMessage(string title, string message) 
        {
            await PopupNavigation.PushAsync(new DisplayAlertPage(new Common.DisplayAlertViewModel(title, message)));
        }

        protected async Task BeginOperation(string module) 
        {
            SafetyOperation.OperationId = await OffLineHelper.BeginOperation(module);
        }
    }

    public static class SafetyOperation {
    
        public static int OperationId { get; set; }
    }
}
