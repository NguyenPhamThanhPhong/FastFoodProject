﻿using FastFoodUpgrade.Models;
using FastFoodUpgrade.Utility;
using FastFoodUpgrade.ViewModels.InsertFormViewModels;
using FastFoodUpgrade.ViewModels.ModelBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastFoodUpgrade.Commands.InsertCommands
{
    public class InsertStaffCommand : AsyncCommandBase
    {
        InsertStaffViewModel vm;
        StringBuilder sb;
        Staff s;
        public InsertStaffCommand(InsertStaffViewModel vm) 
        { this.vm = vm; }
        public InsertStaffCommand(InsertStaffViewModel vm,Uri u)
        { this.vm = vm; }
        public InsertStaffCommand(Staff s, StringBuilder Filename){
            this.s = s;
            this.sb = Filename;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            await Task.Run(async () =>
            {
                if (await Staff.IsExisted(s.Username))
                {
                    MessageBox.Show("Username already existed");
                    return;
                }
                    
                DataProvider<Staff> db = new DataProvider<Staff>(Staff.Collection);
                await db.InsertOneAsync(s);
                string filename = sb.ToString();
                if(!String.IsNullOrEmpty(filename) && File.Exists(filename))
                {
                    ImageStorage.StoreImage(filename, ImageStorage.StaffImageLocation, s.Avatar);
                }
                MessageBox.Show("Singed up sucessfully");
                if (parameter != null)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {

                        Window f = parameter as Window;
                        f.Close();
                    });

                }
            });
        }
    }
}
