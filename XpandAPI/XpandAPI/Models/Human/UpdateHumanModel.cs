using XpandAPI.Data.Enums;

namespace XpandAPI.Models.Human
{
    public class UpdateHumanModel
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public HumanRole? Role { get; set; }
        public int? TeamId { get; set; }
    }
}
