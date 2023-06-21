using FastFoodUpgrade.Commands.AdvancedSearchCommand;
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
        private string _type = "";
        public string Type
        {
            get { return _type; }
            set { _type = value; OnPropertyChanged(nameof(Type)); }
        }
        private string _unit = "";
        public string Unit
        {
            get => _unit;
            set { _unit = value; OnPropertyChanged(nameof(Unit)); }
        }
        private int _quantityFrom =0;
        public int QuantityFrom
        {
            get => _quantityFrom;
            set { _quantityFrom = value; OnPropertyChanged(nameof(QuantityFrom)); }
        }
        private int _quantityTo=999999;
        public int QuantityTo
        {
            get => _quantityTo;
            set { _quantityTo= value; OnPropertyChanged(nameof(QuantityTo)); }
        }
        public IngredientViewModel vm { get; set; }
        public ICommand AdvancedSearchIngredient { get; set; }
            //Constructor
        public IngredientAdvancedSearch() { }
        public IngredientAdvancedSearch(IngredientViewModel vm) {
            this.vm = vm;
            this.AdvancedSearchIngredient = new IngredientAdvancedSearchCommand(this);
        }

    }
}
