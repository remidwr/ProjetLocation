using System.Collections.Generic;
using System.Linq;
using DAL.IRepositories;
using Dal = DAL.Models;
using Api = ProjetLocation.API.Models.Good;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using ProjetLocation.API.Utils.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetLocation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodController : ControllerBase
    {
        private IGoodRepository<Dal.Good> _goodRepository;

        public GoodController(GoodRepository goodRepository)
        {
            _goodRepository = goodRepository;
        }

        // GET: api/<GoodController>
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Api.Good> goods = _goodRepository.GetAll().Select(x => x.DALGoodToAPI());

            if (!(goods is null))
                return Ok(goods);
            else
                return NotFound();
        }

        // GET api/<GoodController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Api.Good good = _goodRepository.Get(id).DALGoodToAPI();

            if (!(good is null))
                return Ok(good);
            else
                return NotFound();
        }

        // POST api/<GoodController>
        [HttpPost]
        public IActionResult Post([FromBody] Api.Good good)
        {
            int Successful =  _goodRepository.Insert(good.APIGoodToDAL());

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }

        // PUT api/<GoodController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Api.Good good)
        {
            int Successful = _goodRepository.Update(id, good.APIGoodToDAL());

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }

        // DELETE api/<GoodController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int Successful = _goodRepository.Delete(id);

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }
    }
}
