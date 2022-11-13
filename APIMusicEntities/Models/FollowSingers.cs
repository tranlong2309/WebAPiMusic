using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMusicEntities.Models
{
    public class FollowSingers:BaseEntity
    {
        public int IdSinger { get; set; }
        public int IdListener { get; set; }
        public virtual Singer Singer { get; set; }
        public virtual Listener Listener { get; set; }
    }
}
