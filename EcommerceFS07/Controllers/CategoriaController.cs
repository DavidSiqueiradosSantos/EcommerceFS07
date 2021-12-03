using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceFS07.Context;
using EcommerceFS07.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceFS07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (EcommerceContext cxt = new EcommerceContext())
            {
                return Ok(cxt.Categorias.ToList());

            }
        }

        [HttpGet("{id}")]
        public ActionResult getPeloId(int id)
        {
            using (EcommerceContext cxt = new EcommerceContext())
            {
                Categoria categoria = cxt.Categorias.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (categoria == null)
                    return NotFound();

                return Ok(categoria);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (EcommerceContext cxt = new EcommerceContext())
            {
                Categoria categoria = cxt.Categorias.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (categoria == null)
                    cxt.Categorias.Remove(categoria);
                cxt.SaveChanges();
            }
            return Ok();

        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.Categorias.Add(categoria);
                ctx.SaveChanges();
            }
            return Ok(categoria);
        }



        [HttpPut]
        public ActionResult Put(Categoria categoria)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.Categorias.Update(categoria);
                ctx.SaveChanges();
            }
            return Ok(categoria);
        }
    }
}