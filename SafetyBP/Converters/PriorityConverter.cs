using SafetyBP.Domain.Enums;
using SafetyBP.Interfaces;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace SafetyBP.Converters
{
    public class PriorityConverter : IValueConverter
    {
        private readonly ITranslateBusiness _translateBusiness;
        public PriorityConverter()
        {
            _translateBusiness = DependencyService.Get<ITranslateBusiness>();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((byte)value)
            {
                case (byte) TaskPriority.Normal: return _translateBusiness.GetText(Data.ApplicationWordsEnum.LabelPriorityNormal).ToUpper();
                case (byte) TaskPriority.High: return _translateBusiness.GetText(Data.ApplicationWordsEnum.LabelPriorityHigh).ToUpper();
                case (byte) TaskPriority.Critical: return _translateBusiness.GetText(Data.ApplicationWordsEnum.LabelPriorityCritical).ToUpper();
                default:
                    return _translateBusiness.GetText(Data.ApplicationWordsEnum.LabelPriorityUnknown).ToUpper();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
