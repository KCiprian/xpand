using Microsoft.EntityFrameworkCore;
using XpandAPI.Data;
using XpandAPI.Data.Entities;
using XpandAPI.Extensions;
using XpandAPI.Models.Team;
using XpandAPI.Services.Interface;

namespace XpandAPI.Services
{
    public class TeamService : ITeamService
    {
        private readonly ILogger _logger;
        private readonly XpandContext _context;
        public TeamService(ILogger<TeamService> logger, XpandContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<bool> Add(AddTeamModel teamModel)
        {
            try
            {
                var team = new Team
                {
                    Name = teamModel.Name,
                };
                await _context.Teams.AddAsync(team);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message);
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var team = await _context.Teams.FirstOrDefaultAsync(o => o.Id == id);
                if (team == null)
                {
                    return false;
                }
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message);
            }
            return false;
        }

        public async Task<TeamModel> GetTeam(int id)
        {
            try
            {
                var team = await _context.Teams.FirstOrDefaultAsync(o => o.Id == id);
                if (team == null)
                {
                    return null;
                }
                return team.ToModel();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message);
            }
            return null;
        }

        public async Task<IEnumerable<TeamModel>> GetTeams()
        {
            try
            {
                var teams = await _context.Teams.ToListAsync();
                return teams.Select(o => o.ToModel());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message);
            }
            return new List<TeamModel>();
        }

        public async Task<bool> Update(int id, UpdateTeamModel teamModel)
        {
            try
            {
                var team = await _context.Teams.FirstOrDefaultAsync(o => o.Id == id);
                if (team == null)
                {
                    return false;
                }
                if (!string.IsNullOrWhiteSpace(teamModel.Name))
                {
                    team.Name = teamModel.Name;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message);
            }
            return false;
        }
    }
}
