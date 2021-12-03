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
        public class EnderecoController : ControllerBase
        {
            [HttpGet]
            public ActionResult Get()
            {
            using (EcommerceContext ctx = new EcommerceContext())
                {
                    return Ok(ctx.Enderecos.ToList());
                }
            }

            [HttpGet("{id}")]
            public ActionResult getPeloId(int id)
            {
                using (EcommerceContext ctx = new EcommerceContext())
                {
                Endereco endereco = ctx.Enderecos.Where( e => e.Id.Equals(id)).FirstOrDefault();

                    if (endereco == null)
                        return base.NotFound();

                    return base.Ok(endereco);
                }
            }

            [HttpDelete("{id}")]
            public ActionResult Delete(int id)
            {
                using (EcommerceContext ctx = new EcommerceContext())
                {
                Endereco endereco = ctx.Enderecos.Where(e => e.Id.Equals(id)).FirstOrDefault();

                    if (endereco == null)
                        return base.NotFound();

                    ctx.Enderecos.Remove(endereco);
                    ctx.SaveChanges();
                }
                return Ok();
            }

            [HttpPost]
            public ActionResult Post(Endereco endereco)
            {
                using (EcommerceContext ctx = new EcommerceContext())
                {
                    ctx.Enderecos.Add(endereco);
                    ctx.SaveChanges();
                }
                return Ok(endereco);
            }

            [HttpPut]
            public ActionResult Put(Endereco endereco)
            {
                using (EcommerceContext ctx = new EcommerceContext())
                {
                    ctx.Enderecos.Update(endereco);
                    ctx.SaveChanges();
                }
                return Ok(endereco);
            }
        }
    }

