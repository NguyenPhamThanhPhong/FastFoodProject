using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FastFoodUpgrade.Views.SplitTaskTable
{
    /// <summary>
    /// Interaction logic for ProductPageSplit.xaml
    /// </summary>
    public partial class ProductPageSplit : UserControl
    {
        public ProductPageSplit()
        {
            InitializeComponent();
        }
        private bool isDragging = false;
        private double originalTop = 0;
        private void DrawerButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //isDragging = true;

            //Thickness tn = Drawer.Margin;
            //originalTop = tn.Top;
            //DrawerButton.CaptureMouse();
        }

        private async void DrawerButton_MouseMove(object sender, MouseEventArgs e)
        {
            //if (isDragging)
            //{
            //    Point position = e.GetPosition(this);
            //    //double yy = position.Y;
            //    double top = position.Y;
            //    if (top < 0)
            //    {
            //        top = 0;
            //    }
            //    else if (top > 500)
            //    {
            //        top = 500;
            //    }
            //    Drawer.Margin = new Thickness(0, top, 0, 0);
            //}
        }

        private void DrawerButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //isDragging = false;
            //DrawerButton.ReleaseMouseCapture();
        }
    }
}
