using Api = ProjetLocation.API.Models.Good;
using Dal = DAL.Models;

namespace ProjetLocation.API.Utils.Extensions
{
    internal static class GoodMapperAPI
    {
        internal static Api.Good DALGoodToAPI(this Dal.Good good)
        {
            if (!(good is null))
            {
                return new Api.Good()
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
                    UserId = good.UserId,
                    SectionId = good.SectionId
                };
            }
            else
                return null;
        }

        internal static Dal.Good APIGoodToDAL(this Api.Good good)
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
                Picture = good.Picture,
                UserId = good.UserId,
                SectionId = good.SectionId
            };
        }
    }
}
