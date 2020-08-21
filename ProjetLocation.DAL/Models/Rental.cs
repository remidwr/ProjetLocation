using System;

namespace ProjetLocation.DAL.Models
{
    public class Rental
    {
        public DateTime CreationDate { get; set; }
        public DateTime RentedFrom { get; set; }
        public DateTime RentedTo { get; set; }
        public double AmountPerDay { get; set; }
        public double AmountPerWeek { get; set; }
        public double AmountPerMonth { get; set; }
        public double Deposit { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public int UserId { get; set; }
        public int GoodId { get; set; }
    }
}
