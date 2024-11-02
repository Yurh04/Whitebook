using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace WhiteBook
{
    public class IntToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // 检查是否为整数并且值为1
            if (value is int && (int)value == 1)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); // 不需要实现反向转换
        }
    }
}