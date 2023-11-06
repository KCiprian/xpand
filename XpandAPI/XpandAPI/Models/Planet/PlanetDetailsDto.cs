using XpandAPI.Data.Enums;
using XpandAPI.Models.Human;
using XpandAPI.Models.Robot;

namespace XpandAPI.Models.Planet
{
    public class PlanetDetailsDto
    {
        public int PlanetId { get; set; }
        public string PlanetName { get; set; }
        public string PlanetDescription { get; set; }
        public byte[]? PlanetImage { get; set; }
        public PlanetStatus? PlanetStatus { get; set; }
        public List<RobotModel> Robots { get; set; }
        public List<HumanModel> Captains { get; set; }

    }
}
