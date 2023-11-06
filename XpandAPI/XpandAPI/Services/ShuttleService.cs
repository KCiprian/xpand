using Microsoft.EntityFrameworkCore;
using XpandAPI.Data;
using XpandAPI.Data.Entities;
using XpandAPI.Extensions;
using XpandAPI.Models.Shuttle;
using XpandAPI.Services.Interface;

namespace XpandAPI.Services
{
    public class ShuttleService : IShuttleService
    {
        private readonly ILogger _logger;
        private readonly XpandContext _context;

        public ShuttleService(ILogger<ShuttleService> logger, XpandContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<bool> Add(AddShuttleModel shuttleModel)
        {
            try
            {
                var shuttle = new Shuttle
                {
                    Name = shuttleModel.Name,
                    TeamId = shuttleModel.TeamId,
                };
                await _context.AddAsync(shuttle);
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
                var shuttle = await _context.Shuttles.FirstOrDefaultAsync(o => o.Id == id);
                if (shuttle == null)
                {
                    return false;
                }
                _context.Shuttles.Remove(shuttle);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message);
            }
            return false;
        }

        public async Task<ShuttleModel> GetShuttle(int id)
        {
            try
            {
                var shuttle = await _context.Shuttles.FirstOrDefaultAsync(o => o.Id == id);
                if (shuttle == null)
                {
                    return null;
                }
                return shuttle.ToModel();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message);
            }
            return null;
        }

        public async Task<IEnumerable<ShuttleModel>> GetShuttles()
        {
            try
            {
                var shuttles = await _context.Shuttles.ToListAsync();
                return shuttles.Select(o => o.ToModel());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message);
            }
            return null;
        }

        public async Task<bool> Update(int id, UpdateShuttleModel shuttleModel)
        {
            try
            {
                var shuttle = await _context.Shuttles.FirstOrDefaultAsync(o => o.Id == id);
                if (shuttle == null)
                {
                    return false;
                }
                if (!string.IsNullOrWhiteSpace(shuttleModel.Name))
                {
                    shuttle.Name = shuttleModel.Name;
                }
                if (shuttleModel.TeamId.HasValue)
                {
                    shuttle.TeamId = shuttleModel.TeamId;
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
