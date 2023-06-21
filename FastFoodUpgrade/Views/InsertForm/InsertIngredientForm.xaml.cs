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
using FastFoodUpgrade.Models;
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
            this.ComboboxType.ItemsSource = new List<string>() { "Meat","Dairy","Seafood","Fruits","Vegetables","Grains","Herbs","Others"};
            this.buttondelete.Visibility = Visibility.Hidden;
        }
        public InsertIngredientForm(Ingredient ii)
        {
            InitializeComponent();
            this.DataContext = new InsertIngredientViewModel(ii);
            this.ComboboxType.ItemsSource = new List<string>() { "Meat", "Dairy", "Seafood", "Fruits", "Vegetables", "Grains", "Herbs", "Others" };
            this.buttonInsert.Content = "Update";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Delete ingredient
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            InsertIngredientViewModel vm = this.DataContext as InsertIngredientViewModel;
            if (vm.DeleteIngredient != null)
            {
                vm.DeleteIngredient.Execute(this);
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text, out _))
            {
                e.Handled = true;  // Prevents non-integer input from being entered
            }
        }
    }
}
