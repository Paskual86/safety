using System.Threading.Tasks;

namespace SafetyBP.Services
{
    public interface IQrScanningService
    {
        Task<string> ScanAsync();
    }
}
