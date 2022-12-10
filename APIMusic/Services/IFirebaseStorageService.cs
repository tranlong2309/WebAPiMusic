using APIMusic.Models.Requests;
using APIMusic.Models.Responses.Dto;
using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace APIMusic.Services
{
    public interface IFirebaseStorageService
    {
        Task<string> PutFileToFirebaseAsync(Stream stream, string extensionFileName);
        Task<string[]> PutFile(Stream stream, string extensionFileName);
        Task<FileDto> DownloadFileFromFireBaseAsync(string fileName);
    }
}
