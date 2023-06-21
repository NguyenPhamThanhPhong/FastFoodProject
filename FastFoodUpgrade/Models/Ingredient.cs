using FastFoodUpgrade.ViewModels;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastFoodUpgrade.Models
{
    public class Ingredient : ViewModelBase
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        private string _id;
        public string ID
        {
            get => _id;
            set { _id = value;_avatar =_id + ".png"; OnPropertyChanged(nameof(ID)); }
        }
        private string _name="";
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        private string _description="";
        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }
        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; OnPropertyChanged(nameof(Type)); }
        }
        private string _unit="";
        public string Unit
        {
            get => _unit;
            set { _unit = value; OnPropertyChanged(nameof(Unit)); }
        }
        private int _quantity=0;
        public int Quantity
        {
            get => _quantity;
            set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
        }
        private string _avatar;
        public string Avatar
        {
            get => _avatar;
            set { _avatar = value;OnPropertyChanged(nameof(Avatar)); }
        }
        public static string Collection = "ingredient";
        public async Task< bool> IsValid()
        {
            return await Task.Run(async () =>
            {
                if (String.IsNullOrEmpty(this.Name) || await this.IsExisted())
                {
                    MessageBox.Show("invalid name");
                    return false;

                }
                if (Quantity < 0)
                {
                    MessageBox.Show("invalid Quantity");
                    return false;
                }
                return true;
            });
        }
        public async Task<bool> IsExisted()
        {
            return await Task.Run(() =>
            {
                DataProvider<Ingredient> db = new DataProvider<Ingredient>(Collection);
                FilterDefinition<Ingredient> filter = Builders<Ingredient>.Filter.Where(x => x.Name == Name);
                List<Ingredient> check = db.ReadFiltered(filter);
                if(check.Count > 0) { return true; }
                return false;
            });

        }
    }
}
