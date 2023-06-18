using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FastFoodUpgrade.ViewModels.RightSplitTask
{
    public class IngredientAdvancedSearch : ViewModelBase
    {
        private string _id;
        public string ID
        {
            get => _id;
            set { _id = value; OnPropertyChanged(nameof(ID)); }
        }
        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; OnPropertyChanged(nameof(Type)); }
        }
        private string _unit;
        public string Unit
        {
            get => _unit;
            set { _unit = value; OnPropertyChanged(nameof(Unit)); }
        }
        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
        }
        public IngredientViewModel vm;
        public ICommand AdvancedSearchIngredient { get; set; }
            //Constructor
        public IngredientAdvancedSearch() { }
        public IngredientAdvancedSearch(IngredientViewModel vm) {
            this.vm = vm;
        }

    }
}
