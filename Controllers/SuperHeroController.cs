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
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var superHeroes = new List<SuperHero>
            {
                new SuperHero
                    { Id = 1, 
                        Name = "Spider Man", 
                        FirstName = "Peter", 
                        LastName = "Parker", 
                        Place = "New York City" 
                    }
            };

            return Ok(superHeroes);
        }
    }
}