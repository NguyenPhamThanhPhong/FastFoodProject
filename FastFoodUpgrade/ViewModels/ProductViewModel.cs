using FastFoodUpgrade.Commands.DragDropCommands;
using FastFoodUpgrade.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;


namespace FastFoodUpgrade.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        // Product list view Itemsource
        private ObservableCollection<Product> _products = new ObservableCollection<Product>(new fastfooddtbEntities().Products);
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
        private ObservableCollection<String> _types = new ObservableCollection<String>(new fastfooddtbEntities().Products.Select(p=>p.ProductType).Distinct());
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
            
        }

        private void Search()
        {
            List<Product> result = new List<Product>();

            if (!String.IsNullOrEmpty(SearchString))
            {
                using (fastfooddtbEntities db = new fastfooddtbEntities())
                {
                    if(SelectedTypeIndex < 0)
                    {
                        result = db.Products.Where(p => p.ProductName.ToLower().Contains(SearchString)).ToList();
                    }
                    else
                    {
                        result = db.Products.Where(p => p.ProductName.ToLower().Contains(SearchString) && p.ProductType == Types[SelectedTypeIndex]).ToList();
                    }
                }
            }
            products.Clear();
            foreach(Product p in result) { products.Add(p); }
        }


    }
}
