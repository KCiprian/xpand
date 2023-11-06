namespace XpandAPI.Data.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Human> Humans { get; set; }
        public ICollection<Robot> Robots { get; set; }
    }
}
