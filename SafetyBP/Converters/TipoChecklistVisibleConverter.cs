using System;
using System.Globalization;
using Xamarin.Forms;

namespace SafetyBP.Converters
{
    public class TipoChecklistVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool retorno;
            switch (parameter.ToString())
            {
                case "button": retorno = value.ToString() == "1" || value.ToString() == "2" || value.ToString() == "7" ? true : false; break;
                case "picker": retorno = value.ToString() == "3" || value.ToString() == "4" || value.ToString() == "5" || value.ToString() == "6" ? true : false; break;
                default: retorno = false; break;
            }
            return retorno;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
