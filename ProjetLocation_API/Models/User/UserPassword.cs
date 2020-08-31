using System.ComponentModel.DataAnnotations;

namespace ProjetLocation.API.Models.User
{
    public class UserPassword
    {
        [Required]
        public string Passwd { get; set; }
    }
}
