using System;
using System.Globalization;
using Xamarin.Forms;

namespace TrashBox.Converters
{
    public class MultiplicationByNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var multiplier = GetParameter(parameter);

            return value switch
            {
                double doubleValue => (doubleValue * multiplier),
                float floatValue => (floatValue * multiplier),
                int intValue => (intValue * multiplier),
                long longValue => (longValue * multiplier),
                short shortValue => (shortValue * multiplier),
                _ => null
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static double GetParameter(object parameter) =>
            parameter switch
            {
                double doubleParameter => doubleParameter,
                int intParameter => intParameter,
                string stringParameter => double.Parse(stringParameter),
                _ => 1
            };
    }
}