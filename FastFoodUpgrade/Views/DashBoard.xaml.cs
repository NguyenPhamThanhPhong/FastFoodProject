using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
        }
    }
}
