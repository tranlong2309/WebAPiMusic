using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace APIMusicEntities.Models
{
    public class Singer: BaseEntity
    {
        [Required]
        public  string NameSinger { get; set; }
        public TheSong TheSong { get; set; }
        public ICollection<DetailSongSinger> DetailSongSingers { get; set; }
        public ICollection<FollowSingers> FollowSingers { get; set; }
        
        public Singer()
        {
            DetailSongSingers = new List<DetailSongSinger>();
            FollowSingers = new List<FollowSingers>();
        }
    }
}