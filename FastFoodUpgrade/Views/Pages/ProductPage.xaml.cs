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
using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels;
using FastFoodUpgrade.Views.InsertForm;
using FastFoodUpgrade.Windows;

namespace FastFoodUpgrade.Views.Pages
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class ProductPage : System.Windows.Controls.Page
    {
        private Staff s;
        public ProductPage()
        {
            InitializeComponent();
            this.DataContext = new ProductViewModel();
            RightSplitTable.DataContext = (this.DataContext as ProductViewModel).SplitTableDataContext;
            DashBoardWindow main = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive) as DashBoardWindow;
            DashBoardViewModel vm = main.DataContext as DashBoardViewModel;
            Staff loggedinS = vm.CurrentStaff;
            s = loggedinS;
            if (s.AccessRight == "Staff") {
                buttonProduct.Visibility = Visibility.Hidden;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InsertProductForm f = new InsertProductForm();
            f.ShowDialog();
            ProductViewModel pvm = this.DataContext as ProductViewModel;
            pvm.DatabaseChangedTrigger();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DashBoardWindow main = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive) as DashBoardWindow;
            DashBoardViewModel vm = main.DataContext as DashBoardViewModel;
            InsertBillForm f = new InsertBillForm(vm.CurrentStaff);
            f.Owner = main;
            f.Show();
        }
    }
}
