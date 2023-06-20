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
                    CustomerPurchaser = Customer.GetCustomerByName(_ibvm.CustomerName),
                    BillDate = DateTime.Now,
                    DiscountAmount = _ibvm.DiscountAmount,
                    Orders = _ibvm.Odrs.ToList(),
                    SaleStaff = _ibvm.SaleStaff,
                    Total = _ibvm.Total
                };
                if(b.CustomerPurchaser == null)
                {
                    MessageBox.Show("invalid Customer");
                    return;
                }
                DataProvider<Bill> db = new DataProvider<Bill>(Bill.Collection);
                db.Insert(b);
            });
            await ResetInsertBillForm();
        }
        private async Task ResetInsertBillForm()
        {
            DataProvider<Bill> db = new DataProvider<Bill>(Bill.Collection);
            _ibvm.BillID = db.ReadAll().Count + 1;
            _ibvm.CustomerName = "";
            _ibvm.Odrs.Clear();
            _ibvm.IsDropDownOpen = false;
            _ibvm.Total = 0;
            _ibvm.Payment = 0;
        }
    }
}
