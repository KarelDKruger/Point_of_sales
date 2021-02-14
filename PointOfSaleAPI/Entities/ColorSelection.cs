using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSaleAPI.Entities
{
    public class ColorSelection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HexCode { get; set; }
        public decimal Cost { get; set; }
    }
}
