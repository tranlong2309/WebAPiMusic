using System.ComponentModel.DataAnnotations;

namespace APIMusic.Models.Requests
{
    public class RegisterUserRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
