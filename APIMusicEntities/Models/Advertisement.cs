using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMusicEntities.Models
{
    public class Advertisement:BaseEntity
    {
        public string NameAdvertisement { get; set; }
        public string ImageAdvertisement { get; set; }
        public int IdAdvertisementOfTheSong { get; set; }
        public TheSong TheSong { get; set; }
    }
}
