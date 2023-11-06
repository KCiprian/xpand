using System.Runtime.Serialization;

namespace XpandAPI.Models.Shuttle
{
    [DataContract]
    public class ShuttleModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int? TeamId { get; set; }
    }
}
