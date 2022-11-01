using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMusicEntities.Models
{
    public class Playlist : BaseEntity
    {
        public string NamePlaylist { get; set; }
        public string ImagePlaylist { get; set; }
        public int IdListenerOfPlaylist { get; set; }
        public virtual Listener Listener { get; set; }
        public ICollection<DetailPlaylistSong> DetailPlaylistSongs { get; set; }

        public Playlist()
        {
            DetailPlaylistSongs = new List<DetailPlaylistSong>();
        }

    }
}
