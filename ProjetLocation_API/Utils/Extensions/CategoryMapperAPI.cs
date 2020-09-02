using Dal = DAL.Models;
using Api = ProjetLocation.API.Models.Good;

namespace ProjetLocation.API.Utils.Extensions
{
    internal static class CategoryMapperAPI
    {
        internal static Api.Category DALCategoryToAPI(this Dal.Category category)
        {
            if (!(category is null))
            {
                return new Api.Category()
                {
                    Id = category.Id,
                    Name = category.Name,
                    SectionId = category.SectionId
                };
            }
            else
                return null;
        }

        internal static Dal.Category APICategoryToDAL(this Api.Category category)
        {
            return new Dal.Category()
            {
                Id = category.Id,
                Name = category.Name,
                SectionId = category.SectionId
            };
        }
    }
}
