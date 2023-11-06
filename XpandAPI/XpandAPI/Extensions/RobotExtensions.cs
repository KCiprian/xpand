using XpandAPI.Data.Entities;
using XpandAPI.Models.Robot;

namespace XpandAPI.Extensions
{
    internal static class RobotExtensions
    {
        public static RobotModel ToModel(this Robot robot)
        {
            return new RobotModel
            {
                Id = robot.Id,
                Name = robot.Name,
                TeamId = robot.TeamId,
                PlanetId = robot.PlanetId,
            };
        }
    }
}
