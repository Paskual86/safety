namespace SafetyBP.ViewModels.Common
{
    public class DisplayAlertViewModel : BaseViewModel
    {
        public string Message { get; set; }
        public DisplayAlertViewModel(string ATitle, string AMessage):base()
        {
            Title = ATitle;
            Message = AMessage;
        }
    }
}
