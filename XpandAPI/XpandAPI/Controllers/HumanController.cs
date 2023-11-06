using Microsoft.AspNetCore.Mvc;
using XpandAPI.Models.Human;
using XpandAPI.Services.Interface;

namespace XpandAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class HumanController : ControllerBase
    {
        private readonly IHumanService _humanService;
        public HumanController(IHumanService humanService)
        {
            _humanService = humanService;
        }
        [HttpGet]
        public async Task<ActionResult<HumanModel>> GetHumans()
        {
            var humans = await _humanService.GetHumans();
            if (humans == null)
            {
                return NotFound();
            }
            return Ok(humans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HumanModel>> GetHuman(int id)
        {
            var human = await _humanService.GetHuman(id);
            if (human == null)
            {
                return NotFound();
            }
            return Ok(human);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Add([FromBody] AddHumanModel humanModel)
        {
            return Ok(await _humanService.Add(humanModel));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<bool>> Update(int id, [FromBody] UpdateHumanModel humanModel)
        {
            var human = await _humanService.GetHuman(id);
            if (human == null)
            {
                return NotFound();
            }
            return Ok(await _humanService.Update(id, humanModel));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var human = await _humanService.GetHuman(id);
            if (human == null)
            {
                return NotFound();
            }
            return Ok(await _humanService.Delete(id));
        }
    }
}
