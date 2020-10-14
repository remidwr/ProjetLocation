using System.Collections.Generic;
using System.Linq;
using System.Net;
using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetLocation.API.Models.Good;
using ProjetLocation.API.Models.User;
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
        private IGoodRepository<Good,User, Section, Category> _goodRepository;

        public GoodController(GoodRepository goodRepository)
        {
            _goodRepository = goodRepository;
        }

        // GET: api/<GoodController>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll() // POSTMAN OK
        {
            IEnumerable<GoodWithSection> goods = _goodRepository.GetAll().Select(x => x.DALGoodWithSectionToAPI());

            if (!(goods is null))
                return Ok(goods);
            else
                return Problem(detail: "Goods not found",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // GET api/<GoodController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id) // POSTMAN OK
        {
            GoodWithSection good = _goodRepository.GetById(id).DALGoodWithSectionToAPI();

            if (!(good is null))
                return Ok(good);
            else
                return Problem(detail: "Good not found",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        [HttpGet("{id}/user")]
        public IActionResult GetUserByGoodId(int id)
        {
            UserInfo user = _goodRepository.GetUserByGoodId(id).DALUserInfoToAPI();

            if (!(user is null))
                return Ok(user);
            else
                return Problem(detail: "Utilisateur introuvable",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // POST api/<GoodController>
        [HttpPost]
        public IActionResult Post([FromBody] Good good) // POSTMAN OK
        {
            int Successful =  _goodRepository.Insert(good);

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Unable to create good",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // PUT api/<GoodController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Good good) // POSTMAN OK
        {
            int Successful = _goodRepository.Update(id, good);

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Unable to update good",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // DELETE api/<GoodController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) // POSTMAN OK
        {
            int Successful = _goodRepository.Delete(id);

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Unable to delete good",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }
    }
}
