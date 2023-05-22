using FastFoodUpgrade.Commands.DragDropCommands;
using FastFoodUpgrade.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MongoDB.Bson;
using System.Threading.Tasks;
using System.Windows;
using FastFoodUpgrade.Views.SplitTaskTable;
using FastFoodUpgrade.ViewModels.RightSplitTask;

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
            set { _searchString = value; OnPropertyChanged(nameof(SearchString)); Search(); }
        }
        // Selected item for drag&drop
        public Product SelectedItem { get; set; }
        //Product Type index from combobox 
        private int _selctedTypeIndex = -1;
        public int SelectedTypeIndex
        {
            get { return _selctedTypeIndex; }
            set 
            { 
                _selctedTypeIndex = value; 
                Search(); 
                OnPropertyChanged(nameof(SelectedTypeIndex)); 
            }
        }


        // Drag & drop command
        public ICommand LeftMouseButtonDownCommand { get; set; }

        // Split Table DataContext
        public ProductAdvancedSearch SplitTableDataContext { get; }

        // Constructor
        public ProductViewModel()
        {
            LeftMouseButtonDownCommand = new MouseDownDrag(this);

            DataProvider<Product> db = new DataProvider<Product>(Product.Collection);
            List<Product> QueryProducts = db.ReadAll();
            this._products = new ObservableCollection<Product>(QueryProducts);

            List<String> DistinctTypes = db.ReadDistinctString("Type");
            this._types = new ObservableCollection<String>(DistinctTypes);

            this.SplitTableDataContext = new ProductAdvancedSearch(this);
        }
        public void DatabaseChangedTrigger()
        {
            DataProvider<Product> db = new DataProvider<Product>(Product.Collection);
            List<Product> QueryProducts = db.ReadAll();
            products.Clear();
            foreach(Product item in QueryProducts)
            {
                products.Add(item);
            }
            List<String> DistinctTypes = db.ReadDistinctString("Type");
            this.Types.Clear();
            foreach(String type in DistinctTypes)
            {
                this.Types.Add(type);
            }
            OnPropertyChanged(nameof(Types));
            OnPropertyChanged(nameof(products));
        }
        public void UpdateListViewResult(List<Product> p)
        {
            this.products.Clear();
            foreach(Product pp in p)
            {
                products.Add(pp);
            }
        }

        private async void Search()
        {
            await Task.Run(() => 
            {
                List<Product> result = new List<Product>();

                if (SearchString!=null)
                {
                    DataProvider<Product> db = new DataProvider<Product>(Product.Collection);

                    if (SelectedTypeIndex < 0)
                    {
                        string searchInput = SearchString.Trim();
                        FilterDefinition<Product> filter = Builders<Product>.Filter.Regex("Name", new BsonRegularExpression(searchInput, "i"));
                        result = db.ReadFiltered(filter);
                    }
                    else
                    {
                        string searchInput = SearchString.Trim();
                        FilterDefinition<Product> filter = Builders<Product>.Filter.Regex("Name", new BsonRegularExpression(searchInput, "i"))
                            & Builders<Product>.Filter.Eq(p => p.Type, Types[SelectedTypeIndex]);
                        result = db.ReadFiltered(filter);
                    }

                }
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Task.Delay(500);
                    products.Clear();
                    foreach (Product p in result) { products.Add(p); }
                });


            });

        }


    }
}
