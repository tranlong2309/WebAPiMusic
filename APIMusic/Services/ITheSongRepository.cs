using APIMusic.Models.Requests;
using APIMusic.Models.Responses;
using System.Collections.Generic;

namespace APIMusic.Services
{
    public interface ITheSongRepository
    {
        List<TheSong> GetAll();
        bool CreateTheSong(CreateTheSong request, string urlSong, string urlImage, string IdSong);
    }
}
