//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PriceDataLib
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        public Item()
        {
            this.Prices = new HashSet<Price>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemTypeId { get; set; }
    
        public virtual ItemType ItemType { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}
