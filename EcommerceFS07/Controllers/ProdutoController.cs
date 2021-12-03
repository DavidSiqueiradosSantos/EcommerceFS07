using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceFS07.Context;
using EcommerceFS07.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceFS07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (EcommerceContext cxt = new EcommerceContext())
            {
                var prod = cxt.Produtos.Include(p => p.Descrição).Include(p => p.Valor).ToList();
                return Ok(prod);

            }
        }

        [HttpGet("{id}")]
        public ActionResult getPeloId(int id)
        {
            using (EcommerceContext cxt = new EcommerceContext())
            {
                Produto produto = cxt.Produtos.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (produto == null)
                    return NotFound();

                return Ok(produto);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (EcommerceContext cxt = new EcommerceContext())
            {
                Produto produto = cxt.Produtos.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (produto == null)
                    cxt.Produtos.Remove(produto);
                cxt.SaveChanges();
            }
            return Ok();

        }

    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        using (EcommerceContext ctx = new EcommerceContext())
        {
            ctx.Produtos.Add(produto);
            ctx.SaveChanges();
        }
        return Ok(produto);
    }



    [HttpPut]
     public ActionResult Put(Produto produto)
    {
        using (EcommerceContext ctx = new EcommerceContext())
        {
            ctx.Produtos.Update(produto);
            ctx.SaveChanges();
        }
        return Ok(produto);
    }
}
}