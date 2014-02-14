using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class ItemTypesContext : DbContext
    {
        public ItemTypesContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<ItemType> ItemTypes { get; set; }
    }

    [Table("ItemType")]
    public class ItemType
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Parent { get; set; }        
    }
}