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

namespace FastFoodUpgrade.Commands.UpdateCommands
{
    public class UpdateIngredientCommand : AsyncCommandBase
    {
        InsertIngredientViewModel vm;
        public UpdateIngredientCommand(InsertIngredientViewModel vm) {
            this.vm = vm;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            MessageBoxResult asking = MessageBox.Show("Are you sure to save change?", "REMINDING",
    MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (asking == MessageBoxResult.No) return;
            Ingredient ing = vm.CurrentIngredient;
            string filepath = vm.Filename.ToString();

            await Task.Run(() =>
            {
                FilterDefinition<Ingredient> filter = Builders<Ingredient>.Filter.Eq(x => x.ID, ing.ID);
                UpdateDefinition<Ingredient> update = Builders<Ingredient>.Update
                .Set(x => x.Name, ing.Name)
                .Set(x => x.Type, ing.Type)
                .Set(x => x.Quantity, ing.Quantity)
                .Set(x => x.Unit, ing.Unit)
                .Set(x => x.Description, ing.Description);
                DataProvider<Ingredient> db = new DataProvider<Ingredient>(Ingredient.Collection);
                db.Update(filter, update);
                if (!String.IsNullOrEmpty(filepath))
                {
                    ImageStorage.StoreImage(filepath, ImageStorage.IngredientImageLocation, ing.Avatar);
                }
                MessageBox.Show("Updated Ingredient");
            });

        }
    }
}
