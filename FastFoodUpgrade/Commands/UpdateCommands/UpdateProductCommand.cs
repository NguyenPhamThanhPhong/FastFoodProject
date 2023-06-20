using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels.InsertFormViewModels;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastFoodUpgrade.Commands.UpdateCommands
{
    public class UpdateProductCommand : AsyncCommandBase
    {
        private InsertProductViewModel ipvm;
        StringBuilder filename;
        public UpdateProductCommand(InsertProductViewModel ipvm,StringBuilder filepath)
        {
            this.ipvm = ipvm;
            this.filename = filepath;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            MessageBoxResult asking = MessageBox.Show("Are you sure to save change?", "REMINDING",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (asking == MessageBoxResult.No) return;
            await Task.Run(() => {
                DataProvider<Product> db = new DataProvider<Product>(Product.Collection);
                Product P = new Product();
                P._id = ipvm.ID;
                P.Name = ipvm.Name;
                P.Type = ipvm.Type;
                P.Remain = ipvm.Remaining;
                P.Price = ipvm.Price;
                P.Description = ipvm.Description;
                P.Avatar = P._id + ".png";
                P.DiscountAmount = new Discount() { Value = ipvm.DiscountAmount, StartDate = ipvm.StartDate = ipvm.StartDate, EndDate = ipvm.ExpirationDate };
                string filepath = filename.ToString();
                if (!P.IsValid() || P.DiscountAmount.StartDate < P.DiscountAmount.EndDate)
                    return;
                FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(x => x._id, P._id);
                UpdateDefinition<Product> update = Builders<Product>.Update
                    .Set(x => x.Type, P.Type)
                    .Set(x => x.Remain, P.Remain)
                    .Set(x => x.Price, P.Price)
                    .Set(x => x.Description, P.Description)
                    .Set(x => x.DiscountAmount, P.DiscountAmount);
                db.Update(filter, update);
            });


        }
    }
}
