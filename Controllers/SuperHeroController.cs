using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York City"
            },
            new SuperHero
            {
                Id = 2,
                Name = "Iron Man",
                FirstName = "Tony",
                LastName = "Stark",
                Place = "Malibu"
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return Ok(superHeroes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = superHeroes.Find(sh => sh.Id == id);

            if (hero is null) return NotFound("Sorry, but this hero does not exist");
            
            return Ok(hero);
        }
        
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            
            return Ok(superHeroes);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var hero = superHeroes.Find(sh => sh.Id == id);

            if (hero is null) return NotFound("Sorry, but this hero does not exist");

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;
            
            return Ok(superHeroes);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = superHeroes.Find(sh => sh.Id == id);

            if (hero is null) return NotFound("Sorry, but this hero does not exist");

            superHeroes.Remove(hero);
            
            return Ok(superHeroes);
        }
    }
}