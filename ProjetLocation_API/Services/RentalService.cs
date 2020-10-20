using DAL.IRepositories;
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
        private IRentalRepository<Rental, User, Good> _rentalRepository;
        private IGoodRepository<Good, User, Section, Category> _goodRepository;

        public RentalService(RentalRepository rentalRepository, GoodRepository goodRepository)
        {
            _rentalRepository = rentalRepository;
            _goodRepository = goodRepository;
        }

        public IEnumerable<RentalFull> GetAll()
        {
            List<RentalFull> rentals = _rentalRepository.GetAll().Select(x => x.DALRentalFullToAPI()).ToList();
            foreach (RentalFull rental in rentals)
            {
                rental.Good = _rentalRepository.GetGoodByRentalId(rental.Id).DALGoodFullToAPI();
                rental.Good.Section = _goodRepository.GetSectionByGoodId(rental.Good.Id);
                rental.Good.Category = _goodRepository.GetCategoryByGoodId(rental.Good.Id);
                rental.Owner = _rentalRepository.GetOwnerByRentalId(rental.Id).DALUserInfoToAPI();
                rental.Tenant = _rentalRepository.GetTenantByRentalId(rental.Id).DALUserInfoToAPI();
            }

            return rentals;
        }

        public RentalFull GetById(int rentalId)
        {
            RentalFull rental = _rentalRepository.GetById(rentalId).DALRentalFullToAPI();
            rental.Good = _rentalRepository.GetGoodByRentalId(rental.Id).DALGoodFullToAPI();
            rental.Good.Section = _goodRepository.GetSectionByGoodId(rental.Good.Id);
            rental.Good.Category = _goodRepository.GetCategoryByGoodId(rental.Good.Id);
            rental.Owner = _rentalRepository.GetOwnerByRentalId(rental.Id).DALUserInfoToAPI();
            rental.Tenant = _rentalRepository.GetTenantByRentalId(rental.Id).DALUserInfoToAPI();

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
            try
            {
                _rentalRepository.Delete(rentalId);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
