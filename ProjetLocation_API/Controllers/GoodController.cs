using System;
using System.Collections.Generic;
using System.Net;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetLocation.API.Models.Good;
using ProjetLocation.API.Models.User.RoleName;
using ProjetLocation.API.Services;

namespace ProjetLocation.API.Controllers
{
    [Authorize(Roles = Roles.User + "," + Roles.Admin + "," + Roles.SuperAdmin)]
    [Route("api/[controller]")]
    [ApiController]
    public class GoodController : ControllerBase
    {
        private GoodService _goodService;

        public GoodController(GoodService goodService)
        {
            _goodService = goodService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<GoodFull> goods = _goodService.GetAll();

            if (!(goods is null))
                return Ok(goods);
            else
                return Problem(detail: "Biens introuvables.",
                               statusCode: (int)HttpStatusCode.NoContent);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GoodFull good = _goodService.GetById(id);

            if (!(good is null))
                return Ok(good);
            else
                return Problem(detail: "Bien introuvable.",
                               statusCode: (int)HttpStatusCode.NoContent);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Good good)
        {
            try
            {
                _goodService.Post(good);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("CK_Good_Amount"))
                    return Problem(detail: "Le montant doit être positif.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
                else
                    return Problem(detail: "Impossible de créer ce bien.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Good good)
        {
            try
            {
                _goodService.Put(id, good);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("CK_Good_Amount"))
                    return Problem(detail: "Le montant doit être positif.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
                else
                    return Problem(detail: "Impossible de mettre à jour un bien.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _goodService.Delete(id);
            }
            catch (Exception)
            {
                return Problem(detail: "Impossible de supprimer un bien.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            return Ok();
        }
    }
}
