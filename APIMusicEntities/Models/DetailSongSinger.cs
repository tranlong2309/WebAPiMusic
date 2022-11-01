using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMusicEntities.Models
{
    public class DetailSongSinger
    {
        public int IdTheSong { get; set; }
        public int IdSinger { get; set; }
        public string Describe { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual TheSong TheSong { get; set; }
        public virtual Singer Singer { get; set; }
    }
}
