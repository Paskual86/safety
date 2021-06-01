using SafetyBP.Domain.Enums;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace SafetyBP.Converters
{
    public class TipoPreguntaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool retorno;

            if (parameter.ToString() == "entry")
                retorno = (CheckListQuestionTypes) value == CheckListQuestionTypes.Type1 ? true : false;
            else
                retorno = (CheckListQuestionTypes) value == CheckListQuestionTypes.Type2 ? true : false;

            return retorno;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
