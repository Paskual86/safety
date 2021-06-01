using SafetyBP.Domain.Enums;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace SafetyBP.Converters
{
    public class QuestionaryTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int.TryParse(parameter.ToString(), out int intParameter);
            var parameterConverted = (CheckListQuestionTypeGroup)(intParameter);
            return (int) value == (int) parameterConverted;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
