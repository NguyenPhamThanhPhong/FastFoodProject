﻿using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels;
using FastFoodUpgrade.Views.InsertForm;
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
    }
}
