using SafetyBP.Core.Interfaces;
using SafetyBP.Droid;
using System.Linq;
using Xamarin.Essentials;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkHelper))]
namespace SafetyBP.Droid
{
    public class NetworkHelper : INetwork
    {
        public bool IsConnected()
        {
            var current = Connectivity.NetworkAccess;

            if ((current == NetworkAccess.None) || (current == NetworkAccess.Unknown))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsConnectedFast()
        {
            var profiles = Connectivity.ConnectionProfiles;
            if ((IsConnected()) && profiles.Contains(ConnectionProfile.WiFi))
            {
                return true;
            }
            return false;
        }
    }
}