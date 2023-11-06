using System.Runtime.Serialization;

namespace XpandAPI.Models.Team
{
    [DataContract]
    public class UpdateTeamModel
    {
        [DataMember]
        public string? Name { get; set; }
    }
}
