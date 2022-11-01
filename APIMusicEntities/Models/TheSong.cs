using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMusicEntities.Models
{
    public class TheSong:BaseEntity
    {
        public string NameSong { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public int? IdTheSongOfCategory { get; set; }
        public int? IdTheSongOfAlbum { get; set; }
        public string IdUrlSong { get; set; }
        public ICollection<DetailSongSinger> DetailSongSingers { get; set; }
        public ICollection<ListLike> ListLikes { get; set; }
        public ICollection<DetailPlaylistSong> DetailPlaylistSongs { get; set; }
        public virtual Category Category { get; set; }
        public virtual Album Album { get; set; }
        public virtual Advertisement Advertisement { get; set; }
        public TheSong()
        {
            DetailSongSingers = new List<DetailSongSinger>();
            ListLikes = new List<ListLike>();
            DetailPlaylistSongs = new List<DetailPlaylistSong>();
        }

    }
}
