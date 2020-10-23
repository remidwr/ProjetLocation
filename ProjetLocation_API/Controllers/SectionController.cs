using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetLocation.API.Models.Good;
using ProjetLocation.API.Models.User.RoleName;
using ProjetLocation.API.Services;
using System;
using System.Collections.Generic;
using System.Net;

namespace ProjetLocation.API.Controllers
{
    [Authorize(Roles = Roles.User + "," + Roles.Admin + "," + Roles.SuperAdmin)]
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly SectionService _sectionService;

        public SectionController(SectionService sectionService)
        {
            _sectionService = sectionService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<SectionFull> sections = _sectionService.GetAll();

            if (!(sections is null))
                return Ok(sections);
            else
                return NotFound();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            SectionFull section = _sectionService.GetById(id);

            if (!(section is null))
                return Ok(section);
            else
                return NotFound();
        }

        [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
        [HttpPost]
        public IActionResult Post([FromBody] Section section)
        {
            try
            {
                _sectionService.Post(section);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UK_Section_Name"))
                    return Problem(detail: "Le nom de cette section existe déjà.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            return Ok();
        }

        [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Section section)
        {
            try
            {
                _sectionService.Put(id, section);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UK_Section_Name"))
                    return Problem(detail: "Le nom de cette section existe déjà.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
                else if (ex.Message.Contains("Section doesn't exist"))
                    return Problem(detail: "Cette section n'existe pas.",
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
                _sectionService.Delete(id);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable To Delete Section"))
                    return Problem(detail: "Impossible de supprimer cette section car elle est liée à un bien.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            return Ok();
        }
    }
}
