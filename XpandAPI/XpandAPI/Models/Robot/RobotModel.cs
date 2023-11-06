using System.Runtime.Serialization;

namespace XpandAPI.Models.Robot
{
    [DataContract]
    public class RobotModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int? TeamId { get; set; }
        [DataMember]
        public int? PlanetId { get; set; }
    }
}
