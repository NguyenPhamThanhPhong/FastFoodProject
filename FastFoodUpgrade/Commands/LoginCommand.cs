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
        MainViewModel currentMain;
        public LoginCommand(LoginViewModel loginViewModel, MainViewModel currentMain) 
        {
            this.loginViewModel = loginViewModel;
            this.currentMain = currentMain;
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
                currentMain.currentViewModel = new DashBoardViewModel(currentMain);
            }
            else
            {
                MessageBox.Show("incorrect pass");
            }
            //using (var db = new fastfooddtbEntities())
            //{
            //    string user = loginViewModel.username;
            //    string pass = loginViewModel.password;
            //    var matchingStaff = db.Staffs.FirstOrDefault(s => s.username == user && s.pass == pass);
            //    if (matchingStaff != null)
            //    {
            //        currentMain.currentViewModel = new DashBoardViewModel(currentMain);
            //        //DashBoardWindow f = new DashBoardWindow();
            //        //f.ShowDialog();
            //    }
            //    else
            //    {
            //        MessageBox.Show("incorrect pass");
            //    }
        }
        
    }
}
