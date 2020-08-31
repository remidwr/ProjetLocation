using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetLocation.API.Models.User
{
    public class UserInfo
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Box { get; set; }
        public int PostCode { get; set; }
        public string City { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Picture { get; set; }
    }
}
