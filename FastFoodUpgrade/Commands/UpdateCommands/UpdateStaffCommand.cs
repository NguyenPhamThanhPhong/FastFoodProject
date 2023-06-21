using FastFoodUpgrade.Models;
using FastFoodUpgrade.Utility;
using FastFoodUpgrade.ViewModels;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastFoodUpgrade.Commands.UpdateCommands
{
    public class UpdateStaffCommand : AsyncCommandBase
    {
        SettingViewModel vm;
        public UpdateStaffCommand(SettingViewModel vm) { this.vm = vm; }
        public override async Task ExecuteAsync(object parameter)
        {
            MessageBoxResult asking = MessageBox.Show("Are you sure to save change?", "REMINDING",
MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (asking == MessageBoxResult.No) return;
            Staff s = vm.CurrentStaff;
            string filepath = vm.Filename.ToString();
            if (s.Email != vm.MailConfirmed)
            {
                MessageBox.Show("please confirm mail");
                return;
            }
            if (s.Phone.Any(c => char.IsDigit(c)))
            {
                MessageBox.Show("invalid phone number");
                return;
            }

            await Task.Run(() =>
            {
                DataProvider<Staff> db = new DataProvider<Staff>(Staff.Collection);
                FilterDefinition<Staff> filter = Builders<Staff>.Filter.Eq("_id",s.ID);
                UpdateDefinition<Staff> update = Builders<Staff>.Update
                .Set(x => x.Fullname, s.Fullname)
                .Set(x => x.Phone, s.Phone)
                .Set(x => x.Sex, s.Sex)
                .Set(x => x.Address, s.Address)
                .Set(x => x.Email, s.Email)
                .Set(x => x.Password, s.Password);
                db.Update(filter, update);
                if (!String.IsNullOrEmpty(filepath))
                {
                    ImageStorage.StoreImage(filepath, ImageStorage.StaffImageLocation, s.Avatar);
                }
                MessageBox.Show("Updated Account");

            });
        }
    }
}
