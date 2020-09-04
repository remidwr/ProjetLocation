using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using Api = ProjetLocation.API.Models.Rental;
using Microsoft.AspNetCore.Mvc;
using DAL.IRepositories;
using DAL.Repositories;
using System.Net; // TODO Creation Date
using ProjetLocation.API.Models.User.RoleName;
using Microsoft.AspNetCore.Authorization;
using ProjetLocation.API.Utils.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetLocation.API.Controllers
{
    [Authorize(Roles = Roles.User + "," + Roles.Admin + "," + Roles.SuperAdmin)]
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private IRentalRepository<Rental> _rentalRepository;

        public RentalController(RentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        // GET: api/<RentalController>
        [HttpGet]
        public IActionResult GetAll() // POSTMAN OK
        {
            IEnumerable<Rental> rentals = _rentalRepository.GetAll().Select(x => x);

            if (!(rentals is null))
                return Ok(rentals);
            else
                return NotFound();
        }

        // GET api/<RentalController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id) // POSTMAN OK
        {
            Rental rental = _rentalRepository.GetById(id);

            if (!(rental is null))
                return Ok(rental);
            else
                return NotFound();
        }

        // POST api/<RentalController>
        [HttpPost]
        public IActionResult Post([FromBody] Rental rental) // POSTMAN OK
        {
            int Successful = _rentalRepository.Insert(rental);

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }

        // PUT api/<RentalController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Rental rental) // POSTMAN OK
        {
            int Successful = _rentalRepository.Update(id, rental);

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
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
                    return Problem(detail: "Unable to delete because the rental is not finished yet !",
                                   statusCode: (int)HttpStatusCode.Unauthorized);
            }

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }

        [HttpPut("{id}/rating")]
        public IActionResult UpdateRating(int id, [FromBody] Api.RentalRating rental)
        {
            int Successful = 0;

            try
            {
                Successful = _rentalRepository.UpdateRating(id, rental.APIRentalRatingToDAL());
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UnableToAddRating"))
                    return Problem(detail: "Unable to add a rating because the rental is not finished yet !",
                                   statusCode: (int)HttpStatusCode.Unauthorized);
            }

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }
    }
}
