using FastFoodUpgrade.Models;
using FastFoodUpgrade.Utility;
using FastFoodUpgrade.ViewModels.InsertFormViewModels;
using FastFoodUpgrade.Views.InsertForm;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastFoodUpgrade.Commands.InsertCommands
{
    public class InsertProductCommand : AsyncCommandBase
    {
        InsertProductViewModel ipvm;
        StringBuilder filename;
        public InsertProductCommand(InsertProductViewModel currentIpvm,StringBuilder Filename) 
        { 
            ipvm = currentIpvm;
            filename = Filename;
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
                P.DiscountAmount = new Discount() { Value = ipvm.DiscountAmount,StartDate=ipvm.StartDate, EndDate = ipvm.ExpirationDate };
                string filepath = filename.ToString();

                if (P.IsValid())
                {
                    if (P.DiscountAmount.StartDate < P.DiscountAmount.EndDate)
                    {
                        MessageBox.Show("invalid Discount: START DATE should be less than END DATE");
                        return;
                    }
                    await db.InsertOneAsync(P);
                    if (!String.IsNullOrEmpty(filepath) && File.Exists(filepath))
                    {
                        ImageStorage.StoreImage(filepath, ImageStorage.ProductImageLocation, P.Avatar);
                    }
                    MessageBox.Show("Added one new Product");
                    ipvm.RefreshForm();
                }
                else
                    MessageBox.Show("Please check input Data again");

            }
        }
    }
}
