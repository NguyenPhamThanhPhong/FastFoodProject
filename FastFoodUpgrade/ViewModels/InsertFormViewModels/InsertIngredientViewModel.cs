using FastFoodUpgrade.Commands;
using FastFoodUpgrade.Commands.DeleteCommands;
using FastFoodUpgrade.Commands.InsertCommands;
using FastFoodUpgrade.Commands.UpdateCommands;
using FastFoodUpgrade.Models;
using FastFoodUpgrade.Utility;
using FastFoodUpgrade.ViewModels.RightSplitTask;
using Microsoft.Win32;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
        public ICommand SaveImageDialog { get; set; }
        public ICommand InsertIngredient { get; set; }
        public ICommand DeleteIngredient { get; set; }

        public InsertIngredientViewModel()
        {
            this.CurrentIngredient.ID = ObjectId.GenerateNewId().ToString();
            SaveImageDialog = new SaveImageDialogCommand(Filename, this);
            InsertIngredient = new InsertIngredientCommand(CurrentIngredient, Filename);
        }
        public InsertIngredientViewModel(Ingredient ii)
        {
            this.CurrentIngredient = ii;
            SaveImageDialog = new SaveImageDialogCommand(Filename, this);
            InsertIngredient = new UpdateIngredientCommand(this);
            this.DeleteIngredient = new DeleteIngredientCommand(this, Filename);
            this.Filename.Clear();
            this.Filename.Append(ImageStorage.GetImage(ImageStorage.IngredientImageLocation, ii.Avatar));
            OnPropertyChanged(nameof(Filename));
        }

    }
}
