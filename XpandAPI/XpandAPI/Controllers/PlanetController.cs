using Microsoft.AspNetCore.Mvc;
using XpandAPI.Models.Planet;
using XpandAPI.Services.Interface;

namespace XpandAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanetController : ControllerBase
    {
        private readonly IPlanetService _planetService;
        public PlanetController(IPlanetService planetService)
        {
            _planetService = planetService;
        }

        [HttpGet]
        public async Task<ActionResult<PlanetModel>> GetPlanets()
        {
            var planets = await _planetService.GetPlanets();
            if (planets == null)
            {
                return NotFound();
            }
            return Ok(planets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlanetModel>> GetPlanet(int id)
        {
            var planet = await _planetService.GetPlanet(id);
            if (planet == null)
            {
                return NotFound();
            }
            return Ok(planet);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Add([FromBody] AddPlanetModel planetModel)
        {
            return await _planetService.Add(planetModel);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<bool>> Update(int id, [FromBody] UpdatePlanetModel planetModel)
        {
            var planet = await _planetService.GetPlanet(id);
            if (planet == null)
            {
                return NotFound();
            }
            return Ok(await _planetService.Update(id, planetModel));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var planet = await _planetService.GetPlanet(id);
            if (planet == null)
            {
                return NotFound();
            }
            return Ok(await _planetService.Delete(id));
        }
    }
}
