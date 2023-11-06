using Microsoft.EntityFrameworkCore;
using XpandAPI.Data;
using XpandAPI.Data.Entities;
using XpandAPI.Data.Enums;
using XpandAPI.Extensions;
using XpandAPI.Models.Planet;
using XpandAPI.Services.Interface;

namespace XpandAPI.Services
{
    public class PlanetService : IPlanetService
    {
        private readonly ILogger _logger;
        private readonly XpandContext _context;
        public PlanetService(XpandContext context, ILogger<PlanetService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<bool> Add(AddPlanetModel planetModel)
        {
            try
            {
                var planet = new Planet
                {
                    Name = planetModel.Name,
                    Description = planetModel.Description,
                    Status = planetModel.Status,
                    Image = planetModel.Image,
                };
                await _context.Planets.AddAsync(planet);
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
                var planet = await _context.Planets.FirstOrDefaultAsync(o => o.Id == id);
                if (planet == null)
                {
                    return false;
                }
                _context.Planets.Remove(planet);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message);
            }
            return false;
        }

        public async Task<PlanetModel> GetPlanet(int Id)
        {
            try
            {
                var planet = await _context.Planets.FirstOrDefaultAsync(o => o.Id == Id);
                if (planet == null)
                {
                    return null;
                }
                return planet.ToModel();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message);
            }
            return null;
        }

        public async Task<IEnumerable<PlanetDetailsDto>> GetPlanets()
        {
            try
            {
                var planetDetails = await _context.Planets.Include(o => o.Robots).ThenInclude(o => o.Team).ThenInclude(o => o.Humans).Select(o => new PlanetDetailsDto
                {
                    PlanetId = o.Id,
                    PlanetName = o.Name,
                    PlanetDescription = o.Description,
                    PlanetImage = o.Image,
                    PlanetStatus = o.Status,
                    Robots = o.Robots.Select(o => o.ToModel()).ToList(),
                    Captains = o.Robots.SelectMany(o => o.Team.Humans.Where(o => o.Role == HumanRole.Captain)).Select(o => o.ToModel()).Distinct().ToList(),
                }).ToListAsync();
                return planetDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message);
            }
            return new List<PlanetDetailsDto>();
        }

        public async Task<bool> Update(int id, UpdatePlanetModel planetModel)
        {
            try
            {
                var planet = await _context.Planets.FirstOrDefaultAsync(o => o.Id == id);
                if (planet == null)
                {
                    return false;
                }
                if (!string.IsNullOrWhiteSpace(planetModel.Name))
                {
                    planet.Name = planetModel.Name;
                }
                if (!string.IsNullOrWhiteSpace(planetModel.Description))
                {
                    planet.Description = planetModel.Description;
                }
                if (!planetModel.Status.HasValue)
                {
                    planet.Status = (PlanetStatus)planetModel.Status;
                }
                if (planetModel.Image is null) { }
                else
                {
                    planet.Image = planetModel.Image;
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
