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

namespace FastFoodUpgrade.Views
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : Page
    {
        public Product()
        {
            InitializeComponent();
            mylistview.ItemsSource = new List<string> { "akl", "akl", "akl", "akl", "akl", "akl", "akl", "akl", "akl", "akl", "akl" };
        }
        string SelectedStringItem = "";
        Tuple<int, Grid> DraggedObject = null;
        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if(!(sender is ListView))
                {
                    return;
                }
                var listView = sender as ListView;
                var item = FindAncestor<Grid>((DependencyObject)e.OriginalSource);

                if (item != null)
                {
                    var index = listView.Items.IndexOf(item.DataContext);
                    SelectedStringItem = (string)item.DataContext;
                    DraggedObject = new Tuple<int, Grid>(index, item);
                    DragDrop.DoDragDrop(listView, new Tuple<int, Grid>(index, item), DragDropEffects.Move);
                }
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            while (current != null && !(current is T))
            {
                current = VisualTreeHelper.GetParent(current);
            }
        
            return current as T;
        }
    }
}
