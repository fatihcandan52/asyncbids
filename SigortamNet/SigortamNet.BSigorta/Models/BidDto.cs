using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SigortamNet.BSigorta.Models
{
    public class BidDto
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string LicensePlate { get; set; }
    }
}
