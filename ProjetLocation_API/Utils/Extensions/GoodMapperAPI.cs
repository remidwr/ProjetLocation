using DAL.Models;
using ProjetLocation.API.Models.Good;

namespace ProjetLocation.API.Utils.Extensions
{
    internal static class GoodMapperAPI
    {
        internal static GoodFull DALGoodFullToAPI(this Good good)
        {
            if (!(good is null))
            {
                return new GoodFull()
                {
                    Id = good.Id,
                    Name = good.Name,
                    Description = good.Description,
                    State = good.State,
                    Amount = good.Amount,
                    Street = good.Street,
                    Number = good.Number,
                    Box = good.Box,
                    PostCode = good.PostCode,
                    City = good.City,
                    Picture = good.Picture
                };
            }
            else
                return null;
        }

        internal static Good APIGoodFullToDAL(this GoodFull good)
        {
            return new Good()
            {
                Id = good.Id,
                Name = good.Name,
                Description = good.Description,
                State = good.State,
                Amount = good.Amount,
                Street = good.Street,
                Number = good.Number,
                Box = good.Box,
                PostCode = good.PostCode,
                City = good.City,
                Picture = good.Picture
            };
        }
    }
}
