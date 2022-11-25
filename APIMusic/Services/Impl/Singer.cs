using APIMusic.Data;
using APIMusic.Models.Requests;
using APIMusic.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIMusic.Services.Impl
{
    public class Singer : ISinger
    {

        private readonly MyDBContext _context;

        public Singer(MyDBContext context)
        {
            _context = context;
        }

        public bool CreateSinger(string nameSinger ,string urlImage)
        {
            try
            {
                var singer = new APIMusicEntities.Models.Singer
                {
                    NameSinger = nameSinger,
                    UrlImage = urlImage,
                    DateUpdate = DateTime.Now
                };

                _context.Singers.Add(singer);
                _context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }

        }

        public List<SingerResponse> GetAllSinger()
        {
            var list = _context.Singers.Select(s => new SingerResponse
            {
                Name = s.NameSinger,
                Followers = s.FollowSingers.Count(),
                Image = s.UrlImage

            }).ToList();

            return list;
        }
    }
}
