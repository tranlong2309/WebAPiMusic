using System;

namespace APIMusic.Models.Responses
{
    public class TheSong
    {
        public int Id { get; set; }
        public string NameSong { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public string describe { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
