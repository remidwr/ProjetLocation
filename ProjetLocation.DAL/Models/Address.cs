namespace ProjetLocation.DAL.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Box { get; set; }
        public int PostCode { get; set; }
        public string City { get; set; }
    }
}
