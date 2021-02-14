using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PointOfSaleAPI.Entities;

namespace PointOfSaleAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<SalesItem> SalesItems { get; set; }
        public DbSet<HddItem> HddItems { get; set; }
        public DbSet<RamItem> RamItems { get; set; }
        public DbSet<ColorSelection> ColorSelections { get; set; }
        public DbSet<LaptopItem> LaptopItems { get; set; }

        public DataContext(DbContextOptions options)
        : base(options)
        {
            
        }

    }
}
