﻿using FastFoodUpgrade.Models;
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
using MongoDB.Driver;

namespace FastFoodUpgrade.Windows
{
    /// <summary>
    /// Interaction logic for DashBoardWindow.xaml
    /// </summary>
    public partial class DashBoardWindow : Window
    {
        public DashBoardWindow()
        {
            InitializeComponent();
            this.DataContext = new DashBoardViewModel();
            //MyFrame.Source = new Uri("/Views/Pages/CustomerPage.xaml",UriKind.Relative);
        }
        public Staff s { get; set; }
        public DashBoardWindow(Staff loggedinStaff)
        {
            InitializeComponent();
            this.DataContext = new DashBoardViewModel(loggedinStaff);
            //MyFrame.Source = new Uri("/Views/Pages/CustomerPage.xaml",UriKind.Relative);
            this.s = loggedinStaff;
            if(s.AccessRight == "Staff")
            {
                this.buttonIngredient.Visibility = Visibility.Collapsed;
                this.buttonManaging.Visibility = Visibility.Collapsed;
            }
        }
        public void UpdateStaff()
        {
            //DataProvider<Staff> db = new DataProvider<Staff>(Staff.Collection);
            //FilterDefinition<Staff> filter = Builders<Staff>.Filter.Eq("_id", s.ID);
            //List<Staff> stfs = db.ReadFiltered(filter);
            //if (stfs.Count > 0)
            //{
            //    Staff clone = stfs[0];
                
            //}
            DashBoardViewModel vm = this.DataContext as DashBoardViewModel;
            string avt = vm.CurrentStaff.Avatar;
            vm.CurrentStaff.Avatar = avt;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            (this.DataContext as DashBoardViewModel).SwitchHomePage();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            (this.DataContext as DashBoardViewModel).SwitchProductPage();

        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            (this.DataContext as DashBoardViewModel).SwitchBillPage();
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            (this.DataContext as DashBoardViewModel).SwitchCustomerPage();
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            (this.DataContext as DashBoardViewModel).SwitchManagingPage();
        }

        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            (this.DataContext as DashBoardViewModel).SwitchIngredientPage();
        }

        private void RadioButton_Checked_6(object sender, RoutedEventArgs e)
        {
            (this.DataContext as DashBoardViewModel).SwitchSettingPage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
