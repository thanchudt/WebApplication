using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class PricesContext : DbContext
    {
        public PricesContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Price> Prices { get; set; }
    }

    [Table("Price")]
    public class Price
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Value { get; set; }
        public int CurrencyId { get; set; }
        public int UploadBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime EffStartDate { get; set; }
        public DateTime EffEndDate { get; set; }
    }
}