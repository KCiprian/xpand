using Microsoft.EntityFrameworkCore;
using XpandAPI.Data;
using XpandAPI.Data.Entities;
using XpandAPI.Data.Enums;
using XpandAPI.Models.Human;
using XpandAPI.Services.Interface;

namespace XpandAPI.Services
{
    public class HumanService : IHumanService
    {
        private readonly ILogger _logger;
        private readonly XpandContext _context;

        public HumanService(ILogger<HumanService> logger, XpandContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<bool> Add(AddHumanModel humanModel)
        {
            try
            {
                var human = new Human
                {
                    Name = humanModel.Name,
                    Password = humanModel.Password,
                    Role = humanModel.Role,
                };
                await _context.Humans.AddAsync(human);
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
                var human = await _context.Humans.FirstOrDefaultAsync(o => o.Id == id);
                if (human == null)
                {
                    return false;
                }
                _context.Humans.Remove(human);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message);
            }
            return false;
        }

        public async Task<HumanModel> GetHuman(int id)
        {
            try
            {
                var human = await _context.Humans.FirstOrDefaultAsync(o => o.Id == id);
                if (human == null)
                {
                    return null;
                }
                return human.ToModel();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message);
            }
            return null;
        }

        public async Task<IEnumerable<HumanModel>> GetHumans()
        {
            try
            {
                var humans = await _context.Humans.ToListAsync();
                return humans.Select(o => o.ToModel());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message);
            }
            return new List<HumanModel>();
        }

        public async Task<bool> Update(int id, UpdateHumanModel humanModel)
        {
            try
            {
                var human = await _context.Humans.FirstOrDefaultAsync(o => o.Id == id);
                if (human == null)
                {
                    return false;
                }
                if (!string.IsNullOrWhiteSpace(humanModel.Name))
                {
                    human.Name = humanModel.Name;
                }
                if (!string.IsNullOrWhiteSpace(humanModel.Password))
                {
                    human.Password = humanModel.Password;
                }
                if (humanModel.Role.HasValue)
                {
                    human.Role = (HumanRole)humanModel.Role;
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
