using System.ComponentModel.DataAnnotations;
using XpandAPI.Data.Enums;

namespace XpandAPI.Data.Entities
{
    public class Human
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public HumanRole Role { get; set; }
        public int TeamId { get; set; }
        public Team? Team { get; set; }
    }
}
