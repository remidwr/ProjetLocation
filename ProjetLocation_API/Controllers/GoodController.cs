using System.Collections.Generic;
using System.Linq;
using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetLocation.API.Models.Good;
using ProjetLocation.API.Models.User.RoleName;
using ProjetLocation.API.Utils.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetLocation.API.Controllers
{
    [Authorize(Roles = Roles.User + "," + Roles.Admin + "," + Roles.SuperAdmin)]
    [Route("api/[controller]")]
    [ApiController]
    public class GoodController : ControllerBase
    {
        private IGenericRepository<Good> _goodRepository;

        public GoodController(GoodRepository goodRepository)
        {
            _goodRepository = goodRepository;
        }

        // GET: api/<GoodController>
        [HttpGet]
        public IActionResult GetAll() // POSTMAN OK
        {
            IEnumerable<GoodWithSection> goods = _goodRepository.GetAll().Select(x => x.DALGoodWithSectionToAPI());

            if (!(goods is null))
                return Ok(goods);
            else
                return NotFound();
        }

        // GET api/<GoodController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id) // POSTMAN OK
        {
            GoodWithSection good = _goodRepository.GetById(id).DALGoodWithSectionToAPI();

            if (!(good is null))
                return Ok(good);
            else
                return NotFound();
        }

        // POST api/<GoodController>
        [HttpPost]
        public IActionResult Post([FromBody] Good good) // POSTMAN OK
        {
            int Successful =  _goodRepository.Insert(good);

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }

        // PUT api/<GoodController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Good good) // POSTMAN OK
        {
            int Successful = _goodRepository.Update(id, good);

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }

        // DELETE api/<GoodController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) // POSTMAN OK
        {
            int Successful = _goodRepository.Delete(id);

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }
    }
}
