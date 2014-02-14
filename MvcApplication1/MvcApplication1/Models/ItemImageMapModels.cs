using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class ItemImageMapsContext : DbContext
    {
        public ItemImageMapsContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<ItemImageMap> ItemImageMaps { get; set; }
    }

    [Table("ItemImageMap")]
    public class ItemImageMap
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int SmallImageId { get; set; }
        public int OriginalImageId { get; set; }        
    }
}