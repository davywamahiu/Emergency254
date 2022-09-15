using System;
using System.Globalization;
using System.Net;
using Emergency254.Utils;
using Xamarin.Forms;

namespace Emergency254.Converters
{
    public class HtmlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string text = (string)value;
                return HtmlTools.Strip(WebUtility.HtmlDecode(text));
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string text = (string)value;
                return WebUtility.HtmlEncode(text);
            }

            return "";
        }
    }
}
