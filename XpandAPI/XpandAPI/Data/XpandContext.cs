using Microsoft.EntityFrameworkCore;
using XpandAPI.Data.Entities;

namespace XpandAPI.Data
{
    public class XpandContext : DbContext
    {
        public XpandContext(DbContextOptions<XpandContext> options) : base(options) { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Shuttle> Shuttles { get; set; }
        public DbSet<Robot> Robots { get; set; }
        public DbSet<Human> Humans { get; set; }
    }
}
