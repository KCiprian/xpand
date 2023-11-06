using XpandAPI.Data.Enums;

namespace XpandAPI.Models.Human
{
    public class AddHumanModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public HumanRole Role { get; set; }
        public int? TeamId { get; set; }
    }
}
