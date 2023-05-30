using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels.RightSplitTask;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastFoodUpgrade.Commands.AdvancedSearchCommand
{
    public class BillAdvancedSearchCommand : AsyncCommandBase
    {
        BillAdvancedSearch vm;
        public BillAdvancedSearchCommand(BillAdvancedSearch vm) 
        {
            this.vm = vm;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            await Task.Run(async () =>
            {
                string customerName = vm.CustomerName.Trim().ToLower();
                string staffName = vm.StaffName.Trim().ToLower();
                
                DataProvider<Bill> db = new DataProvider<Bill>(Bill.Collection);
                FilterDefinition<Bill> filter = Builders<Bill>.Filter.Where(
                    b => b.CustomerPurchaser.Fullname.Trim().ToLower().Contains(customerName)
                    && b.SaleStaff.Fullname.Trim().ToLower().Contains(staffName)
                    && b.BillDate >= vm.DateFrom
                    && b.BillDate <= vm.DateTo
                    && b.Total <= vm.TotalTo
                    && b.Total >= vm.TotalFrom);
                List<Bill> results = await db.ReadFilteredAsync(filter);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    vm.CurrentBillViewModel.UpdateBillList(results);
                });
            });
        }
    }
}
