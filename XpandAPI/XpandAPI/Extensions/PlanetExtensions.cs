using XpandAPI.Data.Entities;
using XpandAPI.Models.Planet;

namespace XpandAPI.Extensions
{
    internal static class PlanetExtensions
    {
        public static PlanetModel ToModel(this Planet planet)
        {
            return new PlanetModel
            {
                Name = planet.Name,
                Description = planet.Description,
                Status = planet.Status,
                Image = planet.Image,
            };
        }
    }
}
