using DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetLocation.API.Models.User.RoleName;
using System.Collections.Generic;
using System.Linq;

namespace ProjetLocation.API.Controllers
{
    [Authorize(Roles = Roles.User + "," + Roles.Admin + "," + Roles.SuperAdmin)]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Category> categories = _categoryRepository.GetAll().Select(x => x);

            if (!(categories is null))
                return Ok(categories);
            else
                return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Category category = _categoryRepository.GetById(id);

            if (!(category is null))
                return Ok(category);
            else
                return NotFound();
        }

        [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            _categoryRepository.Insert(category);

            return Ok();
        }

        [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            _categoryRepository.Update(id, category);

            return Ok();
        }

        [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryRepository.Delete(id);

            return Ok();
        }
    }
}
