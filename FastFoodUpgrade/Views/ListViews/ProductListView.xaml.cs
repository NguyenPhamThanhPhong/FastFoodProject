using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels;
using FastFoodUpgrade.Views.InsertForm;
using FastFoodUpgrade.Views.ViewForm;
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

namespace FastFoodUpgrade.Views.ListViews
{
    /// <summary>
    /// Interaction logic for ProductListView.xaml
    /// </summary>
    public partial class ProductListView : UserControl
    {
        public ProductListView()
        {
            InitializeComponent();
            //MessageBox.Show(this.DataContext.ToString());
        }
        public ICommand SelectCommand
        {
            get { return (ICommand)GetValue(SelectCommandProperty);}
            set { SetValue(SelectCommandProperty, value);}
        }
        public static readonly DependencyProperty SelectCommandProperty =
            DependencyProperty.Register("SelectCommand", typeof(ICommand), typeof(ProductListView), new PropertyMetadata(null));
        
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(SelectCommand!=null)
            {
                SelectCommand.Execute(sender);
            }
            
        }

        private DateTime _lastClickTime;
        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((DateTime.Now - _lastClickTime).TotalMilliseconds < 500)
            {
                Grid g = sender as Grid;
                Product p = g.DataContext as Product;
                InsertProductForm f = new InsertProductForm(p);
                f.ShowDialog();
                ProductViewModel pvm = this.DataContext as ProductViewModel;
                pvm.DatabaseChangedTrigger();
            }
            _lastClickTime = DateTime.Now;
        }
    }
}
