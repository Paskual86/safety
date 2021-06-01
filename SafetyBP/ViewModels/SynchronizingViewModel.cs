namespace SafetyBP.ViewModels
{
    public class SynchronizingViewModel : BaseViewModel
    {
        public string LabelSynchronizing { get; set; }
        public SynchronizingViewModel()
        {
            LabelSynchronizing = GetTranslateValue(Data.ApplicationWordsEnum.LabelSynchronizing);
        }
    }
}
