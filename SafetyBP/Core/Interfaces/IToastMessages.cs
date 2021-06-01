using SafetyBP.Data;

namespace SafetyBP.Core.Interfaces
{
    public interface IToastMessages
    {
        string GetMessage(ToastMessagesEnum type);
    }


}
