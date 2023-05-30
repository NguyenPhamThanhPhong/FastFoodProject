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
            this.DataContext = new ManagingViewModel();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            InsertStaffForm f = new InsertStaffForm();
            f.ShowDialog();
            DataProvider<Staff> db = new DataProvider<Staff>(Staff.Collection);
            List<Staff> results = await db.ReadAllAsync();
            (this.DataContext as ManagingViewModel).UpdateListStaff(results);
        }
    }
}
