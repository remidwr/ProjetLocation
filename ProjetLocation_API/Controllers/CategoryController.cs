using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DAL.IRepositories;
using DAL.Repositories;
using DAL.Models;
using ProjetLocation.API.Models.User.RoleName;
using Microsoft.AspNetCore.Authorization;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetLocation.API.Controllers
{
    [Authorize(Roles = Roles.User + "," + Roles.Admin + "," + Roles.SuperAdmin)]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository<Category, Section> _categoryRepository;

        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: api/<CategoryController>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll() // POSTMAN OK
        {
            IEnumerable<Category> categories = _categoryRepository.GetAll().Select(x => x);

            if (!(categories is null))
                return Ok(categories);
            else
                return Problem(detail: "Catégories introuvables.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id) // POSTMAN OK
        {
            Category category = _categoryRepository.GetById(id);

            if (!(category is null))
                return Ok(category);
            else
                return Problem(detail: "Catégorie introuvable.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
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
                return Problem(detail: "Impossible de créer une catégorie.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
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
                return Problem(detail: "Impossible de mettre à jour la catégorie.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
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
                return Problem(detail: "Impossible de supprimer la catégorie.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }
    }
}
