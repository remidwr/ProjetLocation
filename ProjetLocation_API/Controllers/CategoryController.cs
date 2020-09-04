﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DAL.IRepositories;
using DAL.Repositories;
using DAL.Models;
using ProjetLocation.API.Models.User.RoleName;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetLocation.API.Controllers
{
    [Authorize(Roles = Roles.User + "," + Roles.Admin + "," + Roles.SuperAdmin)]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IGenericRepository<Category> _categoryRepository;

        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult GetAll() // POSTMAN OK
        {
            IEnumerable<Category> categories = _categoryRepository.GetAll().Select(x => x);

            if (!(categories is null))
                return Ok(categories);
            else
                return NotFound();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id) // POSTMAN OK
        {
            Category category = _categoryRepository.GetById(id);

            if (!(category is null))
                return Ok(category);
            else
                return NotFound();
        }

        // POST api/<CategoryController>
        [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
        [HttpPost]
        public IActionResult Post([FromBody] Category category) // POSTMAN OK
        {
            int Successful = _categoryRepository.Insert(category);

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }

        // PUT api/<CategoryController>/5
        [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category) // POSTMAN OK
        {
            int Successful = _categoryRepository.Update(id, category);

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }

        // DELETE api/<CategoryController>/5
        [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) // POSTMAN OK
        {
            int Successful = _categoryRepository.Delete(id);

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }
    }
}