using System;

namespace APIMusic.Models.Responses
{
    public class SongRankResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Array Singers { get; set; }
        public string Path { get; set; }
        public string Image { get; set; }
        public int Index { get; set; }
        public int Rank { get; set; }
    }
}
