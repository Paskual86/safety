using SafetyBP.Domain.Interfaces;
using SafetyBP.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SafetyBP.ViewModels
{
    public interface IBaseViewModel
    {
        bool IsEnabled { get; set; }
        string LabelButtonBack { get; set; }
        string LabelButtonSave { get; set; }
        string LabelDueDatetime { get; set; }
        string LabelStartDatetime { get; set; }
        string Title { get; set; }
        string WhiteSpace { get; set; }
        ICommand OnCloseCommand { get; set; }
        ICommand OnMenuCommand { get; set; } // Call the menu of 3 points
        ICommand OnNextCommand { get; set; }
        ICommand OnCommentsCommand { get; set; }
        ICommand OnCameraCommand { get; set; }
        
        IWebService WebService { get; }
        INavigation Navigation { get; set; }

        ObservableCollection<IBaseEntity> Sectors { get; set; }
        event PropertyChangedEventHandler PropertyChanged;
        Task LoadData();
        
    }
}