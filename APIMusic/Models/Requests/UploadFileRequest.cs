using Microsoft.AspNetCore.Http;

namespace APIMusic.Models.Requests
{
    public class UploadFileRequest
    {
        public IFormFile FileProfile { get; set; }
    }
}
