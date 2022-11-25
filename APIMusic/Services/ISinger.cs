using APIMusic.Models.Requests;
using APIMusic.Models.Responses;
using System.Collections.Generic;

namespace APIMusic.Services
{
    public interface ISinger
    {
        public bool CreateSinger(string nameSinger, string urlImage);
        public List<SingerResponse> GetAllSinger();
    }
}
