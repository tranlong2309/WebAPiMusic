using System;
using System.Collections.Generic;

namespace APIMusic.Models.Responses
{
    public class GetCategory
    {
        public string Header { get; set; }
        public List<Playlist> Playlists { get; set; }
    }

    public class Playlist
    {
        public string Name { get; set; }
        public Array Artists { get; set; }
        public string Image { get; set; }
    }
}
