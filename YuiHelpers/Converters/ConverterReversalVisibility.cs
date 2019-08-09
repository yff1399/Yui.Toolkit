using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace YuiHelpers.Converters
{
    public class ConverterReversalVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = (Visibility)value;
            if (visibility == Visibility.Collapsed || visibility == Visibility.Hidden)
                return Visibility.Visible;
            else if (visibility == Visibility.Visible)
                return Visibility.Collapsed;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
