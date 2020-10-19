using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories;
using ProjetLocation.API.Models.Rental;
using ProjetLocation.API.Utils.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace ProjetLocation.API.Services
{
    public class RentalService
    {
        private IRentalRepository<Rental, User, Good> _rentalRepository;

        public RentalService(RentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public IEnumerable<RentalFull> GetAll()
        {
            IEnumerable<RentalFull> rentals = _rentalRepository.GetAll().Select(x => x.DALRentalFullToAPI());
            foreach (RentalFull rental in rentals)
            {
                rental.Good = _rentalRepository.GetGoodByRentalId(rental.Id).DALGoodFullToAPI();
                rental.Owner = _rentalRepository.GetOwnerByRentalId(rental.Id).DALUserInfoToAPI();
                rental.Tenant = _rentalRepository.GetTenantByRentalId(rental.Id).DALUserInfoToAPI();
            }

            return rentals;
        }

        public RentalFull GetById(int rentalId)
        {
            RentalFull rental = _rentalRepository.GetById(rentalId).DALRentalFullToAPI();
            rental.Good = _rentalRepository.GetGoodByRentalId(rental.Id).DALGoodFullToAPI();
            rental.Owner = _rentalRepository.GetOwnerByRentalId(rental.Id).DALUserInfoToAPI();
            rental.Tenant = _rentalRepository.GetTenantByRentalId(rental.Id).DALUserInfoToAPI();

            return rental;
        }

        public int Post(Rental rental)
        {
            int Successful = _rentalRepository.Insert(rental);

            return Successful;
        }

        public int Put(int rentalId, Rental rental)
        {
            int Successful = _rentalRepository.Update(rentalId, rental);

            // condition pour le rating

            return Successful;
        }

        public int UpdateRating(int rentalId, RentalRating rental)
        {
            int Successful = _rentalRepository.UpdateRating(rentalId, rental.APIRentalRatingToDAL());

            return Successful;
        }

        public int Delete(int rentalId)
        {
            int Successful = _rentalRepository.Delete(rentalId);

            return Successful;
        }
    }
}
