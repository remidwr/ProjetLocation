using Dal = DAL.Models;
using Api = ProjetLocation.API.Models.Good;
using DAL.Repositories;

namespace ProjetLocation.API.Utils.Extensions
{
    internal static class GoodMapperAPI
    {
        private static GoodRepository _goodRepository;

        public static GoodRepository goodRepository
        {
            get
            {
                return new GoodRepository();
            }
        }

        internal static Api.GoodWithSection DALGoodWithSectionToAPI(this Dal.Good good)
        {
            if (!(good is null))
            {
                return new Api.GoodWithSection()
                {
                    Id = good.Id,
                    Name = good.Name,
                    Description = good.Description,
                    State = good.State,
                    AmountPerDay = good.AmountPerDay,
                    AmountPerWeek = good.AmountPerWeek,
                    AmountPerMonth = good.AmountPerMonth,
                    Street = good.Street,
                    Number = good.Number,
                    Box = good.Box,
                    PostCode = good.PostCode,
                    City = good.City,
                    Picture = good.Picture,
                    User = goodRepository.GetUserByGoodId(good.Id).DALUserInfoToAPI(),
                    Section = goodRepository.GetSectionByGoodId(good.Id).DALSectionNameToAPI()
                };
            }
            else
                return null;
        }

        internal static Dal.Good APIGoodWithSectionToDAL(this Api.GoodWithSection good)
        {
            return new Dal.Good()
            {
                Id = good.Id,
                Name = good.Name,
                Description = good.Description,
                State = good.State,
                AmountPerDay = good.AmountPerDay,
                AmountPerWeek = good.AmountPerWeek,
                AmountPerMonth = good.AmountPerMonth,
                Street = good.Street,
                Number = good.Number,
                Box = good.Box,
                PostCode = good.PostCode,
                City = good.City,
                Picture = good.Picture
            };
        }

        internal static Api.SectionName DALSectionNameToAPI(this Dal.Section section)
        {
            if (!(section is null))
            {
                return new Api.SectionName()
                {
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
                Name = section.Name
            };
        }

        internal static Api.CategoryName DALCategoryNameToAPI(this Dal.Category category)
        {
            if (!(category is null))
            {
                return new Api.CategoryName()
                {
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
                Name = category.Name
            };
        }
    }
}
