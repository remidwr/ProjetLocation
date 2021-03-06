﻿using ProjetLocation.API.Models.Good;
using System;
using System.Collections.Generic;

namespace ProjetLocation.API.Models.User
{
    public class UserFull
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Box { get; set; }
        public int? PostCode { get; set; }
        public string City { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Picture { get; set; }
        public bool IsActive { get; set; }
        public bool IsBanned { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Token { get; set; }
        public IEnumerable<GoodFull> Goods { get; set; }
    }
}
