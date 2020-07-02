using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        private readonly HeroiContext _context;

        public HeroiController(HeroiContext context)
        {
            _context = context;
        }
        // GET: api/<HeroiController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Heroi());
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex}");
            }
          
        }

        // GET api/<HeroiController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok();
        }

        // POST api/<HeroiController>
        [HttpPost]
        public ActionResult Post(Heroi model)
        {
            try
            {
                
                _context.Herois.Add(model);
                _context.SaveChanges();

                return Ok("FUNCIONANDO");
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex}");
            }
        }

        // PUT api/<HeroiController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Heroi model)
        {
            try
            {
                if (_context.Herois.AsNoTracking().FirstOrDefault(
                    h => h.Id == id) != null) //Sendo o Id informado igual ao BD,faça alterção
                {
                    _context.Herois.Update(model);
                    _context.SaveChanges();

                    return Ok("FUNCIONANDO");
                }
                return Ok("Não Encontrado!!");
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex}");
            }
        }

        // DELETE api/<HeroiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var heroi = _context.Herois
                            .Where(x => x.Id == id)
                            .Single();
            _context.Herois.Remove(heroi);
            _context.SaveChanges();
        }
    }
}
