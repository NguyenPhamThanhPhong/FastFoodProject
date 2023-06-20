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
        // List orderssss
        private ObservableCollection<Order> _odrs = new ObservableCollection<Order>();
        public ObservableCollection<Order> Odrs
        {
            get { return _odrs; }
            set { _odrs = value;  OnPropertyChanged(nameof(Odrs)); }
        }
        //ID
        private int _billID;
        public int BillID
        {
            get { return _billID; }
            set { _billID = value; OnPropertyChanged(nameof(BillID)); }
        }
        //List customer
        private ObservableCollection<Customer> _customerPurchaserList;
        public ObservableCollection<Customer> CustomerPurchaserList
        {
            get { return _customerPurchaserList; }
            set { _customerPurchaserList = value; OnPropertyChanged(nameof(CustomerPurchaserList)); }
        }
        //Find customer
        private bool _isDropDownOpen=false;
        public bool IsDropDownOpen
        {
            get => _isDropDownOpen;
            set { _isDropDownOpen = value; OnPropertyChanged(nameof(IsDropDownOpen)); }
        }
        public List<Customer> currentCustomers;
        private string _customerName="";
        public string CustomerName
        {
            get => _customerName;
            set { _customerName = value; SearchCustomer(); IsDropDownOpen = true; OnPropertyChanged(nameof(CustomerName)); }
        }
        // Staff
        private Staff _saleStaff;
        public Staff SaleStaff
        {
            get { return _saleStaff; }
            set { _saleStaff = value; OnPropertyChanged(nameof(SaleStaff)); }
        }
        private float _discountAmount=0;
        public float DiscountAmount
        {
            get { return _discountAmount; }
            set { _discountAmount = value; OnPropertyChanged(nameof(DiscountAmount));  }
        }
        private int _total=0;
        public int Total
        {
            get { return _total; }
            set { _total = value; OnPropertyChanged(nameof(Total)); }
        }
        private float _payment;
        public float Payment 
        { 
            get => _payment;
            set { _payment = value; OnPropertyChanged(nameof(Payment)); }
        }
        public Product SelectedProduct;
        //command
        
        public ICommand DropProductCommand { get; set; }
        public ICommand InsertOneBillCommand { get; set; }

        public InsertBillViewModel()
        {
        }
        public InsertBillViewModel(Bill b)
        {
            _billID = b.ID;
            CustomerName = b.CustomerPurchaser.Fullname;
            SaleStaff = b.SaleStaff;
            DiscountAmount = b.DiscountAmount;
            Total = b.Total;
            this.CustomerPurchaserList = new ObservableCollection<Customer>(new List<Customer>());
            Payment = b.Total*(100-b.DiscountAmount)/100;
            foreach(var o in b.Orders)
            {
                this.Odrs.Add(o);
            }
            IsDropDownOpen = false;
        }
        public static async Task<InsertBillViewModel> CreateAsync(Staff CurrentWorkingStaff)
        {
            InsertBillViewModel viewModel = new InsertBillViewModel();
            await viewModel.InitializeAsync(CurrentWorkingStaff);
            return viewModel;
        }

        private async Task InitializeAsync(Staff CurrentWorkingStaff)
        {
            await Task.Run(async () =>
            {

                DataProvider<Bill> db = new DataProvider<Bill>(Bill.Collection);

                DataProvider<Customer> dbCustomer = new DataProvider<Customer>(Customer.Collection);
                List<Customer> AllCustomers = await dbCustomer.ReadAllAsync();

                this.currentCustomers = AllCustomers;
                BillID = db.ReadAll().Count + 1;
                CustomerPurchaserList = new ObservableCollection<Customer>(AllCustomers);
                SaleStaff = CurrentWorkingStaff;
                DiscountAmount = 0;

                DropProductCommand = new DropCommand(Odrs,this);
                this.InsertOneBillCommand = new InsertBillCommand(this);


                //BillID = db.ReadAll().Count;
            });
        }
        public void SearchCustomer()
        {
            if (CustomerPurchaserList != null)
            {
                this.CustomerPurchaserList.Clear();
                foreach (var c in currentCustomers)
                {
                    if (c.Fullname.Trim().ToLower().Contains(_customerName.Trim().ToLower()))
                    {
                        CustomerPurchaserList.Add(c);
                    }
                }
            }

        }
        public void UpdateTotal()
        {
            this.Total = 0;
            foreach(Order o in Odrs)
            {
                this.Total += o.Total;
            }
            this.Payment = Total * (100 - DiscountAmount) / 100;
        }
    }
}
