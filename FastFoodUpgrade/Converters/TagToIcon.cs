using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FontAwesome.WPF;

namespace FastFoodUpgrade.Converters
{
    public class TagToIcon : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string IconName)
            {
                FontAwesomeIcon Icon;
                if(Enum.TryParse(IconName,out Icon))
                {
                    return Icon;
                }
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
