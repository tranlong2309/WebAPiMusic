using System.ComponentModel.DataAnnotations;

namespace APIMusic.Models.Requests
{
    public class UserRequests
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(250)]
        public string PasswordHash { get; set; }
    }
}