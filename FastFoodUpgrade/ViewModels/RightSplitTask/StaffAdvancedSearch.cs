using FastFoodUpgrade.Commands.AdvancedSearchCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FastFoodUpgrade.ViewModels.RightSplitTask
{
    public class StaffAdvancedSearch : ViewModelBase
    {
        private string _name="";
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(this.Name)); }
        }
        private string _email="";
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(this.Email)); }
        }
        private string _accessRight ;
        public string AccessRight
        {
            get { return _accessRight; }
            set { _accessRight = value; OnPropertyChanged(nameof(this.AccessRight)); }
        }
        private string _gender = "";
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; OnPropertyChanged(nameof(this.Gender));}
        }
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(nameof(this.Phone)); }
        }
        public ICommand AdvancedSearchStaff { get; set; }
        public ManagingViewModel viewModel { get; set; }
        public StaffAdvancedSearch(ManagingViewModel viewmodel)
        {
            this.viewModel = viewmodel;
            this.AdvancedSearchStaff = new StaffAdvancedSearchCommand(this);
        }

    }
}
