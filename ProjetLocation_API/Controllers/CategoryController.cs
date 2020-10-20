using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DAL.IRepositories;
using DAL.Repositories;
using DAL.Models;
using ProjetLocation.API.Models.User.RoleName;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System;

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

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Category> categories = _categoryRepository.GetAll().Select(x => x);

            if (!(categories is null))
                return Ok(categories);
            else
                return Problem(detail: "Catégories introuvables.",
                               statusCode: (int)HttpStatusCode.NoContent);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Category category = _categoryRepository.GetById(id);

            if (!(category is null))
                return Ok(category);
            else
                return Problem(detail: "Catégorie introuvable.",
                               statusCode: (int)HttpStatusCode.NoContent);
        }

        [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            try
            {
                _categoryRepository.Insert(category);
            }
            catch (Exception)
            {
                return Problem(detail: "Impossible de créer cette catégorie.",
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
            catch (Exception)
            {
                return Problem(detail: "Impossible de mettre à jour cette catégorie.",
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
            catch (Exception)
            {
                return Problem(detail: "Impossible de supprimer cette catégorie.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            return Ok();
        }
    }
}
