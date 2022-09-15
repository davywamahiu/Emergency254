using System;
using Xamarin.Forms;
using System.Globalization;

namespace Emergency254.Converters
{
    public class BooleanInverter : IValueConverter
    {
        #region IValueConverter implementation
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !(bool)value;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => !(bool)value;
        #endregion

    }
}

