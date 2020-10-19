using DAL.Models;
using ProjetLocation.API.Models.Good;

namespace ProjetLocation.API.Utils.Extensions
{
    internal static class SectionMapperAPI
    {

        internal static SectionWithCategories DALSectionWithCategoriesToAPI(this Section section)
        {
            if (!(section is null))
            {
                return new SectionWithCategories()
                {
                    Id = section.Id,
                    Name = section.Name
                };
            }
            else
                return null;
        }

        internal static Section APISectionWithCategoriesToDAL(this SectionWithCategories section)
        {
            return new Section()
            {
                Id = section.Id,
                Name = section.Name
            };
        }
    }
}
