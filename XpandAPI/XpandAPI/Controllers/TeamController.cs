using Microsoft.AspNetCore.Mvc;
using XpandAPI.Models.Team;
using XpandAPI.Services.Interface;

namespace XpandAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<ActionResult<TeamModel>> GetTeams()
        {
            var teams = await _teamService.GetTeams();
            if (teams == null)
            {
                return NotFound();
            }
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamModel>> GetTeam(int id)
        {
            var team = await _teamService.GetTeam(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Add([FromBody] AddTeamModel teamModel)
        {
            return Ok(await _teamService.Add(teamModel));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<bool>> Update(int id, [FromBody] UpdateTeamModel teamModel)
        {
            var team = await _teamService.GetTeam(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(await _teamService.Update(id, teamModel));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var team = await _teamService.GetTeam(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(await _teamService.Delete(id));
        }
    }
}
