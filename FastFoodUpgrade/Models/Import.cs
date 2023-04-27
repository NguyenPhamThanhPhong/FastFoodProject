using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodUpgrade.Models
{
    public class Import
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.Int64)]
        public int ID { get; }
        public Staff Admin { get; set; }
        public DateTime ImportDate { get; set; }
        public int Total { get;set; }
        public List<Ingredient> ImportedIngredients { get; set; }

        public static string Collection = "import";

    }
}
