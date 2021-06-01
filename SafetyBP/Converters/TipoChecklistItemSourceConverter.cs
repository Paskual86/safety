using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace SafetyBP.Converters
{
    class TipoChecklistItemSourceConverter : IValueConverter
    {
        Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string[] retorno = new string[] { };
            switch (value.ToString())
            {
                case "3": retorno = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" }; break;
                case "4": retorno = new string[] { "ALTA", "MEDIA", "BAJA" }; break;
                case "5": retorno = new string[] { "0", "1", "2", "3" }; break;
                case "6": retorno = new string[] { "VACÍO", "1/4", "MEDIO", "3/4", "LLENO" }; break;
            }
            return retorno;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
