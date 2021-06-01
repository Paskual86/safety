using SafetyBP.Domain.OperationsResult;
using System.Threading.Tasks;

namespace SafetyBP.Domain.Interfaces.Helpers
{
    public interface ICallApiHelper
    {
        Task<BooleanOperationResult> SendRequest(string request, string url);
    }
}
