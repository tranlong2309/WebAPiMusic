using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMusicEntities.Models
{
    public class SongListener:BaseEntity
    {
        public string NameSong { get; set; }
        public string UrlSong { get; set; }
        public string Image { get; set; }
        public string IdUrlSong { get; set; }
        public int IdListenerOfSong { get; set; }
        public string Singer { get; set; }
        public virtual Listener Listener { get; set; }
    }
}
