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
    internal class IngredientAdvancedSearchCommand : AsyncCommandBase
    {
        IngredientAdvancedSearch viewmodel;
        public IngredientAdvancedSearchCommand(IngredientAdvancedSearch viewmodel) {
            this.viewmodel= viewmodel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            await Task.Run(() =>
            {
                string name = viewmodel.Name.Trim().ToLower();
                string type = viewmodel.Type.Trim().ToLower();
                if (type.Equals("all"))
                {
                    type = "";
                }
                DataProvider<Ingredient> db = new DataProvider<Ingredient>(Ingredient.Collection);
                FilterDefinition<Ingredient> filter = Builders<Ingredient>.Filter.Where(
                    x => x.Name.Trim().ToLower().Contains(name) &&
                    x.Type.Trim().ToLower().Contains(type) &&
                    x.Quantity <= viewmodel.QuantityTo &&
                    x.Quantity >= viewmodel.QuantityFrom);
                List<Ingredient> ingredients = db.ReadFiltered(filter);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    viewmodel.vm.UpdateListIngredients(ingredients);
                });
            });

        }
    }
}
