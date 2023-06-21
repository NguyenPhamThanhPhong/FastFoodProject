using FastFoodUpgrade.Models;
using FastFoodUpgrade.ViewModels.RightSplitTask;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace FastFoodUpgrade.ViewModels
{
    public class BillViewModel : ViewModelBase
    {
        private ObservableCollection<Bill> _bills = new ObservableCollection<Bill>();
        public ObservableCollection<Bill> Bills
        { 
            get { return _bills; }
            set { _bills = value; OnPropertyChanged(nameof(Bills)); }
        }
        //Search string in textbox
        private string _searchString="";
        public string SearchString
        {
            get { return _searchString; }
            set
            {
                _searchString = value;
                Search();
                OnPropertyChanged(nameof(SearchString));
            }
        }
        private int _selectedFilterIndex = 0;
        public int SelectedFilterIndex
        {
            get { return _selectedFilterIndex; }
            set { _selectedFilterIndex = value; Search(); OnPropertyChanged(nameof(SelectedFilterIndex)); }
        }
        public BillAdvancedSearch BillAdvancedSearchViewModel { get; set; }
        // COmbobox
        public static async Task<BillViewModel> Initialize()
        {
            BillViewModel viewmodel = new BillViewModel();
            await viewmodel.IntializeAsync();
            return viewmodel;
        }
        private async Task IntializeAsync()
        {
            DataProvider<Bill> db = new DataProvider<Bill>(Bill.Collection);
            this.Bills = new ObservableCollection<Bill>( await db.ReadAllAsync());
            BillAdvancedSearchViewModel = new BillAdvancedSearch(this);
        }


        private async void Search()
        {
            List<Bill> results = new List<Bill>();
            string searchInput = SearchString.Trim().ToLower();
            DataProvider<Bill> db = new DataProvider<Bill>(Bill.Collection);
            await Task.Run(async () =>
            {
                switch(_selectedFilterIndex)
                {
                    case 0:
                        {
                            FilterDefinition<Bill> filter = Builders<Bill>.Filter.Where(b => b.ID.ToString().Contains(searchInput));
                            results = await db.ReadFilteredAsync(filter);
                            break;
                        }

                    case 1:
                        {
                            FilterDefinition<Bill> filter = Builders<Bill>.Filter.Where(b => b.CustomerPurchaser.Fullname.ToLower().Contains(searchInput));
                            results = await db.ReadFilteredAsync(filter);
                            break;
                        }
                    case 2:
                        {
                            FilterDefinition<Bill> filter = Builders<Bill>.Filter.Where(b => b.SaleStaff.Fullname.ToLower().Contains(searchInput));
                            results = await db.ReadFilteredAsync(filter);
                            break;
                        }
                    case 3:
                        {
                            if(!int.TryParse(searchInput, out int TotalValue))
                            {
                                return;
                            }
                            FilterDefinition<Bill> filter = Builders<Bill>.Filter.Where(b => b.Total> TotalValue);
                            results = await db.ReadFilteredAsync(filter);
                            break;
                        }
                    default: return;

                }
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Bills.Clear();
                    foreach(Bill b in results) 
                    {
                        Bills.Add(b);
                    }

                });
            });
        }
        public void UpdateBillList(List<Bill> bs)
        {
            Bills.Clear();
            foreach(Bill b in bs) 
            {
                Bills.Add(b);
            }
        }

    }
}
