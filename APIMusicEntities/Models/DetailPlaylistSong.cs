using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMusicEntities.Models
{
    public class DetailPlaylistSong
    {
        public int IdPlaylist { get; set; }
        public int IdTheSong { get; set; }
        public DateTime CreateDate { get; set; }
        public string Describe { get; set; }
        public virtual TheSong TheSong { get; set; }
        public virtual Playlist Playlist { get; set; }
    }
}
