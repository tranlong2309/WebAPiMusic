using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMusicEntities.Models
{
    public class Album:BaseEntity
    {
        public string NameAlbum { get; set; }
        public string ImageAlbum { get; set; }
        public ICollection<TheSong> TheSongs { get; set; }
    }
}
