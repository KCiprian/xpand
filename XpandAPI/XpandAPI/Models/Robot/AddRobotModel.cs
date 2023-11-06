using System.Runtime.Serialization;

namespace XpandAPI.Models.Robot
{
    [DataContract]
    public class AddRobotModel
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int? TeamId { get; set; }
        [DataMember]
        public int? PlanetId { get; set; }
    }
}
