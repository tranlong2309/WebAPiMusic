using APIMusic.Models.Requests;
using APIMusic.Models.Responses;
using System.Collections.Generic;

namespace APIMusic.Services
{
    public interface ITheSongRepository
    {
        List<TheSongResponse> GetAll();
        bool CreateTheSong(CreateTheSong request, string urlSong, string urlImage, string IdSong);
        bool CreateDetailSongSinger(CreateSingerSongRequest request);
        List<GetCategory> GetCategories();
        List<GetBrandCategory> GetBrandCategory();
        bool CreateCategory(string name, string image);
        bool CreateAlbum(string name, string image);
        List<CategoryResponse> GetCategory();
        List<AlbumResponse> GetAlbum();
        List<SearchSongResponse> SearchSong(string res);
        bool Updatelisten(int id);
        List<SongRankResponse> GetSongChart();
    }
}
