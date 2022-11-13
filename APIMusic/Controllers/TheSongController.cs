using APIMusic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIMusic.Authorization;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System.IO;
using System;
using System.Threading.Tasks;
using APIMusic.Models.Requests;

namespace APIMusic.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class TheSongController : ControllerBase
    {
        private readonly ITheSongRepository _theSongRepository;
        private readonly IFirebaseStorageService _firebaseStorageService;
        public TheSongController(ITheSongRepository theSongRepository, IFirebaseStorageService firebaseStorageService)
        {
            _theSongRepository = theSongRepository;
            _firebaseStorageService = firebaseStorageService;
        }
  
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public IActionResult GetALL()
        {
            try
            {
                var data = _theSongRepository.GetAll();
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [AllowAnonymous]
        [HttpPost("upload-file")]
        public async Task<IActionResult> UploadFileAsync([FromForm] UploadFileRequest request)
        {
            var fileContent = request.FileProfile.OpenReadStream();
            var extensionFile = Path.GetExtension(request.FileProfile.FileName);
            var Url= await _firebaseStorageService.PutFileToFirebaseAsync(fileContent, extensionFile);

            //request.Document.Link = fileName;

            return Ok(Url);
            // Store fileName to database
        }

        [AllowAnonymous]
        [HttpPost("download-file")]
        public async Task<IActionResult> DownloadFileAsync(string fileName)
        {
            var fileDto = await _firebaseStorageService.DownloadFileFromFireBaseAsync(fileName);
            return File(fileDto.Content.ToArray(), fileDto.ContentType);
        }

        [AllowAnonymous]
        [HttpPost("create-the-song")]
        public async Task<IActionResult> CreateTheSong([FromForm] CreateTheSong request)
        {
            var urlSong = await _firebaseStorageService.PutFile(request.FileSong.OpenReadStream(), Path.GetExtension(request.FileSong.FileName));
            var urlImage = await _firebaseStorageService.PutFileToFirebaseAsync(request.FileImage.OpenReadStream(), Path.GetExtension(request.FileImage.FileName));

            var res = _theSongRepository.CreateTheSong(request, urlSong[0], urlImage, urlSong[1]);

            if (res)
            {
                return Ok("Thanh cong");
            }
            else
            {
                return Ok("That bai");
            }
        }

        [AllowAnonymous]
        [HttpPost("create-song-singer")]
        public async Task<IActionResult> CreateSongSinger(CreateSingerSongRequest request)
        {
            var res = _theSongRepository.CreateDetailSongSinger(request);

            if (res)
            {
                return Ok("Thanh cong");
            }
            else
            {
                return Ok("That bai");
            }
        }

    }
}
