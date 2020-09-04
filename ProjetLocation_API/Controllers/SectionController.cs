using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DAL.IRepositories;
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
        private IGenericRepository<Section> _sectionRepository;

        public SectionController(SectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        // GET: api/<SectionController>
        [HttpGet]
        public IActionResult GetAll() // POSTMAN OK
        {
            IEnumerable<Section> sections = _sectionRepository.GetAll().Select(x => x);

            if (!(sections is null))
                return Ok(sections);
            else
                return NotFound();
        }

        // GET api/<SectionController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id) // POSTMAN OK
        {
            Section section = _sectionRepository.GetById(id);

            if (!(section is null))
                return Ok(section);
            else
                return NotFound();
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
                                   statusCode: (int)HttpStatusCode.Unauthorized);
            }

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
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
                                   statusCode: (int)HttpStatusCode.Unauthorized);
            }

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
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
                return NotFound();
        }
    }
}
