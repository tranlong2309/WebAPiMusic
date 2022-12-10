using APIMusic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIMusic.Authorization;
using System.IO;
using System.Threading.Tasks;
using APIMusic.Models.Requests;
using System;
using Microsoft.AspNetCore.Hosting;

namespace APIMusic.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class TheSongController : ControllerBase
    {
        private readonly ITheSongRepository _theSongRepository;
        private readonly IFirebaseStorageService _firebaseStorageService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUploadFile _uploadFile;
        public TheSongController(ITheSongRepository theSongRepository, IFirebaseStorageService firebaseStorageService,IWebHostEnvironment webHostEnvironment, IUploadFile uploadFile)
        {
           
            _theSongRepository = theSongRepository;
            _firebaseStorageService = firebaseStorageService;
            _webHostEnvironment = webHostEnvironment;
            _uploadFile = uploadFile;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public IActionResult GetALL(int id)
        {
            try
            {
                var data = _theSongRepository.GetAll(id);
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
            string PORT = "https://" + Request.Host.ToString();
            //var urlSong = await _firebaseStorageService.PutFile(request.FileSong.OpenReadStream(), Path.GetExtension(request.FileSong.FileName));
            //var urlImage = await _firebaseStorageService.PutFileToFirebaseAsync(request.FileImage.OpenReadStream(), Path.GetExtension(request.FileImage.FileName));
            var urlSong = await _uploadFile.PutFile(request.FileSong, "MP3");
            var urlImage = await _uploadFile.PutFile(request.FileImage, "IMAGE");
            var res = _theSongRepository.CreateTheSong(request, PORT+urlSong, PORT + urlImage, string.Empty);

            if (res)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        [AllowAnonymous]
        [HttpPost("create-song-singer")]
        public IActionResult CreateSongSinger(CreateSingerSongRequest request)
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


        [AllowAnonymous]
        [HttpGet("Get-category")]
        public IActionResult GetALLCategory()
        {
            try
            {
                var data = _theSongRepository.GetCategories();
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
        [HttpGet("get-brand-category")]
        public IActionResult GetBrandCategory()
        {
            try
            {
                var data = _theSongRepository.GetBrandCategory();
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

        [HttpPost("create-category")]
        public async Task<IActionResult> CreateCategory([FromForm] RequestCreateCategory request)
        {
            string PORT = "https://" + Request.Host.ToString();
            var urlImage = await _uploadFile.PutFile(request.FileImage, "IMAGE");

            var res = _theSongRepository.CreateCategory(request.NameCategory,PORT+ urlImage);

            if (res)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpPost("create-album")]
        public async Task<IActionResult> CreateAlbum([FromForm] CreateAlbum request)
        {
            string PORT = "https://" + Request.Host.ToString();
            var urlImage = await _uploadFile.PutFile(request.FileImage, "IMAGE");

            var res = _theSongRepository.CreateAlbum(request.NameAlbum,PORT+ urlImage);

            return Ok(res);
        }

        [AllowAnonymous]
        [HttpGet("get-all-album")]
        public IActionResult GetAlbum()
        {
            
            var res = _theSongRepository.GetAlbum();

            return Ok(res);
        }

        [AllowAnonymous]
        [HttpGet("get-all-category")]
        public IActionResult GetCategory()
        {

            var res = _theSongRepository.GetCategory();

            return Ok(res);
        }

        [AllowAnonymous]
        [HttpGet("get-search-song")]
        public IActionResult SearchSong(string keyword)
       {

            var res = _theSongRepository.SearchSong(keyword);

            return Ok(res);
        }

        [AllowAnonymous]
        [HttpPut("update-listens")]
        public IActionResult UpdateListen(int id)
        {

            var res = _theSongRepository.Updatelisten(id);

            return Ok(res);
        }

        [AllowAnonymous]
        [HttpGet("get-song-chart")]
        public IActionResult GetSongChart()
        {
            try
            {
                var data = _theSongRepository.GetSongChart();
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
        
        [HttpPost("create-upload")]
        public async Task<IActionResult> CreateUpload([FromForm] CreateUpload request)
        {
            string PORT = "https://" + Request.Host.ToString();
            var urlSong = await _uploadFile.PutFile(request.FileSong, "ListerSong");
            var tfile = TagLib.File.Create(@"E:\WebMusicAPI\WebAPIMusic\APIMusic\wwwroot\ListerSong\" + request.FileSong.FileName);
            string title = tfile.Tag.Title;
   
            var res = _theSongRepository.CreateUpload(request.IdListener,title, tfile.Tag.Artists[0],PORT+urlSong);
                
            return Ok(res);
        }

        [AllowAnonymous]
        [HttpGet("get-music-listener")]
        public IActionResult GetMusicListener(int id)
        {
            var res = _theSongRepository.GetMusicListener(id);

            return Ok(res);
        }

    }
}
