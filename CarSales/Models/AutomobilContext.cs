using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CarSales.Models
{
    public class AutomobilContext : DbContext
    {
        public virtual DbSet<Automobil> Automobili { get; set; }
    }
}