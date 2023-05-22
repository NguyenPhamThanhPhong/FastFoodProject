using FastFoodUpgrade.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MongoDB.Bson;
using System.Windows;
using FastFoodUpgrade.ViewModels.RightSplitTask;

namespace FastFoodUpgrade.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value; OnPropertyChanged(nameof(Customers)); }
        }
        private string _searchString = "";
        public string SearchString
        {
            get { return _searchString; }
            set { _searchString = value;
                Search();
                OnPropertyChanged(nameof(SearchString)); }
        }
        public ObservableCollection<string> ComboBoxItems { get; set; } = new ObservableCollection<string>(new List<string>() {"ID","Name","Phone number"});
        private int _selectedIndex = 0;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex= value; Search(); OnPropertyChanged(nameof(SelectedIndex));}
        }
        public CustomerAdvancedSearch AdvancedSearchViewModel { get; set; }
        // Constructor-------
        public CustomerViewModel() 
        { 
            
        }
        // functions---------------
        public void UpdateCustomerList(List<Customer> customers)
        {
            this.Customers.Clear();
            foreach (Customer c in customers) 
            {
                Customers.Add(c);
            }
        }
        public static async Task<CustomerViewModel> Initialize()
        {
            CustomerViewModel viewModel = new CustomerViewModel();
            await viewModel.InitializeAsync();
            return viewModel;
        }
        private async Task InitializeAsync()
        {
            DataProvider<Customer> db = new DataProvider<Customer>(Customer.Collection);
            List<Customer> AllCustomers = await db.ReadAllAsync();
            this._customers = new ObservableCollection<Customer>(AllCustomers);
            this.AdvancedSearchViewModel = new CustomerAdvancedSearch(this);
        }
        // Search--------------------------
        private async void Search()
        {
            await Task.Run(() => {
                DataProvider<Customer> db = new DataProvider<Customer>(Customer.Collection);
                string searchInput = SearchString.Trim();
                List<Customer> results = new List<Customer>();
                switch (_selectedIndex)
                {
                    case 0:
                        {
                            FilterDefinition<Customer> filter = Builders<Customer>.Filter.Where(c => c.ID.ToString().Contains(searchInput));
                            results =  db.ReadFiltered(filter);
                            break;
                        }
                    case 1:
                        {
                            FilterDefinition<Customer> filter = Builders<Customer>.Filter.Regex("Fullname", new BsonRegularExpression(searchInput, "i"));
                            results = db.ReadFiltered(filter);
                        }
                        break;
                    case 2:
                        {
                             FilterDefinition<Customer> filter = Builders<Customer>.Filter.Regex("Phone", new BsonRegularExpression(searchInput, "i"));
                             results = db.ReadFiltered(filter);
                        }
                        break;
                    default:
                        return;
                }
                Application.Current.Dispatcher.Invoke(() => {
                    Customers.Clear();
                    foreach (Customer c in results)
                    {
                        Customers.Add(c);
                    }
                });
            });
        }


    }
}
