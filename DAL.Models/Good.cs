namespace DAL.Models
{
    public class Good
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public double Amount { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Box { get; set; }
        public int PostCode { get; set; }
        public string City { get; set; }
        public string Picture { get; set; }
        public int UserId { get; set; }
        public int SectionId { get; set; }
        public int CategoryId { get; set; }
    }
}
