using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace YuiHelpers.Converters
{
    public class ConverterObject2Visibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = Visibility.Collapsed;
            if (value != null)
            {
                Type t = value.GetType();
                switch (t.Name)
                {
                    case "Boolean":
                        visibility = Boolean2Visibility(value, visibility);
                        break;
                    case "String":
                        visibility = String2Visibility(value, visibility);
                        break;
                    default:
                        visibility = Visibility.Collapsed;
                        break;
                }
            }
            return visibility;
        }

        private static Visibility String2Visibility(object value, Visibility visibility)
        {
            if (string.IsNullOrEmpty((string)value))
            {
                visibility = Visibility.Visible;
            }
            else if (!string.IsNullOrEmpty((string)value))
            {
                visibility = Visibility.Collapsed;
            }
            return visibility;
        }

        private static Visibility Boolean2Visibility(object value, Visibility visibility)
        {
            if ((bool)value)
            {
                visibility = Visibility.Visible;
            }
            else if (!(bool)value)
            {
                visibility = Visibility.Collapsed;
            }
            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
