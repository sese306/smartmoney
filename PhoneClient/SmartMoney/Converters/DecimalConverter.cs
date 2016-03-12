using System;
using Windows.UI.Xaml.Data;

namespace SmartMoney.Converters
{
    public class DecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var decimalValue = (decimal) value;

            return decimalValue.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var stringValue = (string) value;
            decimal decimalValue;
            decimal.TryParse(stringValue, out decimalValue);

            return decimalValue;
        }
    }
}