using System.Runtime.Serialization;
using XpandAPI.Data.Enums;

namespace XpandAPI.Models.Planet
{
    [DataContract]
    public class UpdatePlanetModel
    {
        [DataMember]
        public string? Name { get; set; }
        [DataMember]
        public string? Description { get; set; }
        [DataMember]
        public PlanetStatus? Status { get; set; }
        [DataMember]
        public byte[]? Image { get; set; }
    }
}
