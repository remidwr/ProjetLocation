using ProjetLocation.API.Models.Rental;
using DAL.Models;

namespace ProjetLocation.API.Utils.Extensions
{
    internal static class RentalMapperAPI
    {
        internal static RentalFull DALRentalFullToAPI(this Rental rental)
        {
            if (!(rental is null))
            {
                return new RentalFull()
                {
                    Id = rental.Id,
                    CreationDate = rental.CreationDate,
                    RentedFrom = rental.RentedFrom,
                    RentedTo = rental.RentedTo,
                    Amount = rental.Amount,
                    Deposit = rental.Deposit,
                    Rating = rental.Rating,
                    Review = rental.Review
                };
            }
            else
                return null;
        }

        internal static Rental APIRentalFullToDAL(this RentalFull rental)
        {
            return new Rental()
            {
                Id = rental.Id,
                CreationDate = rental.CreationDate,
                RentedFrom = rental.RentedFrom,
                RentedTo = rental.RentedTo,
                Amount = rental.Amount,
                Deposit = rental.Deposit,
                Rating = rental.Rating,
                Review = rental.Review
            };
        }

        internal static RentalRating DALRentalRatingToDAL(this Rental rental)
        {
            if (!(rental is null))
            {
                return new RentalRating()
                {
                    Id = rental.Id,
                    Rating = rental.Rating,
                    Review = rental.Review
                };
            }
            else
                return null;
        }

        internal static Rental APIRentalRatingToDAL(this RentalRating rental)
        {
            return new Rental()
            {
                Id = rental.Id,
                Rating = rental.Rating,
                Review = rental.Review
            };
        }
    }
}
