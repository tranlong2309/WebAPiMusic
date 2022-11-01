using System.IO;

namespace APIMusic.Models.Responses.Dto
{
    public class FileDto
    {
        public MemoryStream Content { get; set; }

        public string ContentType { get; set; }
    }
}
