using SafetyBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SafetyBP.ViewModels
{
    public class TaskBoardViewModel : BaseViewModel
    {
        public ObservableCollection<SafetyTask> Tasks { get; set; }
        public Command LoadViewCommand { get; set; }

        public TaskBoardViewModel():base(Data.ApplicationWordsEnum.PageTitleSector)
        {
            Tasks = new ObservableCollection<SafetyTask>();
            LoadViewCommand = new Command(async () => await LoadViewMethod());
        }

        private async Task LoadViewMethod()
        {
            try
            {
                if (await TasksBusiness.GetCountAsync() > 0)
                {
                    IEnumerable<SafetyTask> tasks = await TasksBusiness.GetListAsync();
                    Tasks.Clear();
                    if (tasks.Count() != 0) tasks.ForEach(t =>
                    {
                        if (t.Details.Any(td => !td.IsComplete)) Tasks.Add(t);
                    });
                    OnPropertyChanged(nameof(Tasks));
                }
                else
                {
                    if (IsConnected())
                    {
                        var token = await TokenBusiness.GetTokenAsync();
                    }
                }
            }
            catch (Exception ex) {
                // TODO: Replace by App Center Crashes Logger.Debug(ex.ToString());
            }
        }
    }
}
