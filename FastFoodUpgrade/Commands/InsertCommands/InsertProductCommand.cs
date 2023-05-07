using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels.InsertFormViewModels;
using FastFoodUpgrade.Views.InsertForm;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastFoodUpgrade.Commands.InsertCommands
{
    public class InsertProductCommand : AsyncCommandBase
    {
        InsertProductViewModel ipvm;
        public InsertProductCommand(InsertProductViewModel currentIpvm) 
        { 
            ipvm = currentIpvm;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            if(!Product.IsNameConflict(ipvm.Name))
            {
                DataProvider<Product> db = new DataProvider<Product>(Product.Collection);
                Product P = new Product();
                P._id = ObjectId.GenerateNewId().ToString();
                P.Name = ipvm.Name;
                P.Type = ipvm.Type;
                P.Remain = ipvm.Remaining;
                P.Price = ipvm.Price;
                P.Description = ipvm.Description;
                P.Avatar = P._id + ".png";
                P.DiscountAmount = new Discount() { Value = ipvm.DiscountAmount, EndDate = ipvm.ExpirationDate };
                if (P.IsValid())
                {
                    await db.InsertOneAsync(P);
                    MessageBox.Show("Added one new Product");
                }
                else
                    MessageBox.Show("Please check input Data again");
            }
        }
    }
}
