using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSaleAPI.Entities
{
    public class HddItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HddSize { get; set; }
        public string SideNotation { get; set; }// set to determine if Terabytes or gigabytes
        public decimal Cost { get; set; }
    }
}
