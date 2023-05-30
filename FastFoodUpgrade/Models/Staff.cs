using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace FastFoodUpgrade.Models
{
    public class Staff
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.Int64)]

        public int ID { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string AccessRight { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public static string Collection = "staff";
        public Staff ()
        {
        }
        public static async Task<int> GenerateID()
        {
            DataProvider<Staff> db = new DataProvider<Staff>(Collection);
            List<Staff> staffs = await db.ReadAllAsync();
            return staffs.Count + 1;
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
