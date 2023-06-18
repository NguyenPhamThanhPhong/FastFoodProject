using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodUpgrade.ViewModels.ModelBase
{
    public class StaffvmBase : ViewModelBase
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(ID)); }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(nameof(UserName)); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(nameof(Phone)); }
        }
        private string _sex;
        public string Sex
        {
            get { return _sex; }
            set { _sex = value; OnPropertyChanged(nameof(Sex)); }
        }
        private string _accessRight;
        public string AccessRight
        {
            get { return _accessRight; }
            set { _accessRight = value; OnPropertyChanged(nameof(AccessRight)); }
        }
        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChanged(nameof(Address)); }
        }
        public string Avatar => this.ID + ".png";
    }
}
