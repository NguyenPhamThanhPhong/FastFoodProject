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
        public InsertBillForm(Bill b)
        {
            InitializeComponent();
            this.DataContext= new InsertBillViewModel(b);
            this.InsertButton.IsEnabled = false;
            this.ComboboxCutomer.IsEnabled = false;
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(this._currentStaff!= null)
                this.DataContext = await InsertBillViewModel.CreateAsync(_currentStaff);
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
