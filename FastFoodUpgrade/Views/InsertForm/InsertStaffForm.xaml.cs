using FastFoodUpgrade.Models;
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
        private Staff s;
        public InsertStaffForm()
        {
            InitializeComponent();
            this.ComboboxAcess.ItemsSource = new List<string>() { "Admin", "Staff" };
            this.ComboboxSex.ItemsSource = new List<string>() { "Male", "Female", "Others" };
        }
        public InsertStaffForm(Staff selectedStaff)
        {
            InitializeComponent();
            this.s = selectedStaff;
            this.buttonInsert.Visibility = Visibility.Hidden;
            this.ComboboxAcess.ItemsSource = new List<string>() { "Admin", "Staff" };
            this.ComboboxSex.ItemsSource = new List<string>() { "Male", "Female", "Others" };
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.s == null)
                this.DataContext = await InsertStaffViewModel.Initialize();
            else
                this.DataContext = new InsertStaffViewModel(s);
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InsertStaffViewModel vm = this.DataContext as InsertStaffViewModel;
            if(vm.InsertStaff!=null)
                vm.InsertStaff.Execute(this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
