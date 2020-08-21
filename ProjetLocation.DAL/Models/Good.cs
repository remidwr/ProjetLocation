namespace ProjetLocation.DAL.Models
{
    public class Good
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public string Picture { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int SectionId { get; set; }
    }
}
