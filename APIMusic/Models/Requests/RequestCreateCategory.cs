using Microsoft.AspNetCore.Http;

namespace APIMusic.Models.Requests
{
    public class RequestCreateCategory
    {
        public string NameCategory { get; set; }
        public IFormFile FileImage { get; set; }
    }
}
