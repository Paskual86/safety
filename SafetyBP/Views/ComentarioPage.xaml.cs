using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SafetyBP.ViewModels;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafetyBP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComentarioPage : PopupPage
    {
        readonly ICommand CerrarPopup;
        readonly ComentarioViewModel viewModel;
        
        public ComentarioPage(ComentarioViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;

            string backupComentario = viewModel.SafetyTaskCheck != null ? viewModel.SafetyTaskCheck.Comments : string.Empty;

            this.viewModel.BackupComentario = backupComentario;

            this.viewModel.Text = backupComentario;
                        
            CerrarPopup = new Command(async () =>
            {
                await PopupNavigation.Instance.PopAsync();
            });
            viewModel.CerrarPopup = this.CerrarPopup;
        }

        #region -- MÉTODOS DEL PLUGIN
        protected override void OnAppearing()
        {
            base.OnAppearing();
            editorComentario.Focus();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        // ### Methods for supporting animations in your popup page ###

        // Invoked before an animation appearing
        protected override void OnAppearingAnimationBegin()
        {
            base.OnAppearingAnimationBegin();
        }

        // Invoked after an animation appearing
        protected override void OnAppearingAnimationEnd()
        {
            base.OnAppearingAnimationEnd();
        }

        // Invoked before an animation disappearing
        protected override void OnDisappearingAnimationBegin()
        {
            base.OnDisappearingAnimationBegin();
        }

        // Invoked after an animation disappearing
        protected override void OnDisappearingAnimationEnd()
        {
            base.OnDisappearingAnimationEnd();
        }

        protected override Task OnAppearingAnimationBeginAsync()
        {
            return base.OnAppearingAnimationBeginAsync();
        }

        protected override Task OnAppearingAnimationEndAsync()
        {
            return base.OnAppearingAnimationEndAsync();
        }

        protected override Task OnDisappearingAnimationBeginAsync()
        {
            return base.OnDisappearingAnimationBeginAsync();
        }

        protected override Task OnDisappearingAnimationEndAsync()
        {
            return base.OnDisappearingAnimationEndAsync();
        }

        // ### Overrided methods which can prevent closing a popup page ###

        // Invoked when a hardware back button is pressed
        protected override bool OnBackButtonPressed()
        {
            // Return true if you don't want to close this popup page when a back button is pressed
            return false;
        }

        // Invoked when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return false if you don't want to close this popup page when a background of the popup page is clicked
            return false;
        }
        #endregion
    }
}