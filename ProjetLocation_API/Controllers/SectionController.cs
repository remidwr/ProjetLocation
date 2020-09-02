using System.Collections.Generic;
using System.Linq;
using Dal = DAL.Models;
using Api = ProjetLocation.API.Models.Good;
using Microsoft.AspNetCore.Mvc;
using DAL.IRepositories;
using DAL.Repositories;
using ProjetLocation.API.Utils.Extensions;
using System;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetLocation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private ISectionRepository<Dal.Section> _sectionRepository;

        public SectionController(SectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        // GET: api/<SectionController>
        [HttpGet]
        public IActionResult GetAll() // POSTMAN OK
        {
            IEnumerable<Api.Section> sections = _sectionRepository.GetAll().Select(x => x.DALSectionToAPI());

            if (!(sections is null))
                return Ok(sections);
            else
                return NotFound();
        }

        // GET api/<SectionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) // POSTMAN OK
        {
            Api.Section section = _sectionRepository.Get(id).DALSectionToAPI();

            if (!(section is null))
                return Ok(section);
            else
                return NotFound();
        }

        // POST api/<SectionController>
        [HttpPost]
        public IActionResult Post([FromBody] Api.Section section) // POSTMAN OK
        {
            int Successful = 0;

            try
            {
                Successful = _sectionRepository.Insert(section.APISectionToDAL());
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
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Api.Section section) // POSTMAN OK
        {
            int Successful = 0;

            try
            {
                Successful = _sectionRepository.Update(id, section.APISectionToDAL());
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
