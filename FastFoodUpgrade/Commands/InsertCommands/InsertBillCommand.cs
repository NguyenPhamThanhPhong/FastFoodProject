using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels.InsertFormViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodUpgrade.Commands.InsertCommands
{
    public class InsertBillCommand : AsyncCommandBase
    {
        InsertBillViewModel _ibvm;
        public InsertBillCommand(InsertBillViewModel ibvm) 
        {
            _ibvm = ibvm;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            await Task.Run(() =>
            {
                Bill b = new Bill()
                {
                    ID = _ibvm.BillID,
                    CustomerPurchaser = _ibvm.SelectedCustomer,
                    BillDate = DateTime.Now,
                    DiscountAmount = 0,
                    Orders = _ibvm.Odrs.ToList(),
                    SaleStaff = _ibvm.SaleStaff,
                    Total = _ibvm.Total
                };
                DataProvider<Bill> db = new DataProvider<Bill>(Bill.Collection);
                db.Insert(b);
            });
            await ResetInsertBillForm();
        }
        private async Task ResetInsertBillForm()
        {
            DataProvider<Bill> db = new DataProvider<Bill>(Bill.Collection);
            _ibvm.BillID = db.ReadAll().Count + 1;
            _ibvm.SelectedCustomer = null;
            _ibvm.Odrs.Clear();
        }
    }
}
