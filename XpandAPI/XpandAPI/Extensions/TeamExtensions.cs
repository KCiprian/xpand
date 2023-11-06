using XpandAPI.Data.Entities;
using XpandAPI.Models.Team;

namespace XpandAPI.Extensions
{
    internal static class TeamExtensions
    {
        public static TeamModel ToModel(this Team team)
        {
            return new TeamModel
            {
                Name = team.Name,
                Humans = team.Humans.Select(o => o.ToModel()).ToList(),
            };
        }
    }
}
