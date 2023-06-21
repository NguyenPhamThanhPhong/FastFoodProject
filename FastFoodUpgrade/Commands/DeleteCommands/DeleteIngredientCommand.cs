using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels.InsertFormViewModels;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastFoodUpgrade.Commands.DeleteCommands
{
    public class DeleteIngredientCommand : AsyncCommandBase
    {
        StringBuilder filename;
        InsertIngredientViewModel vm;
        public DeleteIngredientCommand(InsertIngredientViewModel vm, StringBuilder filename)
        {
            this.vm = vm;
            this.filename = filename;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            MessageBoxResult asking = MessageBox.Show("Are you sure to DELETE?", "REMINDING",
MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (asking == MessageBoxResult.No) return;
            await Task.Run(() =>
            {
                DataProvider<Ingredient> db = new DataProvider<Ingredient>(Ingredient.Collection);
                FilterDefinition<Ingredient> filter = Builders<Ingredient>.Filter.Eq(x => x.ID, vm.CurrentIngredient.ID);
                db.Delete(filter);
                MessageBox.Show("Deleted");
                if (parameter != null)
                {
                    Application.Current.Dispatcher.Invoke(() => {
                        Window f = parameter as Window;
                        f.Close();
                    });
                }

            });
        }
    }
}
