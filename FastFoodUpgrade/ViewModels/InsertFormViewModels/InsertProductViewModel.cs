using FastFoodUpgrade.Commands;
using FastFoodUpgrade.Commands.InsertCommands;
using FastFoodUpgrade.Models;
using FastFoodUpgrade.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FastFoodUpgrade.ViewModels.InsertFormViewModels
{
    public class InsertProductViewModel : ViewModelBase
    {

        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value; 
                OnPropertyChanged("Name");
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

        private float _discountAmount = 0;
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
        private DateTime _startDate = DateTime.Today;
        public DateTime StartDate
        {
            get => _startDate;
            set { _startDate = value; OnPropertyChanged(nameof(StartDate)); }
        }
        private DateTime _expirationDate=DateTime.Today;
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
        public BitmapImage bmpp { get; set; } = new BitmapImage(new Uri("C:\\Users\\anhng\\OneDrive\\Máy tính\\ảnh\\NoAvatar.jpg"));
        private string _description="";
        public string Description
        { 
            get { return _description; } 
            set { _description = value; OnPropertyChanged(nameof(Description)); } 
        }
        //Avatar
        private StringBuilder _fileName = new StringBuilder("");
        public StringBuilder FileName
        {
            get => _fileName;
            set { _fileName = value; OnPropertyChanged(nameof(FileName));}
        }
        //COmmand
        public ICommand InsertCommand { get; set; }
        public ICommand SaveImageDialog { get; set; }
        public ICommand UpdateCommand { get; set; }
        // Constructor
        public InsertProductViewModel()
        {
            this.Name = "";
            this.Type = "";
            this.Description = "";
            this.Remaining = 0;
            this.Price = 0;
            this.DiscountAmount = 0f;
            this.ExpirationDate = DateTime.Today;

            this.InsertCommand = new InsertProductCommand(this,FileName);
            this.SaveImageDialog = new SaveImageDialogCommand(FileName,this);
        }
        public InsertProductViewModel(Product SelectedProduct)
        {
            this.Name = SelectedProduct.Name;
            this.Type = SelectedProduct.Type;
            this.Description = SelectedProduct.Description;
            this.Remaining = SelectedProduct.Remain;
            this.Price = SelectedProduct.Price;
            this.DiscountAmount = SelectedProduct.DiscountAmount.Value;
            this.StartDate = SelectedProduct.DiscountAmount.StartDate;
            this.ExpirationDate = SelectedProduct.DiscountAmount.EndDate;
            this.FileName.Clear();
            this.FileName.Append(ImageStorage.GetImage(ImageStorage.ProductImageLocation,SelectedProduct.Avatar));
            this.SaveImageDialog = new SaveImageDialogCommand(FileName, this);

        }
        public void RefreshForm()
        {
            this.Name = "";
            this.Type = "";
            this.Description = "";
            this.Remaining = 0;
            this.Price = 0;
            this.DiscountAmount = 0f;
            this.StartDate = DateTime.Today;
            this.ExpirationDate = DateTime.Today;
        }

        
    }
}
