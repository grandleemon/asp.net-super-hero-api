using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/super-heroes")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return Ok(_superHeroService.GetAllHeroes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var result = _superHeroService.GetSingleHero(id);

            if (result is null) return NotFound("Sorry but this hero does not exist");
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            return Ok(_superHeroService.AddHero(hero));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var result = _superHeroService.UpdateHero(id, request);

            if (result is null) return NotFound("Sorry but this hero does not exist");
            
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = _superHeroService.DeleteHero(id);

            if (result is null) return NotFound("Sorry but this hero does not exist");
            
            return Ok(result);
        }
    }
}