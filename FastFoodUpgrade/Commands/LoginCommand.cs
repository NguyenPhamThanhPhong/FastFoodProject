using FastFoodUpgrade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FastFoodUpgrade.Windows;
using FastFoodUpgrade.ViewModels;
using MongoDB.Driver;

namespace FastFoodUpgrade.Commands
{
    public class LoginCommand : CommandBase
    {
        LoginViewModel loginViewModel;
        public LoginCommand(LoginViewModel loginViewModel) 
        {
            this.loginViewModel = loginViewModel;
        }
        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }
        public override async void Execute(object parameter)
        {
            DataProvider<Staff> db = new DataProvider<Staff>(Staff.Collection);
            string user = loginViewModel.username;
            string password = loginViewModel.password;
            FilterDefinition<Staff> filterLogin = Builders<Staff>.Filter.Eq(s => s.Username, user) & Builders<Staff>.Filter.Eq(s => s.Username, user);
            var matchingStaff = await db.ReadFilteredAsync(filterLogin);
            if (matchingStaff != null) 
            {
                Window f = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
                f.Hide();
                DashBoardWindow ff = new DashBoardWindow();
                ff.ShowDialog();
                f.Show();
            }
            else
            {
                MessageBox.Show("incorrect pass");
            }

        }
        
    }
}
