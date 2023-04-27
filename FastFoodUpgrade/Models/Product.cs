using MongoDB.Bson.Serialization.Attributes;
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
        private string _id;
        public string Name { get; set; }
        public string Type { get; set; }

        public int Price { get; set; }
        public int Remain { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }
        public Discount DiscountAmount { get; set; }

        public static string Collection = "product";

    }
}
