using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class ItemsContext : DbContext
    {
        public ItemsContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Item> Items { get; set; }
    }

    [Table("Item")]
    public class Item
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemTypeId { get; set; }        
    }
}