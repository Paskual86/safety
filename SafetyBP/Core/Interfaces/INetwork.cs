namespace SafetyBP.Core.Interfaces
{
    public interface INetwork
    {
        bool IsConnected();
        bool IsConnectedFast();
    }
}
