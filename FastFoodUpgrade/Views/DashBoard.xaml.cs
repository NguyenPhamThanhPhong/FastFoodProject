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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FastFoodUpgrade.Views
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : UserControl
    {
        public DashBoard()
        {
            InitializeComponent();
            //mylistview.ItemsSource = new List<string> { "Item 1", "Item 2", "Item 3" };
        }

        private void ListViewItem_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //ListViewItem item = sender as ListViewItem;
            //if (item != null)
            //{
            //    int index = mylistview.Items.IndexOf(item.DataContext);
            //    // do something with the index...
            //}
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Grid grid)
            {
                grid.BeginStoryboard((Storyboard)FindResource("scaleUp"));
            }
        }
        


        private void ListViewItem_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Grid grid)
            {
                grid.BeginStoryboard((Storyboard)FindResource("scaleDown"));
            }
        }
    }
}
