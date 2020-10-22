using DAL.Models;
using ProjetLocation.API.Models.Good;

namespace ProjetLocation.API.Utils.Extensions
{
    internal static class SectionMapperAPI
    {
        internal static SectionFull DALSectionWithCategoriesToAPI(this Section section)
        {
            if (!(section is null))
            {
                return new SectionFull()
                {
                    Id = section.Id,
                    Name = section.Name
                };
            }
            else
                return null;
        }

        internal static Section APISectionWithCategoriesToDAL(this SectionFull section)
        {
            return new Section()
            {
                Id = section.Id,
                Name = section.Name
            };
        }
    }
}
