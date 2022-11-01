using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMusicEntities.Models
{
    public class FollowSingers
    {
        public int IdSinger { get; set; }
        public int IdListener { get; set; }
        public DateTime CreateDate { get; set; }
        public string Describe { get; set; }
        public virtual Singer Singer { get; set; }
        public virtual Listener Listener { get; set; }
    }
}
