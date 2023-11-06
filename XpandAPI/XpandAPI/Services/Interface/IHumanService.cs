using XpandAPI.Models.Human;

namespace XpandAPI.Services.Interface
{
    public interface IHumanService
    {
        Task<IEnumerable<HumanModel>> GetHumans();
        Task<HumanModel> GetHuman(int id);
        Task<bool> Add(AddHumanModel humanModel);
        Task<bool> Update(int id, UpdateHumanModel humanModel);
        Task<bool> Delete(int id);
    }
}
