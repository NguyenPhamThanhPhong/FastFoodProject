using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FastFoodUpgrade.Commands.AdvancedSearchCommand;
using FastFoodUpgrade.Models;
using MongoDB.Driver;

namespace FastFoodUpgrade.ViewModels.RightSplitTask
{
    public class CustomerAdvancedSearch : ViewModelBase
    {
        private String _customerName;
        public String CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; OnPropertyChanged(nameof(CustomerName)); }
        }
        private String _phone;
        public String Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(nameof(Phone));}
        }
        private string _selectedRank;
        public string SelectedRank
        {
            get { return _selectedRank; }
            set { _selectedRank = value; OnPropertyChanged(nameof(_selectedRank)); }
        }
        private int _revenueFrom;
        public int RevenueFrom
        {
            get { return _revenueFrom; }
            set { _revenueFrom = value; OnPropertyChanged(nameof(RevenueFrom));}
        }
        private int _revenueTo;
        public int RevenueTo
        {
            get { return _revenueTo; }
            set { _revenueTo = value; OnPropertyChanged(nameof(RevenueTo)); }
        }
        //Commands
        public ICommand CustomerAdvancedSearchCommand { get; set; }
        public CustomerViewModel cvm;
        public CustomerAdvancedSearch(CustomerViewModel cvm) 
        {
            this.cvm = cvm;
            this.CustomerAdvancedSearchCommand = new CustomerAdvancedSearchCommand(this);
        }
    }
}
