using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels.InsertFormViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastFoodUpgrade.Commands.InsertCommands
{
    public class InsertStaffCommand : AsyncCommandBase
    {
        InsertStaffViewModel vm;
        public InsertStaffCommand(InsertStaffViewModel vm) 
        { this.vm = vm; }
        public override async Task ExecuteAsync(object parameter)
        {
            await Task.Run(async () =>
            {
                if (await Staff.IsExisted(vm.UserName))
                {
                    MessageBox.Show("Username already existed");
                    return;
                }
                    
                Staff s = new Staff()
                {
                    ID = await Staff.GenerateID(),
                    Fullname = vm.Name,
                    Username = vm.UserName,
                    Password = vm.Password,
                    Sex = vm.Sex,
                    Phone = vm.Phone,
                    AccessRight = vm.AccessRight,
                    Email = vm.Email,
                    Address = vm.Address,
                };
                s.Avatar = s.ID + ".png";
                DataProvider<Staff> db = new DataProvider<Staff>(Staff.Collection);
                await db.InsertOneAsync(s);
            });
        }
    }
}
