using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodUpgrade.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.Int64)]

        public int ID { get; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Rank { get; set; }
        public int Total { get; set; }
        public static string Collection = "customer";



    }
}
