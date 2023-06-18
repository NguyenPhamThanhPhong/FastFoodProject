using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FastFoodUpgrade.Converters
{
    public class StaffAvatarToImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value as string;
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            string solutionPath = Path.GetFullPath(Path.Combine(assemblyPath, @"..\..\..\"));
            if (String.IsNullOrEmpty(str) || File.Exists(Path.Combine(solutionPath, "IMAGE_STAFF", str)))
            {
                return new BitmapImage(new Uri(@"/IMAGE/NoImage.png", UriKind.Relative));
            }
            else 
            {
                return new BitmapImage(new Uri(@"/IMAGE/"+str, UriKind.Relative));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
