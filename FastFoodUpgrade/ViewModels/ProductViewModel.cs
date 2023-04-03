using FastFoodUpgrade.Commands.DragDropCommands;
using FastFoodUpgrade.Models;
using FastFoodUpgrade.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace FastFoodUpgrade.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private ObservableCollection<Product> _products = new ObservableCollection<Product>(new fastfooddtbEntities().Products);
        public ObservableCollection<Product> products
        {
            get{return _products;}
            set{_products = value;OnPropertyChanged(nameof(products));}
        }
        private ObservableCollection<Order> _Odrs = new ObservableCollection<Order>();
        public ObservableCollection<Order> Odrs
        {
            get { return _Odrs; }
            set { _Odrs = value; OnPropertyChanged(nameof(Odrs));}
        }
        public Product SelectedItem { get; set; }
        public ICommand LeftMouseButtonDownCommand { get; set; }
        public ICommand DropProductCommand { get; set; }
        public ProductViewModel()
        {
            LeftMouseButtonDownCommand = new MouseDownDrag(this);
            DropProductCommand = new DropCommand(this);
        }


    }
}
