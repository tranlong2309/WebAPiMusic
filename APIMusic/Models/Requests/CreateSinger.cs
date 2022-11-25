using Microsoft.AspNetCore.Http;

namespace APIMusic.Models.Requests
{
    public class CreateSinger
    {
        public string NameSinger { get; set; }
        public IFormFile FileImage { get; set; }
    }
}
