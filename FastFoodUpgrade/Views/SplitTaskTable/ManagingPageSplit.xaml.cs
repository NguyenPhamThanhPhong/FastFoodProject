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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FastFoodUpgrade.Views.SplitTaskTable
{
    /// <summary>
    /// Interaction logic for ManagingPageSplit.xaml
    /// </summary>
    public partial class ManagingPageSplit : UserControl
    {
        public ManagingPageSplit()
        {
            InitializeComponent();
            AcessRightCombobox.ItemsSource = new List<string>() { "All","Staff","Admin" };
            GenderCombobox.ItemsSource = new List<string>() { "Male", "Female","Other" };
        }
    }
}
