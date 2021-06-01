using SafetyBP.Domain.Enums;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace SafetyBP.Converters
{
    public class CheckListStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (byte.TryParse(value.ToString(), out byte result))
            {

                switch (result)
                {
                    case (int)TaskCheckListStatus.Uncheck:
                        {
                            return Application.Current.Resources["UNCHECK"];
                        }
                    case (int)TaskCheckListStatus.Check:
                        {
                            return Application.Current.Resources["CHECK"];
                        }
                    case (int)TaskCheckListStatus.NA:
                        {
                            return Application.Current.Resources["NAVALUE"];
                        }
                    default:
                        return Application.Current.Resources["UNCHECK"];
                }
            }
            else {
                return Application.Current.Resources["UNCHECK"];
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
            //throw new NotImplementedException();
        }
    }
}
