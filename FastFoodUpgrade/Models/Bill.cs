using FastFoodUpgrade.ViewModels;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodUpgrade.Models
{
    public class Bill : ViewModelBase
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.Int64)]

        public int ID { get; set; }
        public Customer CustomerPurchaser  { get; set; }
        public Staff SaleStaff { get; set; }    
        public DateTime BillDate { get; set; }
        public float DiscountAmount { get; set; }
        public int Total { get; set; }
        public List<Order>  Orders { get; set; }

        public static string Collection = "bill";

    }
}
