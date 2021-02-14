using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSaleAPI.Entities
{
    public class RamItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RamSize { get; set; } // all ram is in GB for now
        public string RamGeneration { get; set; } // set to store ddr3->ddr4 etc
        public decimal Cost { get; set; }
    }
}
