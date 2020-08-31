using System.ComponentModel.DataAnnotations;

namespace ProjetLocation.API.Models.User
{
    public class UserLogin
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Passwd { get; set; }
    }
}
