using APIMusic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMusicEntities.Models
{
    public class Listener:BaseEntity
    {
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public int? IdListenerOfUser { get; set; }
        public virtual User User { get; set; }
        public ICollection<ListLike> ListLikes { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
        public ICollection<FollowSingers> FollowSingers { get; set; }
        public ICollection<SongListener> SongListeners { get; set; }
        public Listener()
        {
            ListLikes = new List<ListLike>();
            Playlists = new List<Playlist>();
            FollowSingers = new List<FollowSingers>();
            SongListeners = new List<SongListener>();
        }

    }
}
