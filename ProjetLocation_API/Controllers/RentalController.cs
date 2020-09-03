﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dal = DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Api = ProjetLocation.API.Models.Rental;
using DAL.IRepositories;
using DAL.Repositories;
using ProjetLocation.API.Utils.Extensions;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetLocation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private IRentalRepository<Dal.Rental> _rentalRepository;

        public RentalController(RentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        // GET: api/<RentalController>
        [HttpGet]
        public IActionResult GetAll() // POSTMAN OK
        {
            IEnumerable<Api.Rental> rentals = _rentalRepository.GetAll().Select(x => x.DALRentalToAPI());

            if (!(rentals is null))
                return Ok(rentals);
            else
                return NotFound();
        }

        // GET api/<RentalController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) // POSTMAN OK
        {
            Api.Rental rental = _rentalRepository.Get(id).DALRentalToAPI();

            if (!(rental is null))
                return Ok(rental);
            else
                return NotFound();
        }

        // POST api/<RentalController>
        [HttpPost]
        public IActionResult Post([FromBody] Api.Rental rental) // POSTMAN OK
        {
            int Successful = _rentalRepository.Insert(rental.DALRentalToAPI());

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }

        // PUT api/<RentalController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Api.Rental rental) // POSTMAN OK
        {
            int Successful = _rentalRepository.Update(id, rental.DALRentalToAPI());

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
                    return Problem(detail: "Unable to delete because the rental is not finished !",
                                   statusCode: (int)HttpStatusCode.Unauthorized);
            }

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }
    }
}
