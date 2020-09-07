using System.Collections.Generic;

namespace ProjetLocation.API.Models.Good
{
    public class SectionWithCategories
    {
        public string Name { get; set; }
        public IEnumerable<CategoryName> Categories { get; set; }
    }
}
