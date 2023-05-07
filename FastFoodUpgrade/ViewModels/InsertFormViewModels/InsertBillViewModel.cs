using FastFoodUpgrade.Commands.DragDropCommands;
using FastFoodUpgrade.Commands.InsertCommands;
using FastFoodUpgrade.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FastFoodUpgrade.ViewModels.InsertFormViewModels
{
    public class InsertBillViewModel : ViewModelBase
    {
        private ObservableCollection<Order> _odrs = new ObservableCollection<Order>();
        public ObservableCollection<Order> Odrs
        {
            get { return _odrs; }
            set { _odrs = value;  OnPropertyChanged(nameof(Odrs)); }
        }
        private int _billID;
        public int BillID
        {
            get { return _billID; }
            set { _billID = value; OnPropertyChanged(nameof(BillID)); }
        }
        private ObservableCollection<Customer> _customerPurchaserList;
        public ObservableCollection<Customer> CustomerPurchaserList
        {
            get { return _customerPurchaserList; }
            set { _customerPurchaserList = value; OnPropertyChanged(nameof(CustomerPurchaserList)); }
        }
        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { _selectedCustomer = value; OnPropertyChanged(nameof(SelectedCustomer)); }
        }
        private Staff _saleStaff;
        public Staff SaleStaff
        {
            get { return _saleStaff; }
            set { _saleStaff = value; OnPropertyChanged(nameof(SaleStaff)); }
        }
        private float _discountAmount;
        public float DiscountAmount
        {
            get { return _discountAmount; }
            set { _discountAmount = value; OnPropertyChanged(nameof(DiscountAmount));  }
        }
        private int _total;
        public int Total
        {
            get { return _total; }
            set { _total = value; OnPropertyChanged(nameof(Total)); }
        }
        public Product SelectedProduct;
        //command
        
        public ICommand DropProductCommand { get; set; }
        public ICommand InsertOneBillCommand { get; set; }

        public InsertBillViewModel()
        {

        }
        public static async Task<InsertBillViewModel> CreateAsync(Staff CurrentWorkingStaff)
        {
            InsertBillViewModel viewModel = new InsertBillViewModel();
            await viewModel.InitializeAsync( CurrentWorkingStaff);
            return viewModel;
        }

        private async Task InitializeAsync(Staff CurrentWorkingStaff)
        {
            await Task.Run(async () =>
            {

                DataProvider<Bill> db = new DataProvider<Bill>(Bill.Collection);

                DataProvider<Customer> dbCustomer = new DataProvider<Customer>(Customer.Collection);
                List<Customer> AllCustomers = await dbCustomer.ReadAllAsync();


                BillID = db.ReadAll().Count + 1;
                CustomerPurchaserList = new ObservableCollection<Customer>(AllCustomers);
                SaleStaff = CurrentWorkingStaff;
                DiscountAmount = 0;

                DropProductCommand = new DropCommand(Odrs);
                this.InsertOneBillCommand = new InsertBillCommand(this);


                //BillID = db.ReadAll().Count;
            });


        }
    }
}
