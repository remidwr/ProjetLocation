using Api = ProjetLocation.API.Models.Rental;
using Dal = DAL.Models;

namespace ProjetLocation.API.Utils.Extensions
{
    internal static class RentalMapperAPI
    {
        internal static Api.RentalRating DALRentalRatingToDAL(this Dal.Rental rental)
        {
            if (!(rental is null))
            {
                return new Api.RentalRating()
                {
                    Id = rental.Id,
                    Rating = rental.Rating,
                    Review = rental.Review
                };
            }
            else
                return null;
        }

        internal static Dal.Rental APIRentalRatingToDAL(this Api.RentalRating rental)
        {
            return new Dal.Rental()
            {
                Id = rental.Id,
                Rating = rental.Rating,
                Review = rental.Review
            };
        }
    }
}
