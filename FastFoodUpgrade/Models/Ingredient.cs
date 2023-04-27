using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodUpgrade.Models
{
    public class Ingredient
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        private string _id;
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Price { get;set; }
        public float Unit { get; set; }
        public int Quantity { get; set; }
        public string Avatar { get;set; }
        public static string Collection = "ingredient";
        public Ingredient() 
        { 
        }
    }
}
