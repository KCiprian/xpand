using XpandAPI.Models.Robot;

namespace XpandAPI.Services.Interface
{
    public interface IRobotService
    {
        Task<IEnumerable<RobotModel>> GetRobots();
        Task<RobotModel> GetRobot(int id);
        Task<bool> Add(AddRobotModel robotModel);
        Task<bool> Update(int id, UpdateRobotModel robotModel);
        Task<bool> Delete(int id);
    }
}
