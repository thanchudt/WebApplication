using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class CurrenciesContext : DbContext
    {
        public CurrenciesContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Currency> Currencies { get; set; }
    }

    [Table("Currency")]
    public class Currency
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }        
    }
}