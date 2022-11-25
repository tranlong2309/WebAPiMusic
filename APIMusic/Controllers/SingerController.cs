using APIMusic.Authorization;
using APIMusic.Models.Requests;
using APIMusic.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace APIMusic.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class SingerController : ControllerBase
    {
        private readonly ISinger _singer;
        private readonly IFirebaseStorageService _firebaseStorageService;
        public SingerController(ISinger singer, IFirebaseStorageService firebaseStorageService)
        {
            _singer = singer;
            _firebaseStorageService = firebaseStorageService;
        }

        [HttpPost("create-singer")]
        public async Task<IActionResult> CreateSinger([FromForm] CreateSinger req)
        {
            try
            {
                var urlImage = await _firebaseStorageService.PutFileToFirebaseAsync(req.FileImage.OpenReadStream(), Path.GetExtension(req.FileImage.FileName));
                var res = _singer.CreateSinger(req.NameSinger, urlImage);
                if (res)
                {
                    return Ok(true);
                }
                else
                {
                    return Ok(true);
                }
            }catch(Exception e)
            {
                return Ok(false);
            }
           

        }

        [AllowAnonymous]
        [HttpGet("get-all-singer")]
        public IActionResult GetAllSinger()
        {
            var res = _singer.GetAllSinger();
            return Ok(res);
        }
    }
}
