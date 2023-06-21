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
    public class InsertCustomerViewModel : ViewModelBase
    {
        private Int32 _id;
        public Int32 ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(ID)); }
        }
        private String _name = "";
        public String Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        private String _phone="";
        public String Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(nameof(Phone));}
        }
        private String _address = "";
        public String Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChanged(nameof(Address));}
        }
        public ICommand InsertCustomer { get; set; }

        public static async Task<InsertCustomerViewModel> Initialize()
        {
            var viewModel = new InsertCustomerViewModel();
            await viewModel.IntializeAsync();
            return viewModel;
        }
        private async Task IntializeAsync ()
        {
            await Task.Run(() => {
                ID = Customer.CreateID();
                InsertCustomer = new InsertCustomerCommand(this);
            });
        }
    }
}
