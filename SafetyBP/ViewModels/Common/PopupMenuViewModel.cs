using SafetyBP.Domain.Entities;
using SafetyBP.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SafetyBP.ViewModels.Common
{
    public class PopupMenuViewModel : BaseViewModel
    {
        public bool ShowNAButton { get; set; }
        public bool ShowCheckButton { get; set; }
        public bool ShowCommentButton { get; set; }
        public bool ShowCameraButton { get; set; }

        private string _iconNaButton;

        public string IconNaButton
        {
            get { return _iconNaButton; }
            set
            {
                _iconNaButton = value;
                OnPropertyChanged();
            }
        }

        public PopupMenuViewModel():base()
        {
            IconNaButton = "navalue.png";
        }

        protected async Task CatchCameraFor(System.Action<SafetyCameraResponse> success, System.Action error) 
        {
            var photo = await DependencyService.Get<ISafetyCamera>().GetPhotoAsync();
            if ((photo.CameraNotAvailable) || (photo.Content.Length == 0))
            {
                error?.Invoke();
                return;
            }
            else {
                success(photo);
            }
        }
    }
}
