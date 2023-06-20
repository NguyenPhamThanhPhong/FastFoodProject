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
    /// Interaction logic for InsertProductForm.xaml
    /// </summary>
    public partial class InsertProductForm : Window
    {
        public InsertProductForm()
        {
            InitializeComponent();
            InsertProductViewModel datacontext = new InsertProductViewModel();
            this.ComboboxType.ItemsSource = new List<string>() {"Burgers","Pasta","Pizza","Fries","Drinks","Others" };
            this.DataContext = datacontext;
            this.buttonDelete.Visibility = Visibility.Hidden;
        }
        public InsertProductForm(Product p)
        {
            InitializeComponent();
            InsertProductViewModel datacontext = new InsertProductViewModel(p);
            this.ComboboxType.ItemsSource = new List<string>() { "Burgers", "Pasta", "Pizza", "Fries", "Drinks", "Others" };
            this.DataContext = datacontext;
            this.txtboxName.IsEnabled = false;
            this.buttonInsert.Content = "Update Product";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            InsertProductViewModel vm = this.DataContext as InsertProductViewModel;
            if (vm.DeleteCommand != null)
            {
                vm.DeleteCommand.Execute(this);
            }
        }
    }
}
