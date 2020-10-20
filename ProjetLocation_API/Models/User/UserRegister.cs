using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetLocation.API.Models.User
{
    public class UserRegister
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
    }
}
