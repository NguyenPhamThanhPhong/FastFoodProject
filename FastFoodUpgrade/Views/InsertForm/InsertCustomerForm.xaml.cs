using FastFoodUpgrade.Models;
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
using System.Windows.Shapes;
using FastFoodUpgrade.ViewModels.InsertFormViewModels;
namespace FastFoodUpgrade.Views.InsertForm
{
    /// <summary>
    /// Interaction logic for InsertCustomerForm.xaml
    /// </summary>
    public partial class InsertCustomerForm : Window
    {
        public InsertCustomerForm()
        {
            InitializeComponent();
            
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private  void Button_Click_1(object sender, RoutedEventArgs e)
        {
            InsertCustomerViewModel vm = this.DataContext as InsertCustomerViewModel;
            if (vm.InsertCustomer != null)
            {
                vm.InsertCustomer.Execute(this);
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = await InsertCustomerViewModel.Initialize();
        }
    }
}
