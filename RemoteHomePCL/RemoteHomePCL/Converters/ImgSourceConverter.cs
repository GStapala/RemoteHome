using System;
using System.Globalization;
using Xamarin.Forms;

namespace RemoteHomePCL.Converters
{
    public class ImgSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var source = value as string;
            if (source == null || string.IsNullOrWhiteSpace(source))
                return null;

            return ImageSource.FromResource(source);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}