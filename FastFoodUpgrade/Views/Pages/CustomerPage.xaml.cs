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
using FastFoodUpgrade.ViewModels;
using FastFoodUpgrade.Views.InsertForm;
using FastFoodUpgrade.ViewModels.RightSplitTask;
using FastFoodUpgrade.Models;
using FastFoodUpgrade.Views.ViewForm;

namespace FastFoodUpgrade.Views.Pages
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class CustomerPage : System.Windows.Controls.Page
    {
        public CustomerPage()
        {
            InitializeComponent();
            ComboboxFilter.ItemsSource= new List<string>() {"ID", "Name", "Phone" };
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            InsertCustomerForm f = new InsertCustomerForm();
            f.ShowDialog();
            if(this.DataContext !=null)
            {
                CustomerViewModel ViewModel = this.DataContext as CustomerViewModel;
                DataProvider<Customer> db = new DataProvider<Customer>(Customer.Collection);
                ViewModel.UpdateCustomerList(await db.ReadAllAsync());
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = await CustomerViewModel.Initialize();
            //AdvancedSearchGrid.DataContext = new CustomerAdvancedSearch(this.DataContext as CustomerViewModel);
        }
        private DateTime _lastClickTime;

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((DateTime.Now - _lastClickTime).TotalMilliseconds < 500)
            {
                Grid g = sender as Grid;
                Customer c = g.DataContext as Customer;
                ViewCustomerForm f = new ViewCustomerForm(c);
                f.ShowDialog();
            }
            _lastClickTime = DateTime.Now;


        }
    }
}
