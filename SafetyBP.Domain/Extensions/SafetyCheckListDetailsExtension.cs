using SafetyBP.Domain.Models;
using System.Linq;

namespace SafetyBP.Domain.Extensions
{
    public static class SafetyCheckListDetailsExtension
    {
        public static void UpdateValues(this SafetyCheckListDetail currentValue, SafetyCheckListDetail newValue)
        {
            currentValue.Name = newValue.Name;
            currentValue.DueDateTime = newValue.DueDateTime;

            if (newValue.Questions.Count > 0)
            {
                foreach (var question in newValue.Questions)
                {
                    var aux = currentValue.Questions.FirstOrDefault(fo => fo.Id == question.Id);
                    if (aux != null) aux.UpdateValues(question);
                    else currentValue.Questions.Add(aux);
                }
            }
            else
            {
                currentValue.Questions.Clear();
            }
        }
    }
}
