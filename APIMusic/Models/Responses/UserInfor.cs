using APIMusic.Authorization;
using APIMusic.Entities;

namespace APIMusic.Models.Responses
{
    public class UserInfor
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
    }
}