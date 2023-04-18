using FastFoodUpgrade.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodUpgrade.ViewModels
{
    public class BillViewModel : ViewModelBase
    {
        private ObservableCollection<Customer> _customers = new ObservableCollection<Customer>(new fastfooddtbEntities().Customers);
        public ObservableCollection<Customer> Customers 
        { 
            get { return _customers; }
            set { _customers = value; OnPropertyChanged(nameof(Customers)); }
        }
        //Search string in textbox
        private string _searchString;
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
        // COmbobox

        private int _selectedFilterIndex = -1;
        public int SelectedFilterIndex
        {
            get { return _selectedFilterIndex; }
            set { _selectedFilterIndex = value; OnPropertyChanged(nameof(SelectedFilterIndex)); }
        }
        private void Search()
        {

        }
        public BillViewModel() { }
    }
}
