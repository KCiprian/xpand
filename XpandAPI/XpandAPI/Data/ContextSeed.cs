using XpandAPI.Data.Entities;

namespace XpandAPI.Data
{
    public sealed class ContextSeed
    {
        public static void Initialize(XpandContext context)
        {
            context.Database.EnsureCreated();

            if (context.Humans.Any())
            {
                return;
            }

            var human = new Human()
            {
                Name = "captain",
                Password = "473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA8",
                Role = Enums.HumanRole.Captain,
                Team = new Team()
                {
                    Name = "Team 1",
                    Robots = new List<Robot>()
                    {
                        new Robot()
                        {
                            Name = "robot 1",
                            Planet = new Planet()
                            {
                                Name = "Planet 1",
                                Description = "planet desc 1",
                                Status = Enums.PlanetStatus.OK,
                            }
                        }
                    }
                }
            };
            context.Humans.Add(human);
            context.SaveChanges();
        }
    }
}
