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
    
    public partial class Order
    {
        public string ID { get; set; }
        public string BillID { get; set; }
        public string Productname { get; set; }
        public Nullable<int> sell { get; set; }
        public Nullable<int> price { get; set; }
        public Nullable<int> Discount { get; set; }
        public Nullable<int> Total { get; set; }
    
        public virtual Bill Bill { get; set; }
    }
}
