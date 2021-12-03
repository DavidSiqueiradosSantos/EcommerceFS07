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
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                return Ok(ctx.Clientes.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetPeloId(int id)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                Cliente cliente = ctx.Clientes.Include(c => c.Endereco).Where(c => c.Id.Equals(id)).FirstOrDefault();

                if (cliente == null)
                    return NotFound();

                return Ok(cliente);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                Cliente cliente = ctx.Clientes.Where(c => c.Id.Equals(id)).FirstOrDefault();

                if (cliente == null)
                    return NotFound();

                ctx.Clientes.Remove(cliente);
                ctx.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(Cliente cliente)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.Clientes.Add(cliente);
                ctx.SaveChanges();
            }
            return Ok(cliente);
        }

        [HttpPost("login")]
        public ActionResult Login(Cliente cliente)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                Cliente usuario = ctx.Clientes.Where(u => u.Email.Equals(cliente.Email) && u.Senha.Equals(cliente.Senha)).FirstOrDefault();

                if (usuario == null)
                    return NotFound();
                else
                {
                    usuario.Senha = "";
                    return Ok(usuario);
                }
            }
        }

        [HttpPut]
        public ActionResult Put(Cliente cliente)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.Clientes.Update(cliente);
                ctx.SaveChanges();
            }
            return Ok(cliente);
        }
    }
}