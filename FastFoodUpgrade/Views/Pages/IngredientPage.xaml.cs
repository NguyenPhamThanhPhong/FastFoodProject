using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels;
using FastFoodUpgrade.Views.InsertForm;
using FastFoodUpgrade.Views.ViewForm;
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

namespace FastFoodUpgrade.Views.Pages
{
    /// <summary>
    /// Interaction logic for IngredientPage.xaml
    /// </summary>
    public partial class IngredientPage : Page
    {
        public IngredientPage()
        {
            InitializeComponent();
            //this.ComboboxFilter.ItemsSource = new List<string>() { "aljsdkljalksd", "kakjdsklajsd" };
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //InsertStaffForm f = new InsertStaffForm();
            //f.ShowDialog();
            //DataProvider<Staff> db = new DataProvider<Staff>(Staff.Collection);
            //List<Staff> results = await db.ReadAllAsync();
            //(this.DataContext as ManagingViewModel).UpdateListStaff(results);
            InsertIngredientForm f = new InsertIngredientForm();
            f.ShowDialog();
            await Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    IngredientViewModel vm = this.DataContext as IngredientViewModel;
                    DataProvider<Ingredient> db = new DataProvider<Ingredient>(Ingredient.Collection);
                    List<Ingredient> all = db.ReadAll();
                    vm.UpdateListIngredients(all);
                });
            });

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //this.DataContext = await ManagingViewModel.Initialize();
            this.DataContext = await IngredientViewModel.Initialize();
        }
        // double click
        private DateTime _lastClickTime;

        private async void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((DateTime.Now - _lastClickTime).TotalMilliseconds < 500)
            {
                Grid g = sender as Grid;
                Ingredient ii = g.DataContext as Ingredient;
                if (ii != null)
                {
                    InsertIngredientForm f = new InsertIngredientForm(ii);
                    f.ShowDialog();
                    await Task.Run(() =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            IngredientViewModel vm = this.DataContext as IngredientViewModel;
                            DataProvider<Ingredient> db = new DataProvider<Ingredient>(Ingredient.Collection);
                            List<Ingredient> all = db.ReadAll();
                            vm.UpdateListIngredients(all);
                        });
                    });
                }
            }
            _lastClickTime = DateTime.Now;


        }
    }
}
