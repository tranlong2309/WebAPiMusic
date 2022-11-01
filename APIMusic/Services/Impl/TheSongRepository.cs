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

        public List<TheSong> GetAll()
        {
            var listSong = _context.TheSongs.Select(s => new TheSong
            {
                Id = s.Id,
                NameSong = s.NameSong,
                Url = s.Url,
                Image = s.Image,
                describe = s.describe,
                DateUpdate=s.DateUpdate

            }).ToList();

               return listSong;
        }
    }
}
