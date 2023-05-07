using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels.InsertFormViewModels;
using FastFoodUpgrade.Views.ListViews;
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
    /// Interaction logic for InsertBillForm.xaml
    /// </summary>
    public partial class InsertBillForm : Window
    {
        private Staff _currentStaff;
        public InsertBillForm(Staff currentStaff)
        {
            InitializeComponent();
            _currentStaff = currentStaff;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = await InsertBillViewModel.CreateAsync(_currentStaff);
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
