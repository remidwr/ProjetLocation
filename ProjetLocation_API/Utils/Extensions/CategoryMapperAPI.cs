using Api = ProjetLocation.API.Models.Good;
using Dal = DAL.Models;

namespace ProjetLocation.API.Utils.Extensions
{
    internal static class CategoryMapperAPI
    {
        internal static Api.CategoryName DALCategoryNameToAPI(this Dal.Category category)
        {
            if (!(category is null))
            {
                return new Api.CategoryName()
                {
                    Id = category.Id,
                    Name = category.Name
                };
            }
            else
                return null;
        }

        internal static Dal.Category APICategoryNameToDAL(this Api.CategoryName category)
        {
            return new Dal.Category()
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
