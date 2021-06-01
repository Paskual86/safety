using SafetyBP.Domain.Models;

namespace SafetyBP.Domain.Extensions
{
    public static class SafetyTaskCheckListExtension
    {
        public static void UpdateValues(this SafetyTaskCheckList currentValue, SafetyTaskCheckList newValue)
        {
            currentValue.Name = newValue.Name;
            currentValue.Status = newValue.Status;
            currentValue.Comments = newValue.Comments;
            currentValue.Photo = newValue.Photo;
        }
    }
}
