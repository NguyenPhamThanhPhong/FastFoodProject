using FastFoodUpgrade.ViewModels;
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
using FastFoodUpgrade.Views.InsertForm;
using FastFoodUpgrade.Models;
using FastFoodUpgrade.Views.ViewForm;

namespace FastFoodUpgrade.Views.Pages
{
    /// <summary>
    /// Interaction logic for ManagingPage.xaml
    /// </summary>
    public partial class ManagingPage : Page
    {
        public ManagingPage()
        {
            InitializeComponent();
            ComboboxFilter.ItemsSource = new List<string>() {"Staff","Admin" };
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            InsertStaffForm f = new InsertStaffForm();
            f.ShowDialog();
            DataProvider<Staff> db = new DataProvider<Staff>(Staff.Collection);
            List<Staff> results = await db.ReadAllAsync();
            (this.DataContext as ManagingViewModel).UpdateListStaff(results);
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = await ManagingViewModel.Initialize();
        }
        private DateTime _lastClickTime;

        private async void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((DateTime.Now - _lastClickTime).TotalMilliseconds < 500)
            {
                Grid g = sender as Grid;
                Staff selectedStaff = g.DataContext as Staff;
                if (selectedStaff != null)
                {
                    InsertStaffForm f = new InsertStaffForm(selectedStaff);
                    f.ShowDialog();
                    DataProvider<Staff> db = new DataProvider<Staff>(Staff.Collection);
                    List<Staff> results = await db.ReadAllAsync();
                    (this.DataContext as ManagingViewModel).UpdateListStaff(results);
                }
            }
            _lastClickTime = DateTime.Now;
        }
    }
}
