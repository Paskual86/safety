using SafetyBP.Interfaces;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace SafetyBP.Converters
{
    public class TipoChecklistTextConverter : IValueConverter
    {
        private readonly ITranslateBusiness _translateBusiness;
        public TipoChecklistTextConverter()
        {
            _translateBusiness = DependencyService.Get<ITranslateBusiness>();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string retorno = string.Empty;
            if (parameter.ToString() == "btnTxtSI")
            {
                switch (value.ToString())
                {
                    case "1": retorno = _translateBusiness.GetText(Data.ApplicationWordsEnum.LabelButtonYes).ToUpper(); break;
                    case "2": retorno = _translateBusiness.GetText(Data.ApplicationWordsEnum.LabelButtonComply).ToUpper(); break;
                    case "7": retorno = _translateBusiness.GetText(Data.ApplicationWordsEnum.LabelButtonOk).ToUpper(); break;
                }
            }
            else
            {
                switch (value.ToString())
                {
                    case "1": retorno = _translateBusiness.GetText(Data.ApplicationWordsEnum.LabelButtonNo).ToUpper(); break;
                    case "2": retorno = _translateBusiness.GetText(Data.ApplicationWordsEnum.LabelButtonNoComply).ToUpper(); break;
                    case "7": retorno = _translateBusiness.GetText(Data.ApplicationWordsEnum.LabelButtonNoOk).ToUpper(); break;
                }
            }
            return retorno;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
