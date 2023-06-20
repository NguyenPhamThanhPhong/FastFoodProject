using FastFoodUpgrade.ViewModels;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodUpgrade.Models
{
    public class Order : ViewModelBase
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get;}
        public Product Merchandise { get; set; }
        public int SellAmount { get; set; }
        public Discount DiscountAmount { get; set; }
        public int Total { get; set; }

    }
}
