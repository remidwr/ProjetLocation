using DAL.Models;
using System.Collections.Generic;

namespace ProjetLocation.API.Models.Good
{
    public class SectionWithCategories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
