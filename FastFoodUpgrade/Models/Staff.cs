using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastFoodUpgrade.ViewModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace FastFoodUpgrade.Models
{
    public class Staff : ViewModelBase
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.Int64)]

        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; 
                _avatar = _id.ToString() + ".png"; 
                OnPropertyChanged(nameof(ID)); }
        }
        private string _fullname="";
        public string Fullname
        {
            get { return _fullname; }
            set { _fullname = value; OnPropertyChanged(nameof(Fullname)); }
        }
        private string _userName="";
        public string Username
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(nameof(Username)); }
        }
        private string _password="";
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }
        private string _email = "";
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }
        private string _avatar;
        public string Avatar
        {
            get { return _avatar; }
            set { _avatar = value; OnPropertyChanged(nameof(Avatar));}
        }
        private string _accessRight = "";
        public string AccessRight
        {
            get { return _accessRight; }
            set { _accessRight = value; OnPropertyChanged(nameof(AccessRight)); }
        }
        private string _sex = "";
        public string Sex
        {
            get { return _sex; }
            set { _sex = value; OnPropertyChanged(nameof(Sex)); }
        }
        private string _phone = "";
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(nameof(Phone)); }
        }
        private string _address = "";
        public string Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChanged(nameof(Address)); }
        }
        public static string Collection = "staff";
        public Staff ()
        {
        }
        public static async Task<int> GenerateID()
        {
            DataProvider<Staff> db = new DataProvider<Staff>(Collection);
            FilterDefinition<Staff> filter = Builders<Staff>.Filter.Empty;
            var sort = Builders<Staff>.Sort.Ascending("ID");
            List<int> AllID = db.collection.Find(x => true).Project(x => x.ID).SortBy(x => x.ID).ToList();
            int smallestMissingNumber = 1;

            foreach (int number in AllID)
            {
                if (number == smallestMissingNumber)
                {
                    smallestMissingNumber++;
                }
                else if (number > smallestMissingNumber)
                {
                    break;
                }
            }

            return smallestMissingNumber;

        }
        public static async Task<bool> IsExisted(string userName)
        {
            DataProvider<Staff> db = new DataProvider<Staff>(Collection);
            
            List<string> str = await db.collection.Distinct<string>("Username", Builders<Staff>.Filter.Empty).ToListAsync();
            foreach (string s in str )
            {
                if (s.Trim().Equals(userName))
                    return true;
            }
            return false;
        }
    }
}
