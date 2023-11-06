using System.Runtime.Serialization;
using XpandAPI.Models.Human;

namespace XpandAPI.Models.Team
{
    [DataContract]
    public class TeamModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public ICollection<HumanModel> Humans { get; set; }
    }
}
