using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMusicEntities.Models
{
    public class ListLike:BaseEntity
    {
        public int IdTheSong { get; set; }
        public int IdListener { get; set; }
        public virtual TheSong TheSong { get; set; }
        public virtual Listener Listener { get; set; }
    }
}
