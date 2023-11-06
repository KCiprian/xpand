using Microsoft.AspNetCore.Mvc;
using XpandAPI.Models.Robot;
using XpandAPI.Services.Interface;

namespace XpandAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class RobotController : ControllerBase
    {
        private readonly IRobotService _robotService;
        public RobotController(IRobotService robotService)
        {
            _robotService = robotService;
        }

        [HttpGet]
        public async Task<ActionResult<RobotModel>> GetRobots()
        {
            var robots = await _robotService.GetRobots();
            if (robots == null)
            {
                return NotFound();
            }
            return Ok(robots);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RobotModel>> GetRobot(int id)
        {
            var robot = await _robotService.GetRobot(id);
            if (robot == null)
            {
                return NotFound();
            }
            return Ok(robot);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Add([FromBody] AddRobotModel robotModel)
        {
            return Ok(await _robotService.Add(robotModel));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<bool>> Update(int id, [FromBody] UpdateRobotModel robotModel)
        {
            var robot = await _robotService.GetRobot(id);
            if (robot == null)
            {
                return NotFound();
            }
            return Ok(await _robotService.Update(id, robotModel));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var robot = await _robotService.GetRobot(id);
            if (robot == null)
            {
                return NotFound();
            }
            return Ok(await _robotService.Delete(id));
        }
    }
}
