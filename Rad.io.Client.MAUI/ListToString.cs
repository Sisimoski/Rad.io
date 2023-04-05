using System;
using System.Globalization;

namespace Rad.io.Client.MAUI
{
	public class ListToString : IValueConverter
	{
		public ListToString()
		{
		}

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<string>)
            {
                return string.Join(", ", ((List<string>)value).ToArray());
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

