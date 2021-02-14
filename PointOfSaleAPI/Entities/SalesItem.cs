using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSaleAPI.Entities
{
    public class SalesItem
    {
        public int Id { get; set; }
        public int LaptopId { get; set; }
        public int RamId { get; set; } 
        public int HddId { get; set; }
        public int ColorId { get; set; }
        public decimal CostExcVat { get; set; }
        public decimal CostIncVat { get; set; }

        public virtual LaptopItem Laptop { get; set; }
        public virtual HddItem Hdd { get; set; }
        public virtual RamItem Ram { get; set; }
        public virtual ColorSelection Color { get; set; }



    }
}
