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
            FilterDefinition<Staff> filterLogin = Builders<Staff>.Filter.Where(s=>s.Username == user&&s.Password==password);
            var matchingStaff =  db.ReadFiltered(filterLogin);
            if (matchingStaff != null) 
            {
                Staff loggedInStaff=null;
                if (matchingStaff.Count > 0)
                {
                    loggedInStaff = matchingStaff[0];
                    Window f = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
                    f.Hide();
                    DashBoardWindow ff = new DashBoardWindow(loggedInStaff);
                    ff.ShowDialog();
                    f.Show();
                }
            }
            else
            {
                MessageBox.Show("incorrect pass");
            }

        }
        
    }
}
