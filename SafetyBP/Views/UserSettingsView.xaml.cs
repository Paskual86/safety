using SafetyBP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserSettings : ToolbarPage
    {
        private readonly UserSettingViewModel _userSettingViewModel;
        private bool _changingLanguage;
        public UserSettings()
        {
            InitializeComponent();
            _userSettingViewModel = new UserSettingViewModel();
            BindingContext = _userSettingViewModel;
            _changingLanguage = false;
        }

        protected override void OnAppearing()
        {
            Application.Current.Resources["NavigationPrimary"] = Application.Current.Resources["AzulFrancia"];
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Picker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
        }

        private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (!_changingLanguage)
            {
                if (!_userSettingViewModel.ChangingLanguage)
                {
                    var pos = ((Picker)sender).SelectedIndex;
                    if (pos > -1) {
                        _changingLanguage = true;
                        _userSettingViewModel.ChangeLanguage();
                    }
                }
                _changingLanguage = false;
            }
        }

        private async void btnSave_Clicked(object sender, System.EventArgs e)
        {
            await DisplayAlert(_userSettingViewModel.DisplayAlertTitle, _userSettingViewModel.DisplayAlertMessage, _userSettingViewModel.DisplayAlertButtonOk);
            await Navigation.PopToRootAsync();
        }
    }
}