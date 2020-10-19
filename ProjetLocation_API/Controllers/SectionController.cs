using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DAL.Repositories;
using System;
using System.Net;
using DAL.Models;
using ProjetLocation.API.Models.User.RoleName;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetLocation.API.Controllers
{
    [Authorize(Roles = Roles.User + "," + Roles.Admin + "," + Roles.SuperAdmin)]
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private SectionRepository _sectionRepository;

        public SectionController(SectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        // GET: api/<SectionController>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll() // POSTMAN OK
        {
            IEnumerable<Section> sections = _sectionRepository.GetAll().Select(x => x);

            if (!(sections is null))
                return Ok(sections);
            else
                return Problem(detail: "Sections introuvables.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // GET api/<SectionController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id) // POSTMAN OK
        {
            Section section = _sectionRepository.GetById(id);

            if (!(section is null))
                return Ok(section);
            else
                return Problem(detail: "Section introuvable.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        [AllowAnonymous]
        [HttpGet("{id}/categories")]
        public IActionResult GetCategoriesBySectionId(int id) // POSTMAN OK
        {
            IEnumerable<Category> categories = _sectionRepository.GetCategoriesBySectionId(id).Select(x => x);

            if (!(categories is null))
                return Ok(categories);
            else
                return Problem(detail: "Impossible de récupérer les catégories de la section.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // POST api/<SectionController>
        [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
        [HttpPost]
        public IActionResult Post([FromBody] Section section) // POSTMAN OK
        {
            int Successful = 0;

            try
            {
                Successful = _sectionRepository.Insert(section);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UK_Section_Name"))
                    return Problem(detail: "Le nom de la section existe déjà.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Impossible de créer une section.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // PUT api/<SectionController>/5
        [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Section section) // POSTMAN OK
        {
            int Successful = 0;

            try
            {
                Successful = _sectionRepository.Update(id, section);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UK_Section_Name"))
                    return Problem(detail: "Le nom de la section existe déjà.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Impossible de mettre à jour la section.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // DELETE api/<SectionController>/5
        [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) // POSTMAN OK
        {
            int Successful = _sectionRepository.Delete(id);

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Impossible de supprimer la section.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }
    }
}
