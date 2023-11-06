using XpandAPI.Data.Entities;
using XpandAPI.Models.Shuttle;

namespace XpandAPI.Extensions
{
    internal static class ShuttleExtensions
    {
        public static ShuttleModel ToModel(this Shuttle shuttle)
        {
            return new ShuttleModel
            {
                Name = shuttle.Name,
                TeamId = shuttle.TeamId,
            };
        }
    }
}
