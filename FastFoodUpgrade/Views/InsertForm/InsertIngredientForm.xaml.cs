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
using FastFoodUpgrade.ViewModels;
using FastFoodUpgrade.ViewModels.InsertFormViewModels;

namespace FastFoodUpgrade.Views.InsertForm
{
    /// <summary>
    /// Interaction logic for InsertIngredientForm.xaml
    /// </summary>
    public partial class InsertIngredientForm : Window
    {
        public InsertIngredientForm()
        {
            InitializeComponent();
            this.DataContext = new InsertIngredientViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
