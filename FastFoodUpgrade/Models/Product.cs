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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.DisplayProducts = new HashSet<DisplayProduct>();
        }
    
        public string ID { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Remaining { get; set; }
        public string Descript { get; set; }
        public string Avatar { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisplayProduct> DisplayProducts { get; set; }
    }
}