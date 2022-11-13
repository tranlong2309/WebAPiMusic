using APIMusic.Data;
using APIMusic.Models.Requests;
using APIMusic.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIMusic.Services.Impl
{
    public class TheSongRepository: ITheSongRepository
    {
        private readonly MyDBContext _context;

        public TheSongRepository(MyDBContext context)
        {
            _context = context;
        }

        public bool CreateTheSong(CreateTheSong request,string urlSong, string urlImage, string IdSong)
        {
            try
            {
                var theSong = new APIMusicEntities.Models.TheSong
                {
                    NameSong = request.NameSong,
                    Url = urlSong,
                    Image = urlImage,
                    IdUrlSong = IdSong,
                    IdTheSongOfCategory = 6,
                    DateUpdate=DateTime.Now
                };

                _context.TheSongs.Add(theSong);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CreateDetailSongSinger(CreateSingerSongRequest request)
        {
            try
            {
                var DetailSongSinger = new APIMusicEntities.Models.DetailSongSinger
                {
                    IdTheSong= request.idSong,
                    IdSinger=request.idSinger,
                    DateUpdate = DateTime.Now
                };

                _context.DetailSongSingers.Add(DetailSongSinger);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<TheSongResponse> GetAll()
        {
            var listSong = _context.TheSongs.Select(s => new TheSongResponse
            {
                Name=s.NameSong,
                Singers = s.DetailSongSingers.Select(s=>s.Singer.NameSinger).ToArray(),
                Path=s.Url,
                Image=s.Image

            }).ToList();

               return listSong;
        }

    }
}
