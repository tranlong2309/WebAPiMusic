using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMusicEntities.Models
{
    public class Category:BaseEntity
    {
        public string NameCategory { get; set; }
        public string ImageCategory { get; set; }
        public ICollection<TheSong> TheSongs { get; set; }
    }
}
