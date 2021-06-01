using SafetyBP.Domain.Entities;
using SafetyBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SafetyBP.ViewModels
{
    public class TaskBoardMoreInformationViewModel : BaseViewModel
    {
        public ObservableCollection<FileModel> Files { get; set; }
        public string Comments{ get; set; }
        public string Url { get; set; }
        public bool ShowUrl { get; set; }

        public string LabelFile { get; set; }
        public int HeightRequestScrollView { get; set; }
        public int HeightRequestListView { get; set; }

        public ICommand ClickCommand { get; set; }
        

        public TaskBoardMoreInformationViewModel(SafetyTaskDetails safetyTask):base()
        {
            if (safetyTask != null)
            {
                var lst = safetyTask.Files.Split(';');
                Files = new ObservableCollection<FileModel>(GetListFiles(lst.ToList()));
                Comments = safetyTask.Comments;
                Url = safetyTask.Url;

                if (Files.Count > 0)
                {
                    HeightRequestScrollView = HeightRequestListView = 150;
                }
                else
                {
                    HeightRequestScrollView = HeightRequestListView = 5;
                }

                ShowUrl = Url.Trim().Length != 0;
                if (Comments.Trim().Length == 0) Comments = GetTranslateValue(Data.ApplicationWordsEnum.CommentIsEmtpy);

                OnPropertyChanged(nameof(HeightRequestScrollView));
                OnPropertyChanged(nameof(HeightRequestListView));

                
            }
            else
            {
                Files = new ObservableCollection<FileModel>();
                ShowUrl = false;
                Url = Comments = string.Empty;
            }

            LabelFile = GetTranslateValue(Data.ApplicationWordsEnum.LabelFile);
            ClickCommand = new Command<string>(async (url) =>
            {
                string url_aux = url;
                if (!url_aux.Trim().Contains("http://")&&(!url_aux.Trim().Contains("https://"))) url_aux = "http://" + url_aux;
                try
                {
                    await Launcher.OpenAsync(new System.Uri(url_aux));
                }
                catch (Exception ex) {
                    await ShowPopupInformationMessage(GetTranslateValue(Data.ApplicationWordsEnum.ToastMessageInformation), ex.Message);
                
                }
            });
        }

        private List<FileModel> GetListFiles(List<string> files) {

            var result = new List<FileModel>();

            int fileIndex = 1;
            foreach (var file in files)
            {
                if (file.Trim().Length != 0)
                {
                    result.Add(new FileModel()
                    {
                        FilePath = file,
                        Index = fileIndex++
                    });
                }
            }

            return result;
        }
    }
}
