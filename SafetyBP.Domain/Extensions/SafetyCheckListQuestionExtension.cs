using SafetyBP.Domain.Models;

namespace SafetyBP.Domain.Extensions
{
    public static class SafetyCheckListQuestionExtension
    {
        public static void UpdateValues(this SafetyCheckListQuestion currentValue, SafetyCheckListQuestion newValue)
        {
            currentValue.Name = newValue.Name;
            currentValue.RelatedId = newValue.RelatedId;
            currentValue.Type = newValue.Type;
            currentValue.IsAlert = newValue.IsAlert;
            currentValue.PhotoRequired = newValue.PhotoRequired;

            currentValue.IsCritica = newValue.IsCritica;
            currentValue.Value = newValue.Value;
            currentValue.PhotoRequired = newValue.PhotoRequired;
            currentValue.NegativeValues.Clear();
            foreach (var nv in newValue.NegativeValues)
            {
                currentValue.NegativeValues.Add(nv);
            }
        }
    }
}
