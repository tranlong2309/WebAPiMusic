using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMusic.Entities;

namespace APIMusic.Models.Responses.Dto
{
    public class UserInfor
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
    }
}
