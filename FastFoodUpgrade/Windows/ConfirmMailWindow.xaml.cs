using FastFoodUpgrade.ViewModels;
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
    /// Interaction logic for ConfirmMailWindow.xaml
    /// </summary>
    public partial class ConfirmMailWindow : Window
    {
        private SignUpViewModel vm;
        public ConfirmMailWindow(SignUpViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string code = vm.Current6Digits;
            if (code == txtbox.Text)
            {
                vm.IsConfirmed= true;
                MessageBox.Show("Mail Confirmed");
                this.Close();
            }
            else
                MessageBox.Show("Incorrect code, please check mail again");
        }
    }
}
