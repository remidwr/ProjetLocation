using DAL.Models;
using System.Collections.Generic;

namespace ProjetLocation.API.Models.Good
{
    public class SectionFull
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CategorySimple> Categories { get; set; }
    }
}
