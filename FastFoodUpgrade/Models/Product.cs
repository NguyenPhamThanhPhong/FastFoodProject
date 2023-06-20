using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodUpgrade.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id;
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Remain { get; set; }
        public string Description { get; set; }
        public string Avatar{ get; set; }
        public Discount DiscountAmount { get; set; }

        public static string Collection = "product";
        public static bool IsNameConflict(string name)
        {

            DataProvider<Product> db = new DataProvider<Product>(Product.Collection);
            FilterDefinition<Product> filter = Builders<Product>.Filter.Empty;
            ProjectionDefinition<Product> projection = Builders<Product>.Projection.Include(x => x.Name);
            IMongoCollection<Product> collection = db.collection;
            List<string> Names = db.collection.Find(filter).ToList().Select(x => x.Name).ToList();
            List<string> abcd = Names;
            foreach(string x in Names) 
            { 
                if(name.Trim().ToLower().Equals(x.Trim().ToLower()))
                { return true; }
            }
            return false;
        }
        public Product ()
        {
            Avatar = "abc";
        }
        public static bool IsTypeExist(string name)
        {
            DataProvider<string> db = new DataProvider<string>(Product.Collection);
            FilterDefinition<string> filter = Builders<string>.Filter.Empty;
            ProjectionDefinition<Product> projection = Builders<Product>.Projection.Include(x => x.Name);
            List<string> distinctType = db.collection.Distinct<string>("Type", filter).ToList();
            foreach (string type in distinctType)
            {
                if (name.Trim().ToLower().Equals(type.Trim().ToLower()))
                { return true; }
            }
            return false;
        }
        public bool IsValid()
        {
            if(String.IsNullOrEmpty(Name)
                || String.IsNullOrEmpty(Type)
                || Price < 0
                || Remain < 0
                || DiscountAmount.Value <0
                || DiscountAmount.Value >100
                || Description == null
                || Avatar == null)
            {
                return false;
            }
            return true;
        }

    }
}
