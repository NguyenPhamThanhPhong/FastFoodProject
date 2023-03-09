using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastFoodUpgrade.Views
{
    public static class ThicknessExtensions
    {
        public static readonly DependencyProperty BottomProperty =
            DependencyProperty.RegisterAttached(
                "Bottom",
                typeof(double),
                typeof(ThicknessExtensions),
                new FrameworkPropertyMetadata(
                    0.0,
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.AffectsParentArrange |
                    FrameworkPropertyMetadataOptions.AffectsParentMeasure),
                value => (double)value >= 0);

        public static double GetBottom(DependencyObject obj)
        {
            return (double)obj.GetValue(BottomProperty);
        }

        public static void SetBottom(DependencyObject obj, double value)
        {
            obj.SetValue(BottomProperty, value);
        }
    }

}
