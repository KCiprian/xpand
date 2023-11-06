using System.ComponentModel.DataAnnotations;
using XpandAPI.Data.Enums;

namespace XpandAPI.Data.Entities
{
    public class Planet
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public PlanetStatus? Status { get; set; }
        public ICollection<Robot> Robots { get; set; }
        public byte[]? Image { get; set; }
    }
}
