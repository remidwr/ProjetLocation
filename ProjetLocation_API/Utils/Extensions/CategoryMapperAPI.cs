using DAL.Models;
using ProjetLocation.API.Models.Good;

namespace ProjetLocation.API.Utils.Extensions
{
    internal static class CategoryMapperAPI
    {
        internal static CategorySimple DALCategoryToAPI(this Category category)
        {
            if (!(category is null))
            {
                return new CategorySimple()
                {
                    Id = category.Id,
                    Name = category.Name
                };
            }
            else
                return null;
        }

        internal static Category APICategoryToDAL(this CategorySimple category)
        {
            return new Category()
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
