using System.Text.Json.Serialization;
using System.Collections.Generic;
using APIMusicEntities.Models;

namespace APIMusic.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        public virtual Listener Listener { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }

        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }
        //public Listener Listener { get; set; }

    }
}
