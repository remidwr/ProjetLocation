using System;

namespace DAL.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int GoodId { get; set; }
        public int OwnerId { get; set; }
        public int TenantId { get; set; }
        public DateTime RentedFrom { get; set; }
        public DateTime RentedTo { get; set; }
        public double Amount { get; set; }
        public double? Deposit { get; set; }
        public int? Rating { get; set; }
        public string Review { get; set; }
    }
}
