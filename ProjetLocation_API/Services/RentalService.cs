using DAL.Models;
using DAL.Repositories;
using ProjetLocation.API.Models.Rental;
using ProjetLocation.API.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetLocation.API.Services
{
    public class RentalService
    {
        private readonly RentalRepository _rentalRepository;
        private readonly GoodRepository _goodRepository;

        public RentalService(RentalRepository rentalRepository, GoodRepository goodRepository)
        {
            _rentalRepository = rentalRepository;
            _goodRepository = goodRepository;
        }

        public IEnumerable<RentalFull> GetAll()
        {
            List<RentalFull> rentals = _rentalRepository.GetAll().Select(x => x.DALRentalFullToAPI()).ToList();

            if (!(rentals is null))
            {
                foreach (RentalFull rental in rentals)
                {
                    rental.Good = _rentalRepository.GetGoodByRentalId(rental.Id).DALGoodFullToAPI();
                    rental.Good.Section = _goodRepository.GetSectionByGoodId(rental.Good.Id);
                    rental.Good.Category = _goodRepository.GetCategoryByGoodId(rental.Good.Id).DALCategoryToAPI();
                    rental.Owner = _rentalRepository.GetOwnerByRentalId(rental.Id).DALUserInfoToAPI();
                    rental.Tenant = _rentalRepository.GetTenantByRentalId(rental.Id).DALUserInfoToAPI();
                }
            }

            return rentals;
        }

        public RentalFull GetById(int rentalId)
        {
            RentalFull rental = _rentalRepository.GetById(rentalId).DALRentalFullToAPI();

            if (!(rental is null))
            {
                rental.Good = _rentalRepository.GetGoodByRentalId(rental.Id).DALGoodFullToAPI();
                rental.Good.Section = _goodRepository.GetSectionByGoodId(rental.Good.Id);
                rental.Good.Category = _goodRepository.GetCategoryByGoodId(rental.Good.Id).DALCategoryToAPI();
                rental.Owner = _rentalRepository.GetOwnerByRentalId(rental.Id).DALUserInfoToAPI();
                rental.Tenant = _rentalRepository.GetTenantByRentalId(rental.Id).DALUserInfoToAPI();
            }

            return rental;
        }

        public void Post(Rental rental)
        {
            try
            {
                _rentalRepository.Insert(rental);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Put(int rentalId, Rental rental)
        {
            try
            {
                _rentalRepository.Update(rentalId, rental);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateRating(int rentalId, RentalRating rental)
        {
            try
            {
                _rentalRepository.UpdateRating(rentalId, rental.APIRentalRatingToDAL());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int rentalId)
        {
            _rentalRepository.Delete(rentalId);
        }
    }
}
