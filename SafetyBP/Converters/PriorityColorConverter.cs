using SafetyBP.Data.Constants;
using SafetyBP.Domain.Enums;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace SafetyBP.Converters
{
    public class PriorityColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((byte)value)
            {
                case (byte)TaskPriority.Normal: return Application.Current.Resources[ColorResourcesConstants.PRIORITY_NORMAL];
                case (byte)TaskPriority.High: return Application.Current.Resources[ColorResourcesConstants.PRIORITY_HIGH];
                case (byte)TaskPriority.Critical: return Application.Current.Resources[ColorResourcesConstants.PRIORITY_CRITICAL];
                default:
                    return Application.Current.Resources[ColorResourcesConstants.PRIORITY_UNKNOWN];
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
