using Microsoft.AspNetCore.Http;

namespace APIMusic.Models.Requests
{
    public class CreateAlbum
    {
        public string NameAlbum { get; set; }
        public IFormFile FileImage { get; set; }
    }
}
