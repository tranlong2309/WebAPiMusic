using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace APIMusic.Services.Impl
{
    public class UploadFile : IUploadFile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadFile(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> PutFile(IFormFile formFile,string NameFolder)
        {
            if (formFile.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\"+ NameFolder+"\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\" + NameFolder + "\\");

                    }
                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\" + NameFolder + "\\" + formFile.FileName))
                    {
                        formFile.CopyTo(fileStream);
                        fileStream.Flush();
                        return "//" + NameFolder + "//" + formFile.FileName;
                    }
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
    }
}
