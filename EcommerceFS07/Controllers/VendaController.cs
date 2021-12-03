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
    public class VendaController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                return Ok(ctx.Vendas.Include(c => c.Cliente)
                    .Include(c => c.produto)
                    .ThenInclude(c => c.Descrição)
                    .Include(c => c.produto.Descrição)
                    .ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult getPeloId(int id)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                Venda venda = ctx.Vendas.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (venda == null)
                    return NotFound();

                return Ok(venda);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                Venda venda = ctx.Vendas.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (venda == null)
                    return NotFound();

                ctx.Vendas.Remove(venda);
                ctx.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(Venda venda)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.Vendas.Add(venda);
                ctx.SaveChanges();
            }
            return Ok(venda);
        }

        [HttpPost("CompraCarrinho")]
        public ActionResult PostCompraCarrinho([FromBody] List<Venda> vendas)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                for (int i = 0; i < vendas.Count(); i++)
                {
                    vendas[i].Cliente = ctx.Clientes.Where(c => c.Id.Equals(vendas[i].Cliente.Id)).FirstOrDefault();
                    vendas[i].produto = ctx.Produtos.Where(c => c.Id.Equals(vendas[i].produto.Id)).FirstOrDefault();

                    ctx.Vendas.Add(vendas[i]);
                }
                ctx.SaveChanges();
            }
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(Venda venda)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.Vendas.Update(venda);
                ctx.SaveChanges();
            }
            return Ok(venda);
        }
    }
}
