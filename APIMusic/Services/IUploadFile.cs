using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace APIMusic.Services
{
    public interface IUploadFile
    {
        Task<string> PutFile(IFormFile formFile,string NameFolder);
    }
}
