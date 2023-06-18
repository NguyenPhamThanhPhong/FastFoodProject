using FastFoodUpgrade.Models;
using FastFoodUpgrade.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodUpgrade.Commands.InsertCommands
{
    public class InsertIngredientCommand : AsyncCommandBase
    {
        Ingredient ii;
        StringBuilder filename;
        public InsertIngredientCommand(Ingredient ii,StringBuilder filename) 
        {
            this.ii = ii;
            this.filename = filename;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            await Task.Run(async () =>
            {
                if (!await ii.IsValid())
                {
                    return;
                }
                DataProvider<Ingredient> db = new DataProvider<Ingredient>(Ingredient.Collection);
                await db.InsertOneAsync(ii);
                string filepath = filename.ToString();
                if (!String.IsNullOrEmpty(filepath) && File.Exists(filepath))
                {
                    ImageStorage.StoreImage(filepath, ImageStorage.IngredientImageLocation, ii.Avatar);
                }
            });
        }
    }
}
