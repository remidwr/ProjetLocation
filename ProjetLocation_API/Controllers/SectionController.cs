using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DAL.Repositories;
using System;
using System.Net;
using DAL.Models;
using ProjetLocation.API.Models.User.RoleName;
using Microsoft.AspNetCore.Authorization;
using ProjetLocation.API.Models.Good;
using ProjetLocation.API.Utils.Extensions;

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
        [HttpGet]
        public IActionResult GetAll() // POSTMAN OK
        {
            IEnumerable<SectionName> sections = _sectionRepository.GetAll().Select(x => x.DALSectionNameToAPI());

            if (!(sections is null))
                return Ok(sections);
            else
                return Problem(detail: "Sections not found",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // GET api/<SectionController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id) // POSTMAN OK
        {
            SectionName section = _sectionRepository.GetById(id).DALSectionNameToAPI();

            if (!(section is null))
                return Ok(section);
            else
                return Problem(detail: "Section not found",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        [HttpGet("{id}/categoriesbysection")]
        public IActionResult GetCategoriesBySectionId(int id) // POSTMAN OK
        {
            IEnumerable<CategoryName> categories = _sectionRepository.GetCategoriesBySectionId(id).Select(x => x.DALCategoryNameToAPI());

            if (!(categories is null))
                return Ok(categories);
            else
                return Problem(detail: "Unable to get categories from section",
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
                    return Problem(detail: "Section name already exists !",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Unable to create section",
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
                    return Problem(detail: "Section name already exists !",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Unable to update section",
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
                return Problem(detail: "Unable to delete section",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }
    }
}
