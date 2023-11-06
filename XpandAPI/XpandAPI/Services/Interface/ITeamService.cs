using XpandAPI.Models.Team;

namespace XpandAPI.Services.Interface
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamModel>> GetTeams();
        Task<TeamModel> GetTeam(int id);
        Task<bool> Add(AddTeamModel teamModel);
        Task<bool> Update(int id, UpdateTeamModel teamModel);
        Task<bool> Delete(int id);
    }
}
