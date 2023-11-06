using System.Runtime.Serialization;
using XpandAPI.Data.Enums;

namespace XpandAPI.Models.Human
{
    [DataContract]
    public class HumanModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public HumanRole Role { get; set; }
        [DataMember]
        public int? TeamId { get; set; }
    }
}
