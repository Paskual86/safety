using System;
using System.Globalization;

namespace SafetyBP.Domain.Helpers
{
    public static class DatetimeHelper
    {
        private static string[] formats = {"M/d/yyyy h:mm:ss tt",
                                    "M/d/yyyy h:mm tt",
                                        "MM/dd/yyyy hh:mm:ss",
                                "M/d/yyyy h:mm:ss",
                                "M/d/yyyy hh:mm tt",
                                "M/d/yyyy hh tt",
                                "M/d/yyyy h:mm",
                                "M/d/yyyy h:mm",
                                "MM/dd/yyyy hh:mm",
                                "M/dd/yyyy hh:mm",
                                "dd-MM-yy",
            "yyyy-MM-dd",
            "dd-MM-yyyy"};

        public static DateTime ConvertFromString(string value)
        {
            if (DateTime.TryParseExact(value, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
            {
                return dateTime;
            }
            else
            {
                return DateTime.Now;
            }
        }
        public static DateTime? ConvertDatetimeFromString(string value)
        {
            if (DateTime.TryParseExact(value, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
            {
                return dateTime;
            }
            else
            {
                return null;
            }
        }
    }
}
