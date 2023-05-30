using FastFoodUpgrade.Commands.AdvancedSearchCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FastFoodUpgrade.ViewModels.RightSplitTask
{
    public class BillAdvancedSearch : ViewModelBase
    {
        private string _customerName= "";
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; OnPropertyChanged(nameof(CustomerName)); }
        }
        private string _staffName = "";
        public string StaffName
        {
            get { return _staffName; }
            set { _staffName = value; OnPropertyChanged(nameof(StaffName)); }
        }
        private DateTime _dateFrom = DateTime.Today;
        public DateTime DateFrom
        {
            get { return _dateFrom; }
            set { _dateFrom = value; OnPropertyChanged(nameof(DateFrom)); }
        }
        private DateTime _dateTo = DateTime.Today;
        public DateTime DateTo
        {
            get => _dateTo;
            set { _dateFrom = value; OnPropertyChanged(nameof(DateTo)); }
        }
        private int _totalFrom = 0;
        public int TotalFrom
        {
            get { return _totalFrom; }
            set { _totalFrom = value; OnPropertyChanged(nameof(TotalFrom)); }
        }
        private int _totalTo = 0;
        public int TotalTo
        {
            get { return _totalTo; }
            set { _totalTo = value; OnPropertyChanged(nameof(TotalTo)); }
        }
        public ICommand BillAdvancedSearchCMD { get; set; }
        public BillViewModel CurrentBillViewModel { get; set; }
        public BillAdvancedSearch(BillViewModel bvm)
        {
            this.BillAdvancedSearchCMD = new BillAdvancedSearchCommand(this);
            CurrentBillViewModel = bvm;
        }

    }
}
