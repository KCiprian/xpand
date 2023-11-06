using Microsoft.EntityFrameworkCore;
using XpandAPI.Data;
using XpandAPI.Data.Entities;
using XpandAPI.Extensions;
using XpandAPI.Models.Robot;
using XpandAPI.Services.Interface;

namespace XpandAPI.Services
{
    public class RobotService : IRobotService
    {
        private readonly ILogger _logger;
        private readonly XpandContext _context;

        public RobotService(ILogger<RobotService> logger, XpandContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<bool> Add(AddRobotModel robotModel)
        {
            try
            {
                var robot = new Robot
                {
                    Name = robotModel.Name,
                    TeamId = robotModel.TeamId,
                    PlanetId = robotModel.PlanetId,
                };
                await _context.Robots.AddAsync(robot);
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
                var robot = await _context.Robots.FirstOrDefaultAsync(o => o.Id == id);
                if (robot == null)
                {
                    return false;
                }
                _context.Robots.Remove(robot);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message);
            }
            return false;
        }

        public async Task<RobotModel> GetRobot(int id)
        {
            try
            {
                var robot = await _context.Robots.FirstOrDefaultAsync(o => o.Id == id);
                if (robot == null)
                {
                    return null;
                }
                return robot.ToModel();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message);
            }
            return null;
        }

        public async Task<IEnumerable<RobotModel>> GetRobots()
        {
            try
            {
                var robots = await _context.Robots.ToListAsync();
                return robots.Select(o => o.ToModel());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message);
            }
            return new List<RobotModel>();
        }

        public async Task<bool> Update(int id, UpdateRobotModel robotModel)
        {
            try
            {
                var robot = await _context.Robots.FirstOrDefaultAsync(o => o.Id == id);
                if (robot == null)
                {
                    return false;
                }
                if (!string.IsNullOrWhiteSpace(robotModel.Name))
                {
                    robot.Name = robotModel.Name;
                }
                if (robotModel.TeamId.HasValue)
                {
                    robot.TeamId = robotModel.TeamId;
                }
                if (robotModel.PlanetId.HasValue)
                {
                    robot.PlanetId = robotModel.PlanetId;
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
