using System;
using System.Windows.Data;

namespace WpfSample01.Samples.K
{
    public class FilterStringConverter : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              System.Globalization.CultureInfo culture)
        {
            if (value == null) return Binding.DoNothing;
            return String.Format("[{0}] = '{1}'", parameter, value);
        }

        public object ConvertBack(object value,
                                  Type targetType,
                                  object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}