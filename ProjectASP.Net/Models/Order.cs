//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectASP.Net.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public Order()
        {
            this.ProductDetails = new HashSet<ProductDetail>();
        }
    
        public int Id { get; set; }
        public int UserId { get; set; }
        public Nullable<double> OrderAmount { get; set; }
        public Nullable<double> OrderPrice { get; set; }
    
        public virtual User User { get; set; }
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
