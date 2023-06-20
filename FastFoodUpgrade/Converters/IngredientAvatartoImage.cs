using FastFoodUpgrade.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace FastFoodUpgrade.Converters
{
    public class IngredientAvatartoImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string filename = value as string;
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.CacheOption = BitmapCacheOption.OnLoad;
            bmp.UriSource = new Uri(Path.Combine(ImageStorage.CurrentSolutionLocation, "IMAGE", "Burger.png"), UriKind.Absolute);
            bmp.EndInit();
            if (!String.IsNullOrEmpty(filename))
            {
                if (File.Exists(Path.Combine(ImageStorage.IngredientImageLocation, filename)) == false)
                    return bmp;
                BitmapImage bmp1 = new BitmapImage();
                bmp1.BeginInit();
                bmp1.CacheOption = BitmapCacheOption.OnLoad;
                bmp1.UriSource = new Uri(Path.Combine(ImageStorage.IngredientImageLocation, filename), UriKind.Absolute);
                bmp1.EndInit();
                return bmp1;
            }
            return bmp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
