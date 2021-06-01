using System.Collections.Generic;

namespace SafetyBP.Domain.Helpers
{
    public class StringHelper
    {
        public static string ConcatenateString(ICollection<string> value)
        {
            if (value != null)
            {
                var result = string.Empty;
                foreach (var item in value)
                {
                    result += item + ";";
                }
                return result;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
