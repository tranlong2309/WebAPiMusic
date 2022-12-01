using APIMusic.Data;
using APIMusic.Models.Requests;
using APIMusic.Models.Responses;
using APIMusicEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIMusic.Services.Impl
{
    public class TheSongRepository : ITheSongRepository
    {
        private readonly MyDBContext _context;

        public TheSongRepository(MyDBContext context)
        {
            _context = context;
        }

        public bool CreateTheSong(CreateTheSong request, string urlSong, string urlImage, string IdSong)
        {
            try
            {
                var theSong = new APIMusicEntities.Models.TheSong
                {
                    NameSong = request.NameSong,
                    Url = urlSong,
                    Image = urlImage,
                    IdUrlSong = IdSong,
                    IdTheSongOfCategory = request.IdCategory,
                    DateUpdate = DateTime.Now
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
                    IdTheSong = request.idSong,
                    IdSinger = request.idSinger,
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
        public List<TheSongResponse> GetAll(int id)
        {
            int indexx = 0;
            var listSong = _context.TheSongs.OrderByDescending(o=>o.DateUpdate).Select(s => new TheSongResponse
            {
                Id=s.Id,
                Name = s.NameSong,
                Singers = s.DetailSongSingers.Select(s => s.Singer.NameSinger).ToArray(),
                Path = s.Url,
                Image = s.Image,
                Index= 0

            }).ToList();
            foreach (var item in listSong)
            {
                item.Index = indexx++;
            }
            var SongListeners = _context.SongListeners.Where(w => w.IdListenerOfSong == id).OrderByDescending(o => o.DateUpdate).Select(s => new TheSongResponse
            {
                Id = s.Id,
                Name = s.NameSong,
                Path = s.UrlSong,
                Image = s.Image,
                Singers = new[] { s.Singer },
                Index = 0

            }).ToList();
            if(SongListeners.Count > 0)
            {
                indexx = listSong.Count;
                foreach (var item in SongListeners)
                {
                    item.Index = indexx++;
                }
                listSong = SongListeners.Concat(listSong).ToList();

            }
            return listSong;
        }

        public List<GetCategory> GetCategories()
        {
            var listCategory = _context.Categories.Select(s => new GetCategory
            {
                Header = s.NameCategory,
                Playlists = s.TheSongs.Select(s1 => new Models.Responses.Playlist
                {
                    Name = s1.NameSong,
                    Artists = s1.DetailSongSingers.Select(s2 => s2.Singer.NameSinger).ToArray(),
                    Image = s1.Image
                }).ToList()

            }).Where(w => w.Playlists.Count > 0).ToList();

            return listCategory;
        }

        public List<GetBrandCategory> GetBrandCategory()
        {
            var list = _context.Categories.Select(s => new GetBrandCategory { Image= s.ImageCategory }).ToList();
            return list;
        }
        public bool CreateCategory(string name,string image)
        {
            try
            {
                var create = new Category
                {
                    NameCategory = name,
                    ImageCategory = image
                };

                _context.Categories.Add(create);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateAlbum(string name, string image)
        {
            try
            {
                var cretae = new Album
                {
                    NameAlbum = name,
                    ImageAlbum = image
                };
                _context.Albums.Add(cretae);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<CategoryResponse> GetCategory()
        {
            var list = _context.Categories.Select(s => new CategoryResponse
            {
                Id = s.Id,
                NameCategory = s.NameCategory
            }).ToList();

            return list;
        }

        public List<AlbumResponse> GetAlbum()
        {
            var list = _context.Albums.Select(s => new AlbumResponse
            {
                Id = s.Id,
                NameAlbum = s.NameAlbum
            }).ToList();

            return list;
        }

        public List<SearchSongResponse> SearchSong(string res)
        {
            var listSong = _context.TheSongs.Select(s => new SearchSongResponse
            {
                Id=s.Id,
                Name = s.NameSong,
                Singers = s.DetailSongSingers.Select(s => s.Singer.NameSinger).ToArray(),
                Path = s.Url,
                Image = s.Image,
                Index= 0


            }).Where(w=>w.Name.Contains(res)).ToList();
            foreach (var item in listSong)
            {
                item.Index = GetAll(0).Where(ww => ww.Id == item.Id).Select(ss => ss.Index).First();
            };

            return listSong;
        }

        public bool Updatelisten(int id)
        {
            try
            {
                var song = _context.TheSongs.Where(w => w.Id == id).FirstOrDefault();
                if (song != null)
                {
                    song.Listens = song.Listens + 1;
                    _context.TheSongs.Update(song);
                    _context.SaveChanges();
                }
               
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<SongRankResponse> GetSongChart()
        {
            int rank = 1;
            var listSong = _context.TheSongs.OrderByDescending(o => o.Listens).Select(s => new SongRankResponse
            {
                Id = s.Id,
                Name = s.NameSong,
                Singers = s.DetailSongSingers.Select(s => s.Singer.NameSinger).ToArray(),
                Path = s.Url,
                Image = s.Image,
                Index = 0,
                Rank=0
                

            }).ToList();

            foreach (var item in listSong)
            {
                item.Index = GetAll(0).Where(ww => ww.Id == item.Id).Select(ss => ss.Index).First();
                item.Rank = rank ++;
            }

            return listSong;
        }

        public bool CreateUpload(int id,string name,string singer,string url)
        {
            try
            {
                if (singer == null)
                {
                    singer = "Various Artists";
                }

                var upload = new SongListener
                {
                    IdListenerOfSong=id,
                    NameSong = name,
                    UrlSong = url,
                    Image = "https://photo-resize-zmp3.zmdcdn.me/w94_r1x1_webp/cover/3/2/a/3/32a35f4d26ee56366397c09953f6c269.jpg",
                    DateUpdate=DateTime.Now,
                    Singer= singer

                };

                _context.SongListeners.Add(upload);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TheSongResponse> GetMusicListener(int id)
        {
            int indexx = GetAll(0).Count();
            var listSong = _context.SongListeners.Where(w=>w.IdListenerOfSong==id).OrderByDescending(o => o.DateUpdate).Select(s => new TheSongResponse
            {
                Id = s.Id,
                Name = s.NameSong,
                Path = s.UrlSong,
                Image = s.Image,
                Singers = new[] { s.Singer },
                Index = 0

            }).ToList();

            foreach (var item in listSong)
            {
                item.Index = indexx++;
            }

            return listSong;
        }
    }
}
