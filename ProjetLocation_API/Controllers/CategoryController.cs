using System.Collections.Generic;
using System.Linq;
using Dal = DAL.Models;
using Api = ProjetLocation.API.Models.Good;
using Microsoft.AspNetCore.Mvc;
using DAL.IRepositories;
using ProjetLocation.API.Utils.Extensions;
using DAL.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetLocation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository<Dal.Category> _categoryRepository;

        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult GetAll() // POSTMAN OK
        {
            IEnumerable<Api.Category> categories = _categoryRepository.GetAll().Select(x => x.DALCategoryToAPI());

            if (!(categories is null))
                return Ok(categories);
            else
                return NotFound();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) // POSTMAN OK
        {
            Api.Category category = _categoryRepository.Get(id).DALCategoryToAPI();

            if (!(category is null))
                return Ok(category);
            else
                return NotFound();
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] Api.Category category) // POSTMAN OK
        {
            int Successful = _categoryRepository.Insert(category.APICategoryToDAL());

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Api.Category category) // POSTMAN OK
        {
            int Successful = _categoryRepository.Update(id, category.APICategoryToDAL());

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }

        // DELETE api/<CategoryController>/5
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
