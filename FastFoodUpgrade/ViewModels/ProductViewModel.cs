using FastFoodUpgrade.Commands.DragDropCommands;
using FastFoodUpgrade.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MongoDB.Bson;


namespace FastFoodUpgrade.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        // Product list view Itemsource
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> products
        {
            get { return _products; }
            set 
            { 
                _products = value;
                Search();
                OnPropertyChanged(nameof(products)); 
            }
        }
        // Order list view Itemsource
        private ObservableCollection<Order> _Odrs = new ObservableCollection<Order>();
        public ObservableCollection<Order> Odrs
        {
            get { return _Odrs; }
            set { _Odrs = value; OnPropertyChanged(nameof(Odrs)); }
        }
        // ProductType Combobox Itemsource
        private ObservableCollection<String> _types;
        public ObservableCollection<String> Types
        {
            get { return _types; }
        }
        // Search String in textbox
        private string _searchString;
        public string SearchString
        {
            get { return _searchString; }
            set { _searchString = value; Search(); }
        }
        // Selected item for drag&drop
        public Product SelectedItem { get; set; }
        //Product Type index from combobox 
        private int _selctedTypeIndex = -1;
        public int SelectedTypeIndex
        {
            get { return _selctedTypeIndex; }
            set { _selctedTypeIndex = value; OnPropertyChanged(nameof(SelectedTypeIndex)); }
        }


        // Drag & drop command
        public ICommand LeftMouseButtonDownCommand { get; set; }
        public ICommand DropProductCommand { get; set; }

        // Constructor
        public ProductViewModel()
        {
            LeftMouseButtonDownCommand = new MouseDownDrag(this);
            DropProductCommand = new DropCommand(this);

            DataProvider<Product> db = new DataProvider<Product>(Product.Collection);
            List<Product> QueryProducts = db.ReadAll();
            this._products = new ObservableCollection<Product>(QueryProducts);

            List<String> DistinctTypes = db.ReadDistinctString("Type");
            this._types = new ObservableCollection<String>(DistinctTypes);
        }

        private void Search()
        {
            List<Product> result = new List<Product>();

            if (!String.IsNullOrEmpty(SearchString))
            {
                DataProvider<Product> db = new DataProvider<Product>(Product.Collection);
                
                if (SelectedTypeIndex < 0)
                {
                    string searchInput = SearchString.ToLower().Trim();
                    FilterDefinition<Product> filter = Builders<Product>.Filter.Regex("Name", new BsonRegularExpression(searchInput,"i"));
                    result = db.ReadFiltered(filter);
                }
                else
                {
                    string searchInput = SearchString.ToLower().Trim();
                    FilterDefinition<Product> filter = Builders<Product>.Filter.Regex("Name", new BsonRegularExpression(searchInput, "i")) 
                        & Builders<Product>.Filter.Eq(p => p.Type, Types[SelectedTypeIndex]);
                    result = db.ReadFiltered(filter);
                }

            }
            products.Clear();
            foreach(Product p in result) { products.Add(p); }
        }


    }
}
