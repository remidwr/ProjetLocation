using DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetLocation.API.Models.User.RoleName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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
            try
            {
                _categoryRepository.Insert(category);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable to insert category"))
                    return Problem(detail: "Cette catégorie existe déjà dans cette section.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            return Ok();
        }

        [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            try
            {
                _categoryRepository.Update(id, category);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable to update category"))
                    return Problem(detail: "Cette catégorie existe déjà dans cette section.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            return Ok();
        }

        [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoryRepository.Delete(id);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable to delete category"))
                    return Problem(detail: "Cette catégorie est rattachée à un bien existant.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            return Ok();
        }
    }
}
