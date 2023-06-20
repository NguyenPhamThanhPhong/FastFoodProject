using FastFoodUpgrade.Models;
using FastFoodUpgrade.Utility;
using FastFoodUpgrade.ViewModels.InsertFormViewModels;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastFoodUpgrade.Commands.DeleteCommands
{
    public class DeleteProductCommand : AsyncCommandBase
    {
        private InsertProductViewModel ipvm;
        StringBuilder filename;
        public DeleteProductCommand(InsertProductViewModel ipvm, StringBuilder filepath) {
            this.ipvm = ipvm;
            this.filename = filepath;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            MessageBoxResult asking = MessageBox.Show("Are you sure to DELETE?", "REMINDING",
    MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (asking == MessageBoxResult.No) return;
            await Task.Run(() =>
            {
                DataProvider<Product> db = new DataProvider<Product>(Product.Collection);
                FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(x => x._id, ipvm.ID);
                db.Delete(filter);
                ImageStorage.DeleteImage(ImageStorage.ProductImageLocation,filename.ToString());
                Application.Current.Dispatcher.Invoke(() =>{
                    Window f = parameter as Window;
                    f.Close();
                });

            });
        }
    }
}
