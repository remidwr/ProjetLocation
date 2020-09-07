using ProjetLocation.API.Models.Good;
using ProjetLocation.API.Models.User;
using System;

namespace ProjetLocation.API.Models.Rental
{
    public class RentalWithUsersGood
    {
        public int Id { get; set; }
        public GoodWithSection Good { get; set; }
        public UserInfo Owner { get; set; }
        public UserInfo Tenant { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RentedFrom { get; set; }
        public DateTime RentedTo { get; set; }
        public double Amount { get; set; }
        public double? Deposit { get; set; }
        public int? Rating { get; set; }
        public string Review { get; set; }
    }
}
