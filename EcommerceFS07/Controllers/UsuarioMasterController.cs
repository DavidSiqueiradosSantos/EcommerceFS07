using EcommerceFS07.Context;
using EcommerceFS07.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceFS07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioMasterController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                return Ok(ctx.UsuariosMaster.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult getPeloId(int id)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                UsuarioMaster usuarioMaster = ctx.UsuariosMaster.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (usuarioMaster == null)
                    return NotFound();

                return Ok(usuarioMaster);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delte(int id)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                UsuarioMaster usuarioMaster = ctx.UsuariosMaster.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (usuarioMaster == null)
                    return NotFound();

                ctx.UsuariosMaster.Remove(usuarioMaster);
                ctx.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(UsuarioMaster usuarioMaster)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.UsuariosMaster.Add(usuarioMaster);
                ctx.SaveChanges();
            }
            return Ok(usuarioMaster);
        }

        [HttpPost("login")]
        public ActionResult Login(UsuarioMaster usuarioMaster)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                UsuarioMaster usuario = ctx.UsuariosMaster.Where(u => u.Email.Equals(usuarioMaster.Email) && u.Senha.Equals(usuarioMaster.Senha)).FirstOrDefault();

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
        public ActionResult Put(UsuarioMaster usuarioMaster)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.UsuariosMaster.Update(usuarioMaster);
                ctx.SaveChanges();
            }
            return Ok(usuarioMaster);
        }
    }
}