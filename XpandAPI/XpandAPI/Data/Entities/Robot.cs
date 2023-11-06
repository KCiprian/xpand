using System.ComponentModel.DataAnnotations;

namespace XpandAPI.Data.Entities
{
    public class Robot
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
        public int? PlanetId { get; set; }
        public Planet? Planet { get; set; }
    }
}
