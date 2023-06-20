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

namespace FastFoodUpgrade.Views.ViewForm
{
    /// <summary>
    /// Interaction logic for ViewCustomerForm.xaml
    /// </summary>
    public partial class ViewCustomerForm : Window
    {
        public ViewCustomerForm(Customer c)
        {
            InitializeComponent();
            this.txtboxName.Text = c.Fullname;
            this.txtboxPhone.Text = c.Phone;
            this.txtboxRank.Text = c.Rank;
            this.txtboxTotal.Text = c.Total.ToString();
            this.txtboxAddress.Text = c.Address;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
