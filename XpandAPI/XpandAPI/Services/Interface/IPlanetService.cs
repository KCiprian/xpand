using XpandAPI.Models.Planet;

namespace XpandAPI.Services.Interface
{
    public interface IPlanetService
    {
        Task<IEnumerable<PlanetDetailsDto>> GetPlanets();
        Task<PlanetModel> GetPlanet(int Id);
        Task<bool> Add(AddPlanetModel planetModel);
        Task<bool> Update(int id, UpdatePlanetModel planetModel);
        Task<bool> Delete(int id);
    }
}
