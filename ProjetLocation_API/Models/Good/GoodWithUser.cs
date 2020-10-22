using DAL.Models;
using ProjetLocation.API.Models.User;

namespace ProjetLocation.API.Models.Good
{
    public class GoodWithUser
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
        public Section Section { get; set; }
        public CategorySimple Category { get; set; }
        public UserInfo User { get; set; }
    }
}
