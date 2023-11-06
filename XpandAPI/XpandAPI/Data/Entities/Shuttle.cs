namespace XpandAPI.Data.Entities
{
    public class Shuttle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
    }
}
