using SafetyBP.Domain.Models;
using SafetyBP.Domain.Models.Modules.ControlObjects;
using System.Collections.Generic;

namespace SafetyBP.Domain.Helpers
{
    public static class SafetyHelper
    {
        public static List<SafetyCheckListNegativeValue> ConvertIntToNegativeValues(IList<int> values)
        {
            var result = new List<SafetyCheckListNegativeValue>();
            foreach (var value in values)
            {
                result.Add(new SafetyCheckListNegativeValue()
                {
                    Value = value.ToString(),
                    ValueType = 1
                });
            }

            return result;
        }

        public static List<ControlObjectsCheckListNegativeValue> ConvertIntToControlObjectsNegativeValues(IList<int> values)
        {
            var result = new List<ControlObjectsCheckListNegativeValue>();
            foreach (var value in values)
            {
                result.Add(new ControlObjectsCheckListNegativeValue()
                {
                    Value = value.ToString(),
                    ValueType = 1
                });
            }

            return result;
        }
    }
}
