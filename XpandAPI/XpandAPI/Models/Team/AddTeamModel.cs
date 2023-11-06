using System.Runtime.Serialization;

namespace XpandAPI.Models.Team
{
    [DataContract]
    public class AddTeamModel
    {
        [DataMember]
        public string Name { get; set; }
    }
}
