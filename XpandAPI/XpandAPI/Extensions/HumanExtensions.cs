using XpandAPI.Data.Entities;
using XpandAPI.Models.Human;

namespace XpandAPI
{
    internal static class HumanExtensions
    {
        public static HumanModel ToModel(this Human human)
        {
            return new HumanModel
            {
                Id = human.Id,
                Name = human.Name,
                Role = human.Role,
            };
        }
    }
}
