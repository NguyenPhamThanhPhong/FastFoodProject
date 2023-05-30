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

namespace FastFoodUpgrade.Views.Pages
{
    /// <summary>
    /// Interaction logic for BillPage.xaml
    /// </summary>
    public partial class BillPage : Page
    {
        public BillPage()
        {
            InitializeComponent();
            ComboboxFilter.ItemsSource = new List<string>() { "ID", "Customer Name", "Staff Name" };
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = await BillViewModel.Initialize();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
