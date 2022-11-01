using APIMusic.Entities;
using System.Text.Json.Serialization;
using APIMusic.Models.Responses.Dto;

namespace APIMusic.Models.Response
{
    public class AuthenticateResponses
    {

        public UserInfor UserInfor { get; set; }
        public string JwtToken { get; set; }


        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }

        public AuthenticateResponses(User user, string jwtToken, string refreshToken)
        {

            UserInfor = new UserInfor
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
                Name = user.FirstName + " " + user.LastName
            };
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }
    }
}
