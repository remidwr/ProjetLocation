using System.Collections.Generic;
using System.Net;
using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetLocation.API.Models.Good;
using ProjetLocation.API.Models.User;
using ProjetLocation.API.Models.User.RoleName;
using ProjetLocation.API.Services;
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
        private GoodService _goodService;

        public GoodController(GoodRepository goodRepository, GoodService goodService)
        {
            _goodRepository = goodRepository;
            _goodService = goodService;
        }

        // GET: api/<GoodController>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll() // POSTMAN OK
        {
            IEnumerable<GoodFull> goods = _goodService.GetAll();

            if (!(goods is null))
                return Ok(goods);
            else
                return Problem(detail: "Biens non trouvés.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // GET api/<GoodController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id) // POSTMAN OK
        {
            GoodFull good = _goodRepository.GetById(id).DALGoodFullToAPI();

            if (!(good is null))
                return Ok(good);
            else
                return Problem(detail: "Bien introuvable.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        [AllowAnonymous]
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
                return Problem(detail: "Impossible de créer un bien.",
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
                return Problem(detail: "Impossible de mettre à jour un bien.",
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
                return Problem(detail: "Impossible de supprimer un bien.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }
    }
}
