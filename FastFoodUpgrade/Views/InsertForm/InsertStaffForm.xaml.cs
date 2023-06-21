using FastFoodUpgrade.ViewModels.InsertFormViewModels;
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

namespace FastFoodUpgrade.Views.InsertForm
{
    /// <summary>
    /// Interaction logic for InsertStaffForm.xaml
    /// </summary>
    public partial class InsertStaffForm : Window
    {
        public InsertStaffForm()
        {
            InitializeComponent();
            this.ComboboxAcess.ItemsSource = new List<string>() { "Admin", "Staff" };
            this.ComboboxSex.ItemsSource = new List<string>() { "Male", "Female", "Others" };
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = await InsertStaffViewModel.Initialize();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InsertStaffViewModel vm = this.DataContext as InsertStaffViewModel;
            vm.InsertStaff.Execute(this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
