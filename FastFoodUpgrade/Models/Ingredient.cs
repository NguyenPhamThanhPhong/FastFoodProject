//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FastFoodUpgrade.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ingredient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ingredient()
        {
            this.ImportListings = new HashSet<ImportListing>();
        }
    
        public string ID { get; set; }
        public string IngredientName { get; set; }
        public string IngredientType { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> Remaining { get; set; }
        public string Descript { get; set; }
        public string Avatar { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportListing> ImportListings { get; set; }
    }
}
