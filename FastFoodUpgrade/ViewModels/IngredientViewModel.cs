using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels.RightSplitTask;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastFoodUpgrade.ViewModels
{
    public class IngredientViewModel : ViewModelBase
    {
        private ObservableCollection<Ingredient> _ingredients;
        public ObservableCollection<Ingredient> Ingredients
        {
            get { return _ingredients; }
            set { _ingredients = value; OnPropertyChanged(nameof(Ingredients)); }
        }
        // Distinct Ingredient types
        private ObservableCollection<string> _types ;
        public ObservableCollection<string> Types
        {
            get { return _types; }
        }
        // Search String in textbox
        private string _searchString="";
        public string SearchString
        {
            get { return _searchString; }
            set { _searchString = value; Search(); OnPropertyChanged(nameof(SearchString)); }
        }
        // COmbobox
        private int _selectedFilterIndex = 0;
        public int SelectedFilterIndex
        {
            get { return _selectedFilterIndex; }
            set { _selectedFilterIndex = value;Search(); OnPropertyChanged(nameof(SelectedFilterIndex)); }
        }
        public IngredientAdvancedSearch currentAdvancedSearch { get; set; }
        //Initializer instead of constructor
        public static async Task<IngredientViewModel> Initialize()
        {
            IngredientViewModel viewmodel = new IngredientViewModel();
            await viewmodel.InitializeAsync();
            return viewmodel;
        }
        private async Task InitializeAsync()
        {
            DataProvider<Ingredient> db = new DataProvider<Ingredient>(Ingredient.Collection);
            List<Ingredient> ingr = await db.ReadAllAsync();
            Ingredients = new ObservableCollection<Ingredient>(ingr);

            List<String> distinctTypes = db.ReadDistinctString("Type");
            distinctTypes.Insert(0, "All");
            _types = new ObservableCollection<string>(distinctTypes);
            this.currentAdvancedSearch = new IngredientAdvancedSearch(this);
        }

        private async void Search()
        {
            await Task.Run(() =>
            {
                DataProvider<Ingredient> db = new DataProvider<Ingredient>(Ingredient.Collection);
                string searchInput = SearchString.Trim().ToLower();
                List<Ingredient> result = new List<Ingredient>();
                if (SelectedFilterIndex <= 0)
                {
                    FilterDefinition<Ingredient> filter = Builders<Ingredient>.Filter.Where(x => x.Name.Trim().ToLower().Contains(searchInput));
                    result = db.ReadFiltered(filter);
                }
                else
                {
                    FilterDefinition<Ingredient> filter = Builders<Ingredient>.Filter.Where(
                        x => x.Name.Trim().ToLower().Contains(searchInput)
                        && x.Type.Trim().ToLower().Equals(Types[SelectedFilterIndex]));
                    result = db.ReadFiltered(filter);

                }
                Application.Current.Dispatcher.Invoke(() =>
                {
                    UpdateListIngredients(result);
                });

            });
        } 
        public void UpdateListIngredients(List<Ingredient> result)
        {
            _ingredients.Clear();
            foreach(var ingredient in result)
            {
                Ingredients.Add(ingredient);
            }
        }
        public void RefreshPage(List<Ingredient> result,List<string> distinctTypes)
        {
            _ingredients.Clear();
            foreach (var ingredient in result)
            {
                Ingredients.Add(ingredient);
            }
            _types.Clear();
            foreach(var distinct in distinctTypes )
            {
                _types.Add(distinct);
            }
        }
    }
}
