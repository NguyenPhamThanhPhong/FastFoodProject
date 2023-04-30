using FastFoodUpgrade.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodUpgrade.ViewModels.RightSplitTask
{
    public class ProductAdvancedSearch : ViewModelBase
    {
        // Name
        private string _searchName;
        public string SearchName
        {
            get { return _searchName; }
            set { _searchName = value; OnPropertyChanged(nameof(SearchName)); }
        }
        // Type List
        private ObservableCollection<String> _types;
        public ObservableCollection<String> Types
        {
            get { return _types; }
        }

        // Selected Type
        private int _searchTypeIndex;
        public int SearchTypeIndex
        {
            get { return _searchTypeIndex; }
            set { _searchTypeIndex = value; OnPropertyChanged(nameof(SearchTypeIndex)); }
        }
        // Price
        private int _priceFrom;
        public int PriceFrom
        {
            get { return _priceFrom; }
            set { _priceFrom = value; OnPropertyChanged(nameof(PriceFrom)); }
        } 

        private int _priceTo;
        
        public int PriceTo
        {
            get { return _priceTo; }
            set { _priceTo = value; OnPropertyChanged(nameof(PriceTo)); }
        }
        // Remaining
        private int _remainingQuantiy;
        public int RemainingQuantity
        {
            get { return _remainingQuantiy; }
            set { _remainingQuantiy = value; OnPropertyChanged(nameof(RemainingQuantity)); }
        }

        // Discount
        private float _discountAmountFrom;
        public float DiscountAmountFrom
        {
            get { return _discountAmountFrom; }
            set { _discountAmountFrom = value; OnPropertyChanged(nameof(DiscountAmountFrom)); }
        }
        private float _discountAmountTo;
        public float DiscountAmountTo
        {
            get { return _discountAmountTo; }
            set { _discountAmountTo = value; OnPropertyChanged(nameof(DiscountAmountTo)); }
        }
        public ProductViewModel pvm;
        public ProductAdvancedSearch(ProductViewModel pvm)
        {
            this.pvm = pvm;
            foreach(String str in pvm.Types)
            {
                this.Types.Add(str);
            }
        }
        public void DatabaseChangedTrigger()
        {
            OnPropertyChanged(nameof(Types));
        }

        private void Search()
        {
            //Task.Run(() => 
            //{
            //    string searchNameInput = SearchName.Trim();

            //    FilterDefinition<Product> filter = Builders<Product>.Filter.Regex("Name", new BsonRegularExpression( searchNameInput, "i"))
            //    & Builders<Product>.Filter.Eq()
            //    //DataProvider<Product> db = new DataProvider<Product>(Product.Collection);
            //    //FilterDefinition<Product> filter = Builders<Product>.Filter.Regex
            //    //db.ReadFiltered();
            //});
        }

    }
}
