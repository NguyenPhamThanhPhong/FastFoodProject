using FastFoodUpgrade.Commands;
using FastFoodUpgrade.Commands.InsertCommands;
using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels.RightSplitTask;
using Microsoft.Win32;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FastFoodUpgrade.ViewModels.InsertFormViewModels
{
    public class InsertIngredientViewModel : ViewModelBase
    {
        private Ingredient _currentIngredient = new Ingredient();
        public Ingredient CurrentIngredient
        {
            get => _currentIngredient;
            set { _currentIngredient = value; OnPropertyChanged(nameof(CurrentIngredient)); }
        }
        private StringBuilder _filename = new StringBuilder("");
        public StringBuilder Filename
        {
            get => _filename;
            set { _filename = value; OnPropertyChanged(nameof(Filename)); }
        }
        public IngredientAdvancedSearch CurrentAdvancedSearch;
        public ICommand SaveImageDialog { get; set; }
        public ICommand InsertIngredient { get; set; }
        public InsertIngredientViewModel()
        {
            this.CurrentIngredient.ID = ObjectId.GenerateNewId().ToString();
            SaveImageDialog = new SaveImageDialogCommand(Filename, this);
            InsertIngredient = new InsertIngredientCommand(CurrentIngredient, Filename);
        }

    }
}
