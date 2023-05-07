using FastFoodUpgrade.Commands.InsertCommands;
using FastFoodUpgrade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FastFoodUpgrade.ViewModels.InsertFormViewModels
{
    public class InsertProductViewModel : ViewModelBase
    {
        public bool IsEnabled { get; set; }
        private bool _isNameCorrect = false;
        public bool IsNameCorrect
        {
            get { return _isNameCorrect; }
            set
            {
                _isNameCorrect= value;
                OnPropertyChanged(nameof(IsNameCorrect));
            }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value; 
                OnPropertyChanged("Name");
                Task.Run(() => {
                    IsNameCorrect = Product.IsNameConflict(value);
                });
            }
        }
        // Type

        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; OnPropertyChanged(nameof(Type)); }
        }
        private int _price;
        public int Price
        {
            get { return _price; }
            set 
            { 
                if (int.TryParse(value.ToString(),out int Myinteger))
                {
                    _price = Myinteger;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }
        private int _remaining;
        public int Remaining
        {
            get { return _remaining; }
            set
            {
                try
                {
                    if (int.TryParse(value.ToString(), out int Myinteger))
                    {
                        _remaining = Myinteger;
                        OnPropertyChanged(nameof(Remaining));
                    }
                }
                finally { OnPropertyChanged(nameof(Remaining)); }
            }
        }

        private float _discountAmount = 0f;
        public float DiscountAmount
        {
            get { return _discountAmount; }
            set 
            { 
                if(float.TryParse(value.ToString(), out float Myfloat))
                {
                    _discountAmount = Myfloat; 
                    OnPropertyChanged(nameof(DiscountAmount));
                }
                
            }
        }
        private DateTime _expirationDate;
        public DateTime ExpirationDate
        {
            get { return _expirationDate; }
            set
            {
                if (DateTime.TryParse(value.ToString(), out DateTime MyDate))
                {
                    _expirationDate = MyDate;
                    OnPropertyChanged(nameof(ExpirationDate));
                }

            }
        }
        private string _description;
        public string Description
        { 
            get { return _description; } 
            set { _description = value; OnPropertyChanged(nameof(Description)); } 
        }
        //Avatar
        private string _avatar;
        public string Avatar
        {
            get { return _avatar;}
            set { _avatar = value; OnPropertyChanged(nameof(Avatar));}
        }
        //COmmand
        public ICommand InsertCommand { get; set; }
        // Constructor
        public InsertProductViewModel()
        {
            this.IsEnabled = true;
            this.Name = "";
            this.Type = "";
            this.Description = "";
            this.Remaining = 0;
            this.Price = 0;
            this.DiscountAmount = 0f;
            this.ExpirationDate = DateTime.Today;
            this.InsertCommand = new InsertProductCommand(this);
        }
        public InsertProductViewModel(Product SelectedProduct)
        {
            this.IsEnabled = false;
            this.Name = SelectedProduct.Name;
            this.Type = SelectedProduct.Type;
            this.Description = SelectedProduct.Description;
            this.Remaining = SelectedProduct.Remain;
            this.Price = SelectedProduct.Price;
            this.DiscountAmount = SelectedProduct.DiscountAmount.Value;
            this.ExpirationDate = SelectedProduct.DiscountAmount.EndDate;
        }

        
    }
}
