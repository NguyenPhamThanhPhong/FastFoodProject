using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels.InsertFormViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace FastFoodUpgrade.Commands.InsertCommands
{
    public class InsertCustomerCommand : AsyncCommandBase
    {
        InsertCustomerViewModel vm;
        public InsertCustomerCommand(InsertCustomerViewModel vm)
        {
            this.vm = vm;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            Int32 ID      = vm.ID;
            String name   =  vm.Name;
            String Phone  =  vm.Phone;
            String Address=  vm.Address;
            try
            {
                await Task.Run(async () =>
                {
                    if (Customer.IsExisted(name, Phone))
                    {
                        MessageBox.Show("This customer already exist, please checkout NAME and PHONE NUMBERS");
                        return;
                    }
                    Customer c = new Customer()
                    {
                        ID = ID,
                        Fullname = name,
                        Phone = Phone,
                        Address = Address
                    };
                    DataProvider<Customer> db = new DataProvider<Customer>(Customer.Collection);
                    await db.InsertOneAsync(c);
                    Window f = parameter as Window;
                    f.Close();
                });
            }
            catch
            {

            }

        }
    }
}
