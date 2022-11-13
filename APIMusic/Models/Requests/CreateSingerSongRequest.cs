namespace APIMusic.Models.Requests
{
    public class CreateSingerSongRequest
    {
        public int idSong { get; set; }
        public int idSinger { get; set; }
    }
}
