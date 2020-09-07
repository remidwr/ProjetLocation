using Dal = DAL.Models;
using Api = ProjetLocation.API.Models.Good;
using DAL.Repositories;
using System.Linq;

namespace ProjetLocation.API.Utils.Extensions
{
    internal static class SectionMapperAPI
    {
        private static SectionRepository _sectionRepository;

        public static SectionRepository sectionRepository
        {
            get
            {
                return new SectionRepository();
            }
        }

        internal static Api.SectionName DALSectionNameToAPI(this Dal.Section section)
        {
            if (!(section is null))
            {
                return new Api.SectionName()
                {
                    //Id = section.Id,
                    Name = section.Name
                };
            }
            else
                return null;
        }

        internal static Dal.Section APISectionNameToDAL(this Api.SectionName section)
        {
            return new Dal.Section()
            {
                //Id = section.Id,
                Name = section.Name
            };
        }

        internal static Api.SectionWithCategories DALSectionWithCategoriesToAPI(this Dal.Section section)
        {
            if (!(section is null))
            {
                return new Api.SectionWithCategories()
                {
                    //Id = section.Id,
                    Name = section.Name,
                    Categories = _sectionRepository.GetCategoriesBySectionId(section.Id).Select(x => x.DALCategoryNameToAPI())
                };
            }
            else
                return null;
        }

        internal static Dal.Section APISectionWithCategoriesToDAL(this Api.SectionWithCategories section)
        {
            return new Dal.Section()
            {
                //Id = section.Id,
                Name = section.Name
            };
        }
    }
}
