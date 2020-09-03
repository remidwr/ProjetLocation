using Dal = DAL.Models;
using Api = ProjetLocation.API.Models.Rental;

namespace ProjetLocation.API.Utils.Extensions
{
    internal static class RentalMapperAPI
    {
        internal static Api.Rental DALRentalToAPI(this Dal.Rental rental)
        {
            if (!(rental is null))
            {
                return new Api.Rental()
                {
                    Id = rental.Id,
                    GoodId = rental.GoodId,
                    UserId = rental.UserId,
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

        internal static Dal.Rental DALRentalToAPI(this Api.Rental rental)
        {
            return new Dal.Rental()
            {
                Id = rental.Id,
                GoodId = rental.GoodId,
                UserId = rental.UserId,
                RentedFrom = rental.RentedFrom,
                RentedTo = rental.RentedTo,
                Amount = rental.Amount,
                Deposit = rental.Deposit,
                Rating = rental.Rating,
                Review = rental.Review
            };
        }
    }
}
