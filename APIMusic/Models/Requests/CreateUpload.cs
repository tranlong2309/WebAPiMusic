using Microsoft.AspNetCore.Http;

namespace APIMusic.Models.Requests
{
    public class CreateUpload
    {
        public int IdListener { get; set; }
        public IFormFile FileSong { get; set; }
    }
}
