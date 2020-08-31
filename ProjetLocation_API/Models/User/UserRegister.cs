using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetLocation.API.Models.User
{
    public class UserRegister
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Passwd { get; set; }
    }
}
