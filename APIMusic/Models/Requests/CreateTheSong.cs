using Microsoft.AspNetCore.Http;

namespace APIMusic.Models.Requests
{
    public class CreateTheSong
    {
        public string NameSong { get; set; }
        public IFormFile FileSong { get; set; }
        public IFormFile FileImage { get; set; }
        public int? IdCategory { get; set; }
        public int? IdAlbum { get; set; }
    }
}
