using DAL.Repositories;
using Api = ProjetLocation.API.Models.Rental;
using Dal = DAL.Models;

namespace ProjetLocation.API.Utils.Extensions
{
    internal static class RentalMapperAPI
    {
        private static RentalRepository _rentalRepository;

        public static RentalRepository rentalRepository
        {
            get
            {
                return new RentalRepository();
            }
        }

        internal static Api.RentalWithUsersGood DALRentalWithUsersGoodToAPI(this Dal.Rental rental)
        {
            if (!(rental is null))
            {
                return new Api.RentalWithUsersGood()
                {
                    Id = rental.Id,
                    Good = rentalRepository.GetGoodByRentalId(rental.Id).DALGoodWithSectionToAPI(),
                    Owner = rentalRepository.GetOwnerByRentalId(rental.Id).DALUserInfoToAPI(),
                    Tenant = rentalRepository.GetTenantByRentalId(rental.Id).DALUserInfoToAPI(),
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

        internal static Dal.Rental APIRentalWithUsersGoodToDAL(this Api.RentalWithUsersGood rental)
        {
            return new Dal.Rental()
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
