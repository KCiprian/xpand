using XpandAPI.Models.Shuttle;

namespace XpandAPI.Services.Interface
{
    public interface IShuttleService
    {
        Task<IEnumerable<ShuttleModel>> GetShuttles();
        Task<ShuttleModel> GetShuttle(int id);
        Task<bool> Add(AddShuttleModel shuttleModel);
        Task<bool> Update(int id, UpdateShuttleModel shuttleModel);
        Task<bool> Delete(int id);
    }
}
