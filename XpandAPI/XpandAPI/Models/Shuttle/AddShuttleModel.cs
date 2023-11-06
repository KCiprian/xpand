using System.Runtime.Serialization;

namespace XpandAPI.Models.Shuttle
{
    [DataContract]
    public class AddShuttleModel
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int? TeamId { get; set; }
    }
}
