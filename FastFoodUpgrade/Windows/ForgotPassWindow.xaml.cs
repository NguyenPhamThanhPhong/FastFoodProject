using FastFoodUpgrade.Models;
using FastFoodUpgrade.Utility;
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

namespace FastFoodUpgrade.Windows
{
    /// <summary>
    /// Interaction logic for ForgotPassWindow.xaml
    /// </summary>
    public partial class ForgotPassWindow : Window
    {
        public ForgotPassWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = txtboxEmail.Text;
                if (String.IsNullOrEmpty(email))
                {
                    MessageBox.Show("please enter email");
                    return;
                }
                string username = txtboxUsername.Text;
                if (String.IsNullOrEmpty(username))
                {
                    MessageBox.Show("please enter username");
                    return;
                }
                Staff s = Staff.GetStaffbyUsernameEmail(username,email);
                if (s == null)
                {
                    MessageBox.Show("incorrect user name");
                    return;
                }
                MailUtil.SendEmail(email, "NoReply", s.Password);
                MessageBox.Show("Password now sent to your Gmail, please check out to login");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
