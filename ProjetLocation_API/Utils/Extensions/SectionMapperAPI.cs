using Dal = DAL.Models;
using Api = ProjetLocation.API.Models.Good;

namespace ProjetLocation.API.Utils.Extensions
{
    internal static class SectionMapperAPI
    {
        internal static Api.Section DALSectionToAPI(this Dal.Section section)
        {
            if (!(section is null))
            {
                return new Api.Section()
                {
                    Id = section.Id,
                    Name = section.Name
                };
            }
            else
                return null;
        }

        internal static Dal.Section APISectionToDAL(this Api.Section section)
        {
            return new Dal.Section()
            {
                Id = section.Id,
                Name = section.Name
            };
        }
    }
}
