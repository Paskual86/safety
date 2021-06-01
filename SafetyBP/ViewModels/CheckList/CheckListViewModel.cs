using SafetyBP.Domain.Models;
using SafetyBP.Views.Modules.CheckLists;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SafetyBP.ViewModels.CheckList
{
    public class CheckListViewModel : BaseViewModel
    {
        public ObservableCollection<SafetyCheckList> CheckLists { get; set; }

        public CheckListViewModel():base(Data.ApplicationWordsEnum.PageTitleChecklist)
        {
            OnNextCommand = new Command<object>(async parameter =>
            {
                await NextCommand(parameter);
            });
        }

        public override async Task LoadData()
        {
            try
            {
                if (await ModuleCheckListsBusiness.GetCountAsync() > 0)
                {
                    IEnumerable<SafetyCheckList> checkLists = (await ModuleCheckListsBusiness.GetListAsync()).Where(wh => wh.Details.Any(an => !an.Complete)).ToList();
                    Sectors = new ObservableCollection<Domain.Interfaces.IBaseEntity>(checkLists);
                    CheckLists = new ObservableCollection<SafetyCheckList>(checkLists);
                    
                    OnPropertyChanged(nameof(CheckLists));
                    OnPropertyChanged(nameof(Sectors));
                }
                else
                {
                    if (IsConnected())
                    {
                        var token = await TokenBusiness.GetTokenAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // // TODO: Replace by App Center Crashes Logger.Debug(ex.ToString());
            }
        }

        private async Task NextCommand(object parameter) 
        {
            await Navigation.PushAsync(new CheckListDetailPage(new CheckListDetailViewModel(((SafetyCheckList)parameter).Details.ToList())));
        }
    }
}
