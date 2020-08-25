using System;

namespace ProjetLocation.API.Models.User
{
    public class UserRegister
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
    }
}
