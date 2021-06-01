using System;
using System.Globalization;
using Xamarin.Forms;

namespace SafetyBP.Converters
{
    class EstadoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString() == "1" ? Application.Current.Resources["UNCHECK"] : Application.Current.Resources["CHECK"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
