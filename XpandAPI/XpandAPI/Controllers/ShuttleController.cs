using Microsoft.AspNetCore.Mvc;
using XpandAPI.Models.Shuttle;
using XpandAPI.Services.Interface;

namespace XpandAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShuttleController : ControllerBase
    {
        private readonly IShuttleService _shuttleservice;
        public ShuttleController(IShuttleService shuttleservice)
        {
            _shuttleservice = shuttleservice;
        }

        [HttpGet]
        public async Task<ActionResult<ShuttleModel>> GetShuttles()
        {
            var shuttles = await _shuttleservice.GetShuttles();
            if (shuttles == null)
            {
                return NotFound();
            }
            return Ok(shuttles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShuttleModel>> GetShuttle(int id)
        {
            var shuttle = await _shuttleservice.GetShuttle(id);
            if (shuttle == null)
            {
                return NotFound();
            }
            return Ok(shuttle);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Add([FromBody] AddShuttleModel shuttleModel)
        {
            return Ok(await _shuttleservice.Add(shuttleModel));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<bool>> Update(int id, [FromBody] UpdateShuttleModel shuttleModel)
        {
            var shuttle = await _shuttleservice.GetShuttle(id);
            if (shuttle == null)
            {
                NotFound();
            }
            return Ok(await _shuttleservice.Update(id, shuttleModel));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var shuttle = await _shuttleservice.GetShuttle(id);
            if (shuttle == null)
            {
                NotFound();
            }
            return Ok(await _shuttleservice.Delete(id));
        }
    }
}
