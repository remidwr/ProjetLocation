using System.ComponentModel.DataAnnotations;

namespace ProjetLocation.API.Models.User
{
    public class UserLogin
    {
        public string Email { get; set; }
        public string Passwd { get; set; }
    }
}
