using FastFoodUpgrade.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastFoodUpgrade.ViewModels.RightSplitTask;
using System.Windows;

namespace FastFoodUpgrade.Commands.AdvancedSearchCommand
{
    public class StaffAdvancedSearchCommand : AsyncCommandBase
    {
        StaffAdvancedSearch vm;
        public StaffAdvancedSearchCommand(StaffAdvancedSearch vm) 
        {
            this.vm = vm;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            await Task.Run(async () =>
            {
                string Name = vm.Name.Trim().ToLower();
                string Email = vm.Email .Trim().ToLower(); 
                string AcessRight = vm.AccessRight.Trim().ToLower();
                string Gender = vm.Gender.Trim().ToLower();
                string Phone = vm.Phone.Trim().ToLower();
                DataProvider<Staff> db = new DataProvider<Staff>(Staff.Collection);
                FilterDefinition<Staff> filter = Builders<Staff>.Filter.Where(
                    s => s.Fullname.Trim().ToLower().Contains(Name)
                    && s.Email.Trim().ToLower().Contains(Email)
                    && s.AccessRight.Trim().ToLower().Contains(AcessRight)
                    && s.Sex.Trim().ToLower().Contains(Gender)
                    && s.Phone.Trim().ToLower().Contains(Phone));
                List<Staff> results = db.ReadFiltered(filter);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    vm.viewModel.UpdateListStaff(results);
                });
            });
        }
    }
}
