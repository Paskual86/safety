using SafetyBP.Domain.Entities;

namespace SafetyBP.Interfaces
{
    public interface ISafetyCamera
    {
        System.Threading.Tasks.Task<SafetyCameraResponse> GetPhotoAsync();
    }
}
