using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FastFoodUpgrade.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.Int64)]

        public int ID { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Rank { get; set; }
        public int Total { get; set; }
        public static string Collection = "customer";

        public static bool IsExisted(string Name,string Phone)
        {
            DataProvider<Customer> db = new DataProvider<Customer>(Customer.Collection);
            FilterDefinition<Customer> filter = Builders<Customer>.Filter.Eq(x => x.Fullname, Name)
                & Builders<Customer>.Filter.Eq(x => x.Phone, Phone);
            List<Customer> resultls = db.ReadFiltered(filter);
            return resultls.Count > 0;
        }
        public override string ToString()
        {
            if(this.Fullname !=null)
                return this.Fullname;
            return "";
        }
        public static Customer GetCustomerByName(string Name)
        {
            if(Name == null)
            {
                return null;
            }
            Customer c = new Customer();
            DataProvider<Customer> db = new DataProvider<Customer>(Customer.Collection);
            FilterDefinition<Customer> filter = Builders<Customer>.Filter.Eq(x => x.Fullname, Name);
            List<Customer> customers = db.ReadFiltered(filter);
            if(customers.Count > 0)
            {
                return customers[0];
            }else
                return null;
        }
    }
}
