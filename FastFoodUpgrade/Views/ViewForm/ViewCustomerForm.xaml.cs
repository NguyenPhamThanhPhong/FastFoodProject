using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels;
using FastFoodUpgrade.Windows;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FastFoodUpgrade.Views.ViewForm
{
    /// <summary>
    /// Interaction logic for ViewCustomerForm.xaml
    /// </summary>
    public partial class ViewCustomerForm : Window
    {
        private int ID;
        private Staff s;
        public ViewCustomerForm(Customer c,Staff s)
        {
            InitializeComponent();
            this.txtboxName.Text = c.Fullname;
            this.txtboxPhone.Text = c.Phone;
            this.txtboxRank.Text = c.Rank;
            this.txtboxTotal.Text = c.Total.ToString();
            this.txtboxAddress.Text = c.Address;
            this.ID = c.ID;
            this.s = s;
            if(s.AccessRight == "Staff")
            {
                buttonDelete.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        //update
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult asking = MessageBox.Show("Are you sure to save change?", "REMINDING",
    MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (asking == MessageBoxResult.No) return;
            string name = txtboxName.Text;
            string phone = txtboxPhone.Text;
            string address = txtboxAddress.Text;
            if(!phone.Any(c=>char.IsDigit(c))){
                MessageBox.Show("invalid phone number");
                return;
            }
            FilterDefinition<Customer> filter = Builders<Customer>.Filter.Eq("_id", ID);
            UpdateDefinition<Customer> update = Builders<Customer>.Update
                .Set(c => c.Fullname, name)
                .Set(c => c.Phone, phone)
                .Set(c => c.Address, address);
            DataProvider<Customer> db = new DataProvider<Customer>(Customer.Collection);
            db.Update(filter, update);
            
        }
        //Delete
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBoxResult asking = MessageBox.Show("Are you sure to DELETE ?", "REMINDING",
MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (asking == MessageBoxResult.No) return;
            DataProvider<Customer> db = new DataProvider<Customer>(Customer.Collection);
            FilterDefinition<Customer> filter = Builders<Customer>.Filter.Eq(x => x.ID, ID);
            db.Delete(filter);
            this.Close();
        }
    }
}
