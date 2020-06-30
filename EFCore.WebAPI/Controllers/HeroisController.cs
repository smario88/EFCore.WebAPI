using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroisController : ControllerBase
    {

        public HeroiContext _context;
        public HeroisController(HeroiContext context)
        {
            _context = context;
        }

        // GET: api/herois
        [HttpGet("filtro/{nome}")]
        public ActionResult GetFiltro(string nome)
        {
            var listHeroi = _context.Herois
                            .Where(h => h.Nome.Contains(nome))            
                            .ToList();
            //var listHeroi = (from heroi in _context.Herois
            //                 where heroi.Nome.Contains(nome)
            //                 select heroi).ToList();
            return Ok(listHeroi);
        }

        // GET api/herois/5
        [HttpGet("atualizar/{nameHero}")]
        public ActionResult Get(String nameHero)
        {
            //var heroi = new Heroi { Nome = nameHero };

            var heroi = _context.Herois
                            .Where(h => h.Id == 10)
                            .FirstOrDefault();
            heroi.Nome = "Viuva Negra";
            // _context.Herois.Add(heroi);
            _context.SaveChanges();

            return Ok();
        }

        // GET api/herois/5
        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            _context.AddRange(
                new Heroi { Nome = "Capitão América" },
                new Heroi { Nome = "Douto Estranho" },
                new Heroi { Nome = "Pantera Negra" },
                new Heroi { Nome = "Hulk" },
                new Heroi { Nome = "Gavião Arqueiro" },
                new Heroi { Nome = "Capitão Marvel" }
            );                            
            _context.SaveChanges();
          
            return Ok();
        }

        // POST api/herois
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/herois
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/herois
        [HttpGet("Delete/{id}")]
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
