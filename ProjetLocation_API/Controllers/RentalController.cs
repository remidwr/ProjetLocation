using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using DAL.IRepositories;
using DAL.Repositories;
using ProjetLocation.API.Models.User.RoleName;
using Microsoft.AspNetCore.Authorization;
using ProjetLocation.API.Utils.Extensions;
using System.Net;
using ProjetLocation.API.Models.Rental;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetLocation.API.Controllers
{
    [Authorize(Roles = Roles.User + "," + Roles.Admin + "," + Roles.SuperAdmin)]
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private IRentalRepository<Rental, User, Good> _rentalRepository;

        public RentalController(RentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        // GET: api/<RentalController>
        [HttpGet]
        public IActionResult GetAll() // POSTMAN OK
        {
            IEnumerable<RentalFull> rentals = _rentalRepository.GetAll().Select(x => x.DALRentalFullToAPI());

            if (!(rentals is null))
                return Ok(rentals);
            else
                return Problem(detail: "Locations non trouvées.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // GET api/<RentalController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id) // POSTMAN OK
        {
            RentalFull rental = _rentalRepository.GetById(id).DALRentalFullToAPI();

            if (!(rental is null))
                return Ok(rental);
            else
                return Problem(detail: "Location non trouvée.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // POST api/<RentalController>
        [HttpPost]
        public IActionResult Post([FromBody] Rental rental) // POSTMAN OK
        {
            int Successful = _rentalRepository.Insert(rental);

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Impossible de créer une location.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // PUT api/<RentalController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Rental rental) // POSTMAN OK
        {
            int Successful = _rentalRepository.Update(id, rental);

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Impossible de mettre à jour une location.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        [HttpPut("{id}/rating")]
        public IActionResult UpdateRating(int id, [FromBody] RentalRating rental) // POSTMAN OK
        {
            int Successful = 0;

            try
            {
                Successful = _rentalRepository.UpdateRating(id, rental.APIRentalRatingToDAL());
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UnableToAddRating"))
                    return Problem(detail: "Impossible d'ajouter une évaluation car la location n'est pas encore finie.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Impossible de mettre à jour son évaluation.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // DELETE api/<RentalController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) // POSTMAN OK
        {
            int Successful = 0;

            try
            {
                Successful = _rentalRepository.Delete(id);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UnableToDelete"))
                    return Problem(detail: "Impossible de supprimer une location car elle n'est pas encore finie.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Impossible de supprimer une location.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }
    }
}
