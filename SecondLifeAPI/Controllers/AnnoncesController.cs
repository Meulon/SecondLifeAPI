
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SecondLife.Model.Entities;
using SecondLife.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SecondLifeAPI.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AnnoncesController : ControllerBase
    {
        private IAnnonceService _service;

        public AnnoncesController(IAnnonceService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Annonce>> List(string title)
        {
            Expression<Func<Annonce, bool>> condition = x => true;
            if (title != null)
            {
                condition = x => x.Title.Contains(title) || x.Description.Contains(title);
            }
            var res = _service.List(condition);
            if (res.Count == 0)
            {
                return NoContent();
            }

            return res;
        }

        [HttpPatch("{id}")]
        public ActionResult<Annonce> Patch(int id, [FromBody]JsonPatchDocument<Annonce> document)
        {
            var updateAnnonce = _service.Patch(id, document);
            return Ok(updateAnnonce);
        }

        [HttpGet("{id}")]
        public ActionResult<Annonce> Get(int id)
        {
            return _service.Get(id);
        }

        [HttpPost]
        public ActionResult<Annonce> Post(Annonce annonce)
        {
            var res = _service.Add(annonce);
            if (res == null)
            {
                return BadRequest("invalid title");
            }
            return res;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var res = _service.Delete(id);
            if(res)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
