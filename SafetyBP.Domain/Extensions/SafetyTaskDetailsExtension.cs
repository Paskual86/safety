using SafetyBP.Domain.Models;
using System.Linq;

namespace SafetyBP.Domain.Extensions
{
    public static class SafetyTaskDetailsExtension
    {
        public static void UpdateValues(this SafetyTaskDetails currentValue, SafetyTaskDetails newValue)
        {
            currentValue.Name = newValue.Name;
            currentValue.Priority = newValue.Priority;
            currentValue.Comments = newValue.Comments;
            currentValue.StartDateTime = newValue.StartDateTime;
            currentValue.EndDateTime = newValue.EndDateTime;
            currentValue.IsComplete = newValue.IsComplete;

            if (newValue.CheckList.Count > 0)
            {
                foreach (var checkList in newValue.CheckList)
                {
                    var curCheck = currentValue.CheckList.FirstOrDefault(fo => fo.Id == checkList.Id);
                    if (curCheck != null) curCheck.UpdateValues(checkList);
                    else currentValue.CheckList.Add(curCheck);
                }
            }
            else
            {
                currentValue.CheckList.Clear();
            }
        }
    }
}
